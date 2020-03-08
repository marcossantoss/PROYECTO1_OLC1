using Proyecto1_201700328.Analsis_thompson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201700328
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LinkedList<String> AFD;
        LinkedList<String> AFND;
        LinkedList<String> tranciones;
       

        public int contador_tabs = 0;
        TabPage pestana_actual = null;

        Hashtable pestanas = new Hashtable();

        Reportes_HTML.Reporte_html generar_reportes = new Reportes_HTML.Reporte_html();


        private void erroresLeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creamos un objeto de tipo openfiledialog
            OpenFileDialog archivo = new OpenFileDialog();
            System.IO.StreamReader lectura = null;
            //ahora decidimos que tipos de archivos leer para evitar buscar otras extensiones
            archivo.Filter = "Text [*.er*]|*.er|All Files [*,*]|*,*";
            archivo.CheckFileExists = true;
            archivo.Title = "Abrir archivo";
            archivo.ShowDialog(this);
            try
            {
                archivo.OpenFile();
                lectura = System.IO.File.OpenText(archivo.FileName);


                String nombre_pagina = "pestaña" + contador_tabs;

                TabPage paginaNueva = new TabPage(nombre_pagina);
                RichTextBox lienzo = new RichTextBox();
                lienzo.Text = lectura.ReadToEnd();
                lienzo.Height = 330;
                lienzo.Width = 555;
                paginaNueva.Controls.Add(lienzo);

                tabControl1.TabPages.Add(paginaNueva);

                pestanas.Add(paginaNueva, lienzo);

                contador_tabs++;




            }
            catch (Exception)
            {
                MessageBox.Show("Error, no se puedo abrir el archivo");
            }



        }

        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //generamos nueva pestaña , un nuevo tabpage
            String nombre_pagina = "pestaña" + contador_tabs;

            TabPage paginaNueva = new TabPage(nombre_pagina);

            RichTextBox lienzo = new RichTextBox();

            lienzo.Text = "//archivo nuevo";
            lienzo.Height = 330;
            lienzo.Width = 555;

            paginaNueva.Controls.Add(lienzo);

            tabControl1.TabPages.Add(paginaNueva);

            pestanas.Add(paginaNueva, lienzo);

            contador_tabs++;




        }

        private void button6_Click(object sender, EventArgs e)
        {
            try {
                //removemos la llave si existe
                pestanas.Remove(pestana_actual);
                //removemos del tab pages
                tabControl1.TabPages.Remove(pestana_actual);

            }
            catch (Exception) {

                MessageBox.Show("No hay pestañas en el cuadro de edición,\nIntenta abrir un nuevo archivo o genera una nueva pestaña");

            }
           
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //obtenemos la pestaña seleccionado
            pestana_actual = tabControl1.SelectedTab;      


        }

        private RichTextBox buscar_pestana(TabPage pestana)
        {
            try
            {
                if (pestanas.ContainsKey(pestana))
                {
                    //CASTEAMOS LOS DATOS
                    return (RichTextBox)pestanas[pestana];
                }



            }
            catch (Exception) {

                MessageBox.Show("No se ha seleccionado una pestaña");

            }
            return null;
        }

        private void analizarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //obtenemos el texto
            RichTextBox texto_analizar = buscar_pestana(pestana_actual);

            if (texto_analizar == null){

                MessageBox.Show("No se seleccionó ninguna pestaña");

            } else {

           //     MessageBox.Show(texto_analizar.Text);
           Analizadores.Analisis_Lexico analizar_lexicamente = new Analizadores.Analisis_Lexico(texto_analizar.Text);
           analizar_lexicamente.scanner();

                
                generar_reportes.escribir_fichero_tokens(analizar_lexicamente.returnListaTokens());
                generar_reportes.probrando(analizar_lexicamente.returnListaErroresLexicos());

                Analizadores.Analisis_Sintactico analizar_sintacticamente = new Analizadores.Analisis_Sintactico(analizar_lexicamente.returnListaTokens());

                if (analizar_sintacticamente.parser()) {


                    MessageBox.Show("Analisis Sintactico correcto");

                    generar_reportes.escribir_macros(analizar_sintacticamente.Macros);
                    generar_reportes.escribir_lexemas(analizar_sintacticamente.Lexemas);
                    generar_reportes.escribir_expresionesregulares(analizar_sintacticamente.ExpresionesRegulares);

                    metodo_de_thompson hacer_analisis = new metodo_de_thompson(analizar_sintacticamente.Macros, analizar_sintacticamente.Lexemas, analizar_sintacticamente.ExpresionesRegulares);
                    hacer_analisis.procesar_expresiones();
                    hacer_analisis.thompson();
                    AFD = hacer_analisis.rutas_AFD;

                   
                }


                Console.WriteLine("Analisis concluido");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //generamos nueva pestaña , un nuevo tabpage
            String nombre_pagina = "pestaña" + contador_tabs;

            TabPage paginaNueva = new TabPage(nombre_pagina);

            RichTextBox lienzo = new RichTextBox();

            lienzo.Text = "//archivo nuevo";
            lienzo.Height = 330;
            lienzo.Width = 555;

            paginaNueva.Controls.Add(lienzo);

            tabControl1.TabPages.Add(paginaNueva);

            pestanas.Add(paginaNueva, lienzo);

            contador_tabs++;
        }

        private void tokensHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generar_reportes.mostrar_reporte_tokens();
        }

        private void erroresLexicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generar_reportes.mostrar_reporte_ErroresLexicos();
        }

        private void lexemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generar_reportes.mostrar_lexemas();
        }

        private void macrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generar_reportes.mostrar_macros();
        }

        private void expresionesRegularesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generar_reportes.mostrar_expresionesregulares();
        }
    }
}
