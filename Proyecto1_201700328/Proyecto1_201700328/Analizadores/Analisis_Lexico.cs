using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public Boolean AnalisisCorrecto = true;


        //Iniciamos constructor
        public Analisis_Lexico(String contenido_areaTexto) {

            this.contenido_areaTexto = contenido_areaTexto;

        }

        public void scanner()
        {

            MessageBox.Show("Scaneando");
            estado = 0;
            lexema = "";
            int cuenta_llave_apertura = 0;
            int fila = 1;
            int columna = 1;

            int auxcaracter = 0;//me va a servir en los casos donde se tenga que tener un caracter anticipado a su analisis



            char[] cadenaCaracteres = contenido_areaTexto.ToCharArray();

            foreach (char charActual in cadenaCaracteres)
            {

                //solo se verifica el salto de linea y sigue con el curso del analisis
                if (charActual == '\n')
                {
                    fila++;
                    columna = 0;
                }

                //aqui inician los casos de reconocimiento de las expresiones regulares
                switch (estado)
                {

                    case 0:

                        if (charActual == 'C')
                        {
                            lexema += charActual;
                            estado = 9;

                        }
                        else if (charActual == '/')
                        {// inicio de comentario simplre
                            lexema += charActual;
                            estado = 1;

                        }
                        else if (charActual == '<')
                        {//inicio de comentario multi
                            lexema += charActual;
                            estado = 3;

                        }
                        else if (charActual == '{' && cuenta_llave_apertura == 0)
                        { //llave de apertura
                            lexema += charActual;
                            cuenta_llave_apertura++;

                            aceptarToken(Token_lenguaje.TOKEN.LLAVE_A, lexema, fila, columna);
                        }
                        else if (charActual == '}')
                        { //llave de cierre
                            lexema += charActual;
                            aceptarToken(Token_lenguaje.TOKEN.LLAVE_C, lexema, fila, columna);
                        }
                        else if (charActual == '"')
                        { //llave de cierre
                            lexema += charActual;
                            estado = 5;
                        }
                        else if (charActual == '-')
                        {
                            lexema += charActual;
                            estado = 6;
                        }
                        else if (charActual == '%')
                        {

                            lexema += charActual;
                            estado = 12;

                        }
                        else if (charActual == ':')
                        {
                            lexema += charActual;
                            aceptarToken(Token_lenguaje.TOKEN.DOSPUNTOS, lexema, fila, columna);

                        }
                        else if (charActual >= 65 && charActual <= 90 || charActual >= 97 && charActual <= 122)
                        {//una letra


                            lexema += charActual;
                            estado = 8;
                        }
                        else if (charActual == '\n' || charActual == '\t' || charActual == ' ')
                        {//soporte de espacio , tabulaciones , salto de linea

                            //no se hace nada se ignoran
                        }
                        else
                        {
                            //de venir otra vez no se toma en cuenta
                            if (charActual == '{')
                            {
                                //no importa soportamos el error;
                            }
                            else
                            {
                                lexema += charActual;
                                reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                                AnalisisCorrecto = false;
                            }
                        }
                        break;
                    //------------------------------------------------------------------------------------------------------
                    case 1://se espera la siguiene // para comenzar el comentario multilinea

                        if (charActual == '/')
                        {
                            lexema += charActual;
                            estado = 2;

                        }
                        else
                        {
                            lexema += charActual;
                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                            AnalisisCorrecto = false;
                        }
                        break;
                    //------------------------------------------------------------------------------------------------------
                    case 2:// se acepta el comentario simple hasta encontrar un salto de linea

                        if (charActual == '\n')
                        {
                            //ya no se concatena el simbolo solo se acepta lo anterior a estos caracteres
                            // aceptarToken(token_del_lenguaje.TOKEN.COMENSIMPLE, lexema, fila, columna);
                            estado = 0;
                            lexema = "";
                        }
                        else
                        {
                            lexema += charActual;
                        }

                        break;
                    //------------------------------------------------------------------------------------------------------
                    case 3://se espera la apertura correcta de <!

                        if (charActual == '!')
                        {
                            lexema += charActual;
                            estado = 4;
                        }
                        else
                        {
                            lexema += charActual;
                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                            AnalisisCorrecto = false;
                        }
                        break;

                    //-------------------------------------------------------------------------------------------------------
                    case 4://se concatena todo hasta que se encuentre el !> para el cierre anticipado de comentario multilinea
                        if (lexema.StartsWith("<!") && lexema.EndsWith("!>"))
                        {
                            estado = 0;
                            lexema = "";

                        }
                        else
                        {
                            lexema += charActual;
                        }
                        break;
                    //---------------------------------------------------------------------------------------------------------
                    case 5://concatena la cadena

                        if (charActual == '"')
                        {
                            lexema += charActual;
                            aceptarToken(Token_lenguaje.TOKEN.CADENA, lexema, fila, columna);
                        }
                        else
                        {
                            lexema += charActual;
                        }
                        break;
                    //----------------------------------------------------------------------------------------------------
                    case 6://aceptacion del la flecha y calisificacion de macros

                        if (charActual == '>')
                        {
                            lexema += charActual;
                            aceptarToken(Token_lenguaje.TOKEN.FLECHA, lexema, fila, columna);
                            estado = 7;
                        }
                        else
                        {
                            lexema += charActual;
                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                            AnalisisCorrecto = false;
                        }
                        break;
                    case 7://caso para saber si es una expresion regular , una macro de rango o un conjunto finito

                        if (charActual == ';' || charActual == '\n')
                        {//de encontrar el punto y coma

                            if (lexema.Length == 3)
                            {//se trata de un rango 

                                String cadena_aux = "";

                                for (int i = 0; i < lexema.Length; i++)
                                {

                                    if (lexema[i] >= 32 && lexema[i] <= 125)
                                    {
                                        cadena_aux += lexema[i];
                                    }
                                    else if (lexema[i] == '~')
                                    {
                                        cadena_aux += lexema[i];
                                    }
                                    else
                                    {
                                        reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                                        AnalisisCorrecto = false;
                                    }

                                }

                                if (AnalisisCorrecto)
                                {
                                    aceptarToken(Token_lenguaje.TOKEN.MACROS, cadena_aux, fila, columna);
                                }
                            }
                            else
                            {// se trata de un conjunto especifico

                                if (lexema.ElementAt(1).Equals(","))
                                {//es un conjunto
                                    String cadena_aux = "";
                                    for (int i = 0; i < lexema.Length; i++)
                                    {
                                        if (lexema[i] >= 32 && lexema[i] >= 43 && lexema[i] >= 45 && lexema[i] <= 125)
                                        {
                                            cadena_aux += lexema[i];
                                        }
                                        else if (lexema[i] == ',')
                                        {
                                            cadena_aux += lexema[i];
                                        }
                                        else
                                        {
                                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                                            AnalisisCorrecto = false;
                                        }
                                    }

                                    if (AnalisisCorrecto)
                                    {
                                        aceptarToken(Token_lenguaje.TOKEN.CONJUNTOFINITIO, cadena_aux, fila, columna);
                                    }

                                }
                                else
                                { // es una expresion

                                    String cadena_aux = "";

                                    for (int i = 0; i < lexema.Length; i++)
                                    {

                                        if (lexema[i] >= 32 && lexema[i] <= 125 || lexema[i] == '|')
                                        {
                                            cadena_aux += lexema[i];
                                        }
                                        else
                                        {
                                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                                            AnalisisCorrecto = false;
                                        }

                                    }

                                    if (AnalisisCorrecto)
                                    {
                                        aceptarToken(Token_lenguaje.TOKEN.EXPRESION, lexema, fila, columna);
                                    }

                                }

                            }
                            //finalmente se concatena el punto y coma 
                            if (charActual == ';')
                            {
                                aceptarToken(Token_lenguaje.TOKEN.PTOCOMA, charActual, fila, columna);
                            }

                        }
                        else if (charActual == '\n' || charActual == '\t' || charActual == ' ')
                        {//soporte de espacio , tabulaciones , salto de linea

                            //no se hace nada se ignoran
                        }
                        else
                        {
                            lexema += charActual;
                        }

                        break;
                    case 8:
                        if (contenido_areaTexto[auxcaracter + 1].Equals("-") || contenido_areaTexto[auxcaracter + 1].Equals(" ") || contenido_areaTexto[auxcaracter + 1].Equals(":"))
                        {
                            lexema += charActual;
                            aceptarToken(Token_lenguaje.TOKEN.ID, lexema, fila, columna);
                        }
                        else if (charActual >= 65 && charActual <= 90 || charActual >= 97 && charActual <= 122)
                        {//una letra
                            lexema += charActual;
                            estado = 8;
                        }
                        else if (charActual >= 48 && charActual <= 57)
                        {//un numero
                            lexema += charActual;
                            estado = 8;

                        }
                        else if (charActual == '_')
                        {
                            lexema += charActual;
                            estado = 8;
                        }
                        else
                        {

                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                            AnalisisCorrecto = false;

                        }

                        break;

                    case 9:
                        if (charActual == 'O')
                        {
                            lexema += charActual;
                            estado = 10;

                        }
                        else
                        {
                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                            AnalisisCorrecto = false;

                        }
                        break;

                    case 10:

                        if (charActual == 'N')
                        {
                            lexema += charActual;
                            estado = 11;

                        }
                        else
                        {
                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                            AnalisisCorrecto = false;

                        }
                        break;
                    case 11:

                        if (charActual == 'J')
                        {
                            lexema += charActual;
                            aceptarToken(Token_lenguaje.TOKEN.CONJ, lexema, fila, columna);

                        }
                        else
                        {
                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                            AnalisisCorrecto = false;

                        }
                        break;

                    case 12:
                        if (charActual == '%')
                        {
                            lexema += charActual;
                            aceptarToken(Token_lenguaje.TOKEN.PORCENTAJES, lexema, fila, columna);

                        }
                        else
                        {

                            reportarToken(Token_lenguaje.TOKEN.ERROR, lexema, fila, columna);
                            AnalisisCorrecto = false;

                        }
                        break;
               


                }
                columna++;//aumenta la columna cada vez que lee el siguiente caracter
                auxcaracter++;
            } 
            Console.Write("Analisis concluido");
        
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
