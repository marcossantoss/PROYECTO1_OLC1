using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201700328.Analsis_thompson
{
   public class Transicion
    {
        public String estado;
        public String conjunto;
        public LinkedList<String> estados_siguientes;
        public Boolean esAceptacion;


        public Transicion(String estado, String conjunto,bool esAceptacion)
        {
            this.estado = estado;
            this.conjunto = conjunto;
            this.estados_siguientes = new LinkedList<String>();
            this.esAceptacion = esAceptacion;
        }

        public LinkedList<String> getEstadosSiguientes()
        {
            return this.estados_siguientes;

        }
    }
}
