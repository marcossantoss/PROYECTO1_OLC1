using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201700328.Analizadores
{
   public class Expresion_Lexema
    {
        //almacena id y la expresion pero en forma de cadena
        private String Identiicador;
        private String Contenido;
        public int fila;
        public int columna;
        public String estado;

        public Expresion_Lexema(String Identiicador, String Contenido,int fila,int columna)
        {
            this.Identiicador = Identiicador;
            this.Contenido = Contenido;
            this.fila = fila;
            this.columna = columna;
            this.estado = "";
        }

        /**
         * @return the Identiicador
         */
        public String getIdentiicador()
        {
            return Identiicador;
        }

        /**
         * @param Identiicador the Identiicador to set
         */
        public void setIdentiicador(String Identiicador)
        {
            this.Identiicador = Identiicador;
        }

        /**
         * @return the Contenido
         */
        public String getContenido()
        {
            return Contenido;
        }

        /**
         * @param Contenido the Contenido to set
         */
        public void setContenido(String Contenido)
        {
            this.Contenido = Contenido;
        }

    }
}
