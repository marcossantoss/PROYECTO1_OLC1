using Proyecto1_201700328.Analsis_thompson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201700328.Graficadora
{
    public class Graficadora
    {

        public Graficadora()
        {

        }

        public int pos = 0;
        public String recorrer_arbolito(Nodo nodo)
        {

            pos = pos + 1;
            String padre = "nodo" + pos;
            String concatena = "";

            //  concatena+= padre + "[label=\""+pos+") valor: "+nodo.valor+"\"];\n";
            concatena += padre + "[ shape=Mrecord,style=filled, fillcolor=slategray4 , color=lightblue4 , label=<<TABLE border=\"0\" cellborder=\"0\" bgcolor=\"lightskyblue4\">\n";
            concatena +=
                     "<TR>\n"

                    + "<td border=\"1\" >" + nodo.valor + " </td>\n"

                    + " </TR>\n"

                    + "</TABLE>>]";
            foreach (Nodo hijo in nodo.hijos)
            {

                concatena += padre + "->" + "nodo" + (1 + pos) + ";\n";
                concatena += recorrer_arbolito(hijo);
            }

            return concatena;

        }

        public void escribir_fichero_grafo(String info, String nombre)
        {

            string path = nombre + ".txt";
            String texto = "";



            texto += "digraph grafo{\n";

            texto += info + "\n";

            texto += "}";

            File.WriteAllLines(path, new String[] { texto });

        }

   



        public void generar_Dot_grafo(String nombre)
        {
            try
            {
                var command = string.Format("dot -Tsvg {0} -o {1}", Path.Combine("", nombre + ".txt"), Path.Combine("", nombre + ".svg"));

                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + command);

                var proc = new System.Diagnostics.Process();

                proc.StartInfo = procStartInfo;

                proc.Start();

                proc.WaitForExit();

            }
            catch (Exception x)
            {

            }
        }

    }

}
    

