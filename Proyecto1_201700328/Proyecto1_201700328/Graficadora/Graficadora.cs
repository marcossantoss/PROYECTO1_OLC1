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
       public LinkedList<String> pila = new LinkedList<String>();
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

            if (padre != null)
            {

                concatena += nodo.valor + "\n";

          //      MessageBox.Show("EL nodo es: "+padre+" y "+ "aplicaretorno "+nodo.aplicaRetorno);

                foreach (Nodo hijo in nodo.hijos)
                {

                    if (!nodo.aplicaRetorno)
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
                        //    MessageBox.Show("aplicando retorno en grafico"+ "nodo valor:"+nodo.valor);
                            concatena += nodo.valor + "->" + hijo.valor;
                            concatena += "[label= \"" + nodo.transicion + "\"]\n";
                            pila.AddLast(nodo.valor + "->" + hijo.valor);
                            concatena += nodo.valor +"->" + Convert.ToString(Convert.ToInt64(nodo.valor) - 1);
                            concatena += "[label= \"" + "ε" + "\"]\n";
                            pila.AddLast(hijo.valor + "->" + nodo.valor);
                            concatena += recorrer_AFND(hijo);
                        }

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

   



        public void generar_Dot_grafo_svg(String nombre, String guardadoimagen)
        {
            try
            {
                var command = string.Format("dot -Tsvg {0} -o {1}", Path.Combine("", nombre + ".txt"), Path.Combine("", guardadoimagen+ ".svg"));

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


        public void generar_Dot_grafo_png(String nombre, String guardadoimagen)
        {
            try
            {
                var command = string.Format("dot -Tjpg {0} -o {1}", Path.Combine("", nombre + ".txt"), Path.Combine("", guardadoimagen + ".jpg"));

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

        public String hacer_table_transiciones(LinkedList<Transicion> transiciones)
        {

            String info = "";

            info += "node [shape=box];\n";

            info += "tabla[shape=box, style=filled, fillcolor=white, color=blue, label=<<TABLE border=\"0\" cellborder=\"1\">\n";

            info += "<TR>";
            info += "<TD>Simbolo</TD>";
            info += "<TD>Transiciones</TD>";
            info += "<TD>Aceptacion</TD>";

            info += "</TR>\n";


            foreach (Transicion transicion in transiciones)
            {

                info += "<TR>\n";

                info += "<TD>" + transicion.estado + "</TD>\n";

                info += "<TD>";

                if (!(transicion.estados_siguientes.Count==0))
                {
                    foreach (String trans in transicion.estados_siguientes)
                    {


                        if (!transicion.estados_siguientes.Last().Equals(trans))
                        {
                            info += "   " + trans.Replace("¬", " - ") + "   ,   ";
                        }
                        else
                        {
                            info += "   " + trans.Replace("¬", " - ");
                        }
                    }

                    /*      if (transicion.estado.Equals(transiciones.Last().estado)) {

                              for (int a=0;a<transicion.estados_siguientes.Count;a++) 
                              {

                             //     transicion.estados_siguientes.el = "";
                             //     trans = "-";
                                  info += "- ";
                              }

                          }
                          else {

                              foreach (String trans in transicion.estados_siguientes)
                              {


                                  if (!transicion.estados_siguientes.Last().Equals(trans))
                                  {
                                      info += "   " + trans.Replace("¬", " - ") + "   ,   ";
                                  }
                                  else
                                  {
                                      info += "   " + trans.Replace("¬", " - ");
                                  }
                              }

                          }*/



                }
                else
                {
                    info += "estado final de aceptacion";
                }

                info += "</TD>";

                info += "<TD>" + transicion.esAceptacion.ToString() + "</TD>\n";
                info += "</TR>\n";

            }


            info += "</TABLE>>]\n" +
            "\n";
            return info;
        }


        public String hacer_automata(LinkedList<Transicion> transiciones)
        {

            String info = "";
            info += "rankdir=LR;\n";
            info += "size=\"8,5\"";

            info += "\n";

            info += "node [shape = doublecircle]; ";
            //vamos a buscar los estados que contengan en sus conjuntos al simbolo de aceptacion
            foreach (Transicion transicion in transiciones)
            {

                //verifica que los estados sean de aceptacion
                if (transicion.esAceptacion)
                {
                    info += transicion.estado + " ";
                }
            }

            info += "\n node [shape = circle];\n";

            //ahora hacemos enlaces
            foreach (Transicion transicion in transiciones)
            {



                if (transicion.estados_siguientes.Count==0)
                {
                    //no hace nada solamente declara el nodo otra vez              
                    info += "\n";
                }
                else
                {

                    foreach (String trans in transicion.estados_siguientes)
                    {
                        info += transicion.estado;
                        String[] datos = trans.Split('¬');
                        //hace el enlace con cada estado
                        info += "->" + datos[0] + "[label=\"" + datos[1] + "\"];\n";

                    }


                }

            }




            return info;
        }



    }

}
    

