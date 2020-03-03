using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201700328.Analizadores
{
   public class Token_lenguaje
    {

        private TOKEN tipo;
        private Object Lexema;
        private int fila;
        private int columna;

        public Token_lenguaje(TOKEN tipo, Object Lexema, int fila, int columna)
        {
            this.tipo = tipo;
            this.Lexema = Lexema;
            this.fila = fila;
            this.columna = columna;
        }

        public enum TOKEN
        {
            /*SIMBOLOS SIMPLES*/

            LLAVE_A,//{
            LLAVE_C,//}
            COMILLA_DOBLE,//"
            SIMBOLO_OR,//|
            SIMBOLO_AND,//.
            SIMBOLO_0_1vez,//?
            SIMBOLO_0_MAS,//*
            SIMBOLO_1_MAS,//+
            SIMBOLO_RANGO,//~
            PTOCOMA,//;
            DOSPUNTOS,//:
            ASCIII,//CUALQUIER SIMBOLO ASCII COMPRENDIDO DEL 32-47 , 58-64 , 91-96 , 123-125
            COMA,// ,
            CARACTERESPECIAL,// \n \'  \"  \t  
            CARACTERTODO,// [:todo:]


            /*SIMBOLOS COMPUESTOS*/

            FLECHA,//->
            ID,//L(L|N|_)*
            DIGITO,//D+(. D+)?
            COMENAMUL, //<!
            COMENCMUL, //!>
            COMENSIMPLE,// //
            PORCENTAJES, // %%%%
            CADENA, // HOLA , MUNDO , ETC...
            MACROS, // A~z etc
            EXPRESION,//expresion regular
            CONJUNTOFINITIO,


            /*SIMBOLOS RESERVADOS O PALABRAS RESERVADAS DEL LENGUAJE*/
            CONJ,//CONJ


            /*Error*/
            ERROR,

            /*simbolo de aceptacion*/
            ACEPTACION
        }

        /**
    * @return the tipo
    */
        public TOKEN getTipo()
        {
            return tipo;
        }

        /**
         * @return the Lexema
         */
        public Object getLexema()
        {
            return Lexema;
        }

        /**
         * @return the fila
         */
        public int getFila()
        {
            return fila;
        }

        /**
         * @return the columna
         */
        public int getColumna()
        {
            return columna;
        }

        /*GET QUE PERMITE SABER QUE ES CADA SIMBOLO MEDIANTE STRINGS*/

        public String tipo_detallado(TOKEN tipo)
        {

            switch (tipo)
            {

                case TOKEN.LLAVE_A:
                    return "Llave de apertura";
                    break;
                case TOKEN.LLAVE_C:
                    return "Llave de cierre";
                case TOKEN.COMILLA_DOBLE:
                    return "Comilla doble";
                case TOKEN.SIMBOLO_OR:
                    return "Simbolo OR |";
                case TOKEN.SIMBOLO_0_1vez:
                    return "Simbolo cerradura ?";
                case TOKEN.SIMBOLO_0_MAS:
                    return "Simbolo cerradura *";
                case TOKEN.SIMBOLO_1_MAS:
                    return "Simbolo cerradura +";
                case TOKEN.SIMBOLO_RANGO:
                    return "Simbolo de rango de una macro ~";
                case TOKEN.PTOCOMA:
                    return "Punto y coma";
                case TOKEN.DOSPUNTOS:
                    return "Dos puntos";
                case TOKEN.SIMBOLO_AND:
                    return "Simbolo AND .";
                case TOKEN.PORCENTAJES:
                    return "Simbolos de porcentaje doble";
                case TOKEN.FLECHA:
                    return "Simbolo de asignacion de expresion regular";
                case TOKEN.COMENAMUL:
                    return "Comentario multilinea apertura";
                case TOKEN.COMENSIMPLE:
                    return "Comentario simple";
                case TOKEN.CONJ:
                    return "Palabra reservada CONJ";
                case TOKEN.ASCIII:
                    return "Simbolos ASCCI comprendidos del 32-47, 58-64, 91-96, 123-125";
                case TOKEN.COMENCMUL:
                    return "Comentario multulinea cierre";
                case TOKEN.ID:
                    return "Identificador";
                case TOKEN.DIGITO:
                    return "Digito";
                case TOKEN.CADENA:
                    return "Cadena";
                case TOKEN.EXPRESION:
                    return "expresion regular";
                case TOKEN.MACROS:
                    return "Macro de rangos de caracteres ASCII 32 al 125";
                case TOKEN.ERROR:
                    return "Error Lexico, simbolo no admitido";
                case TOKEN.COMA:
                    return "Coma ,";
                case TOKEN.CONJUNTOFINITIO:
                    return "Conjunto finito de caracteres ASCCI 32 al 125";
                case TOKEN.ACEPTACION:
                    return "Simbolo de fin del archivo";
                case TOKEN.CARACTERESPECIAL:
                    return "Caracter Especial";
                case TOKEN.CARACTERTODO:
                    return "Todos los caracteres especiales menor el salto de linea";
                default:
                    return "error!";
            }
        }

    }
}
