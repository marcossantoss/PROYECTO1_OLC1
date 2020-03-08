using Proyecto1_201700328.Analizadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201700328.Analsis_thompson
{


    public class Analisis_lexemas
    {

        LinkedList<Expresion_Lexema> lista_macros;
        LinkedList<Expresion_Lexema> lista_lexemas;
        LinkedList<Transicion> lista_expresiones;

        public Analisis_lexemas(LinkedList<Expresion_Lexema> lista_macros, LinkedList<Expresion_Lexema> lista_lexemas, LinkedList<Transicion> lista_expresiones)
        {
            this.lista_macros = lista_macros;
            this.lista_lexemas = lista_lexemas;
            this.lista_expresiones = lista_expresiones;
        }

        //aqui iniciamos con el analsis de las cadenas y ejecucion de reportes xml
    }
}
