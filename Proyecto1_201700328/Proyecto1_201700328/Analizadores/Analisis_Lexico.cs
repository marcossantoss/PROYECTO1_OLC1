using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201700328.Analizadores
{
    class Analisis_Lexico
    {
        //Contiene el texto cada vez que pulsamos analizar
        String contenido_areaTexto;

        public LinkedList<Token_lenguaje> ListaParser = new LinkedList<Token_lenguaje>();
        public LinkedList<Token_lenguaje> ListaErroresLexicos = new LinkedList<Token_lenguaje>();
        private int estado;
        private String lexema;



        //Iniciamos constructor
        public Analisis_Lexico(String contenido_areaTexto) {

            this.contenido_areaTexto = contenido_areaTexto;

        }

        public void scanner() {
            estado = 0;
            lexema = "";
            bool cuenta_llave_apertura = false;
            int fila = 1;
            int columna = 1;

            int auxcaracter = 0;//me va a servir en los casos donde se tenga que tener un caracter anticipado a su analisis


            char[] cadenaCarecteres = contenido_areaTexto.ToCharArray();

            for (int caracter = 0; caracter < cadenaCarecteres.Length; caracter++) {
                //verificamos 


                columna++;//aumenta la columna cada vez que lee el siguiente caracter
                auxcaracter++;

            }


        }

        /*
                 @aceptarToken
                 acepta el token si cumple alguna expreison del arbol de analisis lexico

        */
        private void aceptarToken(Token_lenguaje.TOKEN tipo, Object Lexema, int fila, int columna)
        {
            
            ListaParser.AddLast(new Token_lenguaje(tipo, Lexema, fila, columna));// se agrega el token a mi lista 
            lexema = "";//limpiamos el lexema
            estado = 0; // el estado regresa al estado inicial
             
        }

        /*
          @reportarToken
          niega el token si no cumple alguna expreison del arbol de analisis lexico

         */
        private void reportarToken(Token_lenguaje.TOKEN tipo, Object Lexema, int fila, int columna)
        {
            ListaErroresLexicos.AddLast(new Token_lenguaje(tipo, Lexema, fila, columna));// se agrega el token a mi lista 
            lexema = "";//limpiamos el lexema
            estado = 0; // el estado regresa al estado inicial
        }


        /*
          @Lista de tokens aceptados
          retorna los tokens acpetados en el analisis
         */
        public LinkedList<Token_lenguaje> returnListaTokens()
        {
            return ListaParser;
        }

        /*
          @Lista de errores Lexicos
          retorna los tokens no acpetados en el analisis
         */
        public LinkedList<Token_lenguaje> returnListaErroresLexicos()
        {
            return ListaErroresLexicos;
        }



    }
}
