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
        LinkedList<String> pila = new LinkedList<String>();
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

        public String recorrer_AFND(Nodo nodo)
        {
            String concatena = "";
                        
                String padre = nodo.valor;
           

                concatena += nodo.valor + "\n";
             
           
                foreach (Nodo hijo in nodo.hijos)
                {
             
                    if (!hijo.aplicaRetorno)
                    {

                    if (!pila.Contains(nodo.valor + "->" + hijo.valor))
                    {
                        concatena += nodo.valor + "->" + hijo.valor;
                        concatena += "[label= \"" + nodo.transicion + "\"]\n";

                        concatena += recorrer_AFND(hijo);

                        pila.AddLast(nodo.valor + "->" + hijo.valor);

                    }

                    }
                    else
                    {
                    if (!pila.Contains(nodo.valor + "->" + hijo.valor))
                    {

                        concatena += nodo.valor + "->" + hijo.valor;
                        concatena += "[label= \"" + nodo.transicion + "\"]\n";
                        pila.AddLast(nodo.valor + "->" + hijo.valor);
                        concatena += hijo.valor + "->" + nodo.valor;
                        concatena += "[label= \"" + "ε" + "\"]\n";
                        pila.AddLast(hijo.valor + "->" + nodo.valor);
                        concatena += recorrer_AFND(hijo);
                    }
                        
                    }
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
    

