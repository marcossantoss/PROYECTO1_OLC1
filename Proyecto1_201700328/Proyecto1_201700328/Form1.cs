using Proyecto1_201700328.Analsis_thompson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        /*Esto permite el control de la aplicacion para ver las imagenes*/
        LinkedList<String> AFD;
        LinkedList<String> AFND;
        LinkedList<String> tranciones;

        int opcion = -1;
        int interacion = 1;
        

        public int contador_tabs = 0;
        TabPage pestana_actual = null;

        Hashtable pestanas = new Hashtable();

        Reportes_HTML.Reporte_html generar_reportes = new Reportes_HTML.Reporte_html();


        private void erroresLeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                 Process.Start("errores_XML.xml");

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
           //ahora decidimos que tipos de archivos leer para evitar buscar otras extensiones
            openFileDialog1.Filter = "Text [*.er*]|*.er|All Files [*,*]|*,*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Title = "Abrir archivo";
            
            try
            {

                openFileDialog1.ShowDialog();
                System.IO.StreamReader Abrir = new System.IO.StreamReader(openFileDialog1.FileName);
                
                
            
                String nombre_pagina = "pestaña" + contador_tabs;

                TabPage paginaNueva = new TabPage(nombre_pagina);
                RichTextBox lienzo = new RichTextBox();
                lienzo.Text = Abrir.ReadToEnd();
                lienzo.Height = 330;
                lienzo.Width = 555;
                paginaNueva.Controls.Add(lienzo);

                tabControl1.TabPages.Add(paginaNueva);

                pestanas.Add(paginaNueva, lienzo);

                contador_tabs++;
                Abrir.Close();

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

                generar_reportes.escribir_fichero_tokens_y_errores(analizar_lexicamente.returnListaTokens(), analizar_lexicamente.returnListaErroresLexicos());
       

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
                    AFND = hacer_analisis.rutas_AFND;
                    tranciones = hacer_analisis.rutas_transiciones;

                    richTextBox2.Text = hacer_analisis.log;
                   
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (tranciones.Count!=0)
            {
               
                pictureBox1.Image = Image.FromFile(AFND.First());
                opcion = 3;
                interacion = 1;
            }
            else
            {
                MessageBox.Show("LISTA VACIA");
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tranciones.Count != 0)
            {

                pictureBox1.Image = Image.FromFile(tranciones.First());
                opcion = 1;
                interacion = 1;
            }
            else
            {
                MessageBox.Show("LISTA VACIA");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tranciones.Count != 0)
            {

                pictureBox1.Image = Image.FromFile(AFD.First());
                opcion = 2;
                interacion = 1;
            }
            else
            {
                MessageBox.Show("LISTA VACIA");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (opcion == 1)
            {

                if (interacion < tranciones.Count)
                {
                 
                    pictureBox1.Image = Image.FromFile(tranciones.ElementAt(interacion));
                    interacion++;
                }
                else
                {
                    interacion = 0;
                    pictureBox1.Image = Image.FromFile(tranciones.ElementAt(interacion));

                }

            }
            else if (opcion == 2)
            {

                if (interacion < AFD.Count)
                {
                    pictureBox1.Image = Image.FromFile(AFD.ElementAt(interacion));
                    interacion++;
                }
                else
                {
                    interacion = 0;
                    pictureBox1.Image = Image.FromFile(AFD.ElementAt(interacion));
                }
            }
            else if (opcion == 3)
            {
                if (interacion < AFND.Count)
                {
                    pictureBox1.Image = Image.FromFile(AFND.ElementAt(interacion));
                    interacion++;
                }
                else
                {
                    interacion = 0;
                    pictureBox1.Image = Image.FromFile(AFND.ElementAt(interacion));

                }
            } else
            {
  
                MessageBox.Show("No se ha detectado una opcion de imagenes\n PULSE automatas, siguientes, arboles u automatas");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (opcion == 1)
            {

                if (0 < interacion)
                {

                    pictureBox1.Image = Image.FromFile(tranciones.ElementAt(interacion));
                    interacion--;

                }
                else
                {
                    interacion = 0;
                    pictureBox1.Image = Image.FromFile(tranciones.ElementAt(interacion));

                }

            }
            else if (opcion == 2)
            {
                try
                {
                    if (0 < interacion)
                    {

                        pictureBox1.Image = Image.FromFile(AFD.ElementAt(interacion));
                        interacion--;
                    }
                    else
                    {
                        interacion = 0;
                        pictureBox1.Image = Image.FromFile(AFD.ElementAt(interacion));
                    }
                }
                catch (Exception) {
                    MessageBox.Show("No hay mas imagenes");
                }
                }
            else if (opcion == 3)
            {
                if (0 < interacion)
                {

                    pictureBox1.Image = Image.FromFile(AFND.ElementAt(interacion));
                    interacion--;
                }
                else
                {
                    interacion = 0;
                    pictureBox1.Image = Image.FromFile(AFND.ElementAt(interacion));

                }
            }
            else
            {

                MessageBox.Show("No se ha detectado una opcion de imagenes\n PULSE automatas, siguientes, arboles u automatas");
            }
        }

        private void tokensXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                Process.Start("Tokens_XML.xml");
        }

        private void rEPORTEPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generar_reportes.mostrar_reporte__tokens_y_errores();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se crea un objeto de tipo savefiledialog que nos servira para guardar el archivo
            SaveFileDialog Save = new SaveFileDialog();
            System.IO.StreamWriter myStreamWriter = null;
            //al igual que para abrir el tipo de documentos aqui se especifica en que extenciones se puede guardar el archivo
            Save.Filter = "Text (*.er)|*.er|All files(*.*)|*.*";
            Save.CheckPathExists = true;
            Save.Title = "Guardar como";
            Save.ShowDialog(this);
            try
            {
                //este codigo se utiliza para guardar el archivo de nuestro editor
                myStreamWriter = System.IO.File.AppendText(Save.FileName);
                RichTextBox texto_analizar = buscar_pestana(pestana_actual);
                myStreamWriter.Write(texto_analizar.Text);
                myStreamWriter.Flush();

            }
            catch (Exception) { MessageBox.Show("No se guardo el archivo"); }

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se crea un objeto de tipo savefiledialog que nos servira para guardar el archivo
            SaveFileDialog Save = new SaveFileDialog();
            System.IO.StreamWriter myStreamWriter = null;
            //al igual que para abrir el tipo de documentos aqui se especifica en que extenciones se puede guardar el archivo
            Save.Filter = "Text (*.er)|*.er|All files(*.*)|*.*";
            Save.CheckFileExists = true;

            Save.Title = "Guardar";
            Save.ShowDialog(this);
            try
            {
                //este codigo se utiliza para guardar el archivo de nuestro editor
                RichTextBox texto_analizar = buscar_pestana(pestana_actual);
               
                myStreamWriter = System.IO.File.CreateText(Save.FileName);
                myStreamWriter.Write(texto_analizar.Text);
                myStreamWriter.Flush();

            }
            catch (Exception) { MessageBox.Show("No se guardo el archivo"); }

        }
    }
}
