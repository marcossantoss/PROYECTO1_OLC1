using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201700328.Analsis_thompson
{
    public class Tablas_de_informacion
    {

        public String id;
        public Nodo raiz_thompson;
        public Nodo raiz_arbol_expresion;
        public LinkedList<String> expresionEstructurdaenLista;
        public LinkedList<Transicion> transiciones;

        public Tablas_de_informacion(string id, Nodo raiz_thompson, Nodo raiz_arbol_expresion, LinkedList<string> expresionEstructurdaenLista, LinkedList<Transicion> transiciones)
        {
            this.id = id;
            this.raiz_thompson = raiz_thompson;
            this.raiz_arbol_expresion = raiz_arbol_expresion;
            this.expresionEstructurdaenLista = expresionEstructurdaenLista;
            this.transiciones = transiciones;
        }


    }
}
