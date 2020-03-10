using Proyecto1_201700328.Analizadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201700328.Analsis_thompson
{


    public class Analisis_lexemas
    {

        LinkedList<Expresion_Lexema> lista_macros;
        LinkedList<Expresion_Lexema> lista_lexemas;
        LinkedList<Transicion> Transiciones;
        
        String Id;

        public Analisis_lexemas(LinkedList<Expresion_Lexema> lista_macros, LinkedList<Expresion_Lexema> lista_lexemas, LinkedList<Transicion> Transiciones,String id)
        {
            this.lista_macros = lista_macros;
            this.lista_lexemas = lista_lexemas;
            this.Transiciones = Transiciones;
            this.Id = id;
        }


        //aqui iniciamos con el analsis de las cadenas y ejecucion de reportes xml
        public String analizar_lexema() {

            String system_out_println = "";

            //iniciamos con el analisis de cada cadena segun el id
            foreach (Expresion_Lexema lexema in lista_lexemas) {
                String contendio = "";
                MessageBox.Show("Id actual: "+ Id);
                //aqui le decimos que solo analice las que tengan el id actual
                if (lexema.getIdentiicador().Equals(Id)) {

                    //limpiamo el contenido porque se cuelan algunos comentarios
                    

                    contendio = lexema.getContenido();

                    int tamanio_lexema =contendio.Length - 1;
                    int posicion = -1;
                    for (int i = tamanio_lexema; i > -1; i--)
                    {
                        //inicia de atras para adelante;
                        if (contendio[i] == '"')
                        {
                            posicion = i;
                            break;
                        }

                    }

                    //limpiamos la cadena quitandole las comillas doble de inicio fin
                    contendio = contendio.Substring(1, posicion-1);
                    MessageBox.Show(Id+" - "+contendio);

                    //ahora que ya tenemos la cadena limpia sin comillas dobles



                }


            }






            return system_out_println;
        }



    }
}
