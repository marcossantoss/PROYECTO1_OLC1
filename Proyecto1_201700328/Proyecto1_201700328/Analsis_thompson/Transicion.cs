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


        public Transicion(String estado, String conjunto)
        {
            this.estado = estado;
            this.conjunto = conjunto;
            this.estados_siguientes = new LinkedList<String>();
        }
    }
}
