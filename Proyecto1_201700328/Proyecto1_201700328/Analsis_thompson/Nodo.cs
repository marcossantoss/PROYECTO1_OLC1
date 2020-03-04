using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201700328.Analsis_thompson
{
    public class Nodo
    {
    
        public String valor;
        public String transicion;
        public LinkedList<Nodo> hijos;


        public Nodo(String valor)
        {
           
            this.valor = valor;
            this.transicion = "";
            this.hijos = new LinkedList<Nodo>();
        }

        public void agregarHijo(Nodo hijo)
        {
            this.hijos.AddLast(hijo);
        }

    }
}
