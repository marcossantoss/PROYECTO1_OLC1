using Proyecto1_201700328.Analizadores;
using Proyecto1_201700328.Graficadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201700328.Analsis_thompson
{
    public class metodo_de_thompson
    {

        //hacer metodo de thompson

        LinkedList<Expresion_Lexema> lista_macros;
        LinkedList<Expresion_Lexema> lista_lexemas;
        LinkedList<Expresion_Lexema> lista_expresiones;

        LinkedList<String> pila = new LinkedList<String>();

        LinkedList<Tablas_de_informacion> Informacion_de_cadaID = new LinkedList<Tablas_de_informacion>();

    

        public metodo_de_thompson(LinkedList<Expresion_Lexema> lista_macros, LinkedList<Expresion_Lexema> lista_lexemas, LinkedList<Expresion_Lexema> lista_expresiones)
        {
            this.lista_macros = lista_macros;
            this.lista_lexemas = lista_lexemas;
            this.lista_expresiones = lista_expresiones;
        }

        public void procesar_expresiones()
        {

            foreach (Expresion_Lexema expresion in lista_expresiones)
            {
                //por cada expresion 
                //lo almacenamos en una lista de expresiones estructuradas
                LinkedList<String> expresion_estructurada = new LinkedList<String>();
                String exp = expresion.getContenido();
                char[] caracteres_expresion = exp.ToCharArray();
                String cadena_nueva = "";
                int cont_verificador = 0;
                int cont_verifiador2 = 0;
                int cont_verificador3 = 0;


                int contAux = 0;

                foreach (char caracter in caracteres_expresion)
                {

                    if (contAux < exp.Length)
                    {
                        if (caracter == '[' && exp[contAux + 1] == ':')
                        {


                            cadena_nueva += caracter;
                            cont_verifiador2 = 1;

                        }
                        else if (caracter == ']' && cont_verifiador2 == 1)
                        {

                            cadena_nueva += caracter;

                            expresion_estructurada.AddLast("TODO");
                            cadena_nueva = "";
                            cont_verifiador2 = 0;

                        }
                        else if (caracter == '\\' && (exp[contAux + 1] == '\'' || exp[contAux + 1] == 'n' || exp[contAux + 1] == '"' || exp[contAux + 1] == 't'))
                        {
                            cadena_nueva += caracter;
                            cont_verificador3 = 1;

                        }
                        else if (caracter == '\'' && cont_verificador3 == 1)
                        {
                            expresion_estructurada.AddLast("comillasimple");
                            cont_verificador3 = 0;
                            cadena_nueva = "";
                        }
                        else if (caracter == 'n' && cont_verificador3 == 1)
                        {
                            expresion_estructurada.AddLast("saltolinea");
                            cont_verificador3 = 0;
                            cadena_nueva = "";
                        }
                        else if (caracter == '"' && cont_verificador3 == 1)
                        {
                            expresion_estructurada.AddLast("comilladoble");
                            cont_verificador3 = 0;
                            cadena_nueva = "";
                        }
                        else if (caracter == 't' && cont_verificador3 == 1)
                        {
                            expresion_estructurada.AddLast("tabulacion");
                            cont_verificador3 = 0;
                            cadena_nueva = "";

                        }

                        else if (caracter == 'ε')
                        {
                            expresion_estructurada.AddLast(caracter.ToString());
                            cadena_nueva = "";

                        }
                        else if (caracter == '"' && cont_verificador == 0)
                        {
                            cadena_nueva += caracter;
                            cont_verificador = 1;

                        }
                        else if (caracter == '"' && cont_verificador == 1)
                        {
                            cadena_nueva += caracter;
                            expresion_estructurada.AddLast(cadena_nueva.Replace("\"", "´"));
                            cadena_nueva = "";
                            cont_verificador = 0;

                        }
                        else if (caracter == '{' && exp[contAux + 1] != '}')
                        {
                            cont_verificador = 1;

                        }
                        else if (caracter == '}' && cont_verificador == 1)
                        {

                            expresion_estructurada.AddLast(cadena_nueva);
                            cadena_nueva = "";
                            cont_verificador = 0;

                        }
                        else if (cont_verificador == 1)
                        {
                            cadena_nueva += caracter;

                        }
                        else if (cont_verifiador2 == 1)
                        {
                            cadena_nueva += caracter;
                        }
                        else
                        {
                            switch (caracter)
                            {

                                case '.':
                                    cadena_nueva += caracter;
                                    expresion_estructurada.AddLast(cadena_nueva);
                                    cadena_nueva = "";

                                    break;
                                case '|':
                                    cadena_nueva += caracter;
                                    expresion_estructurada.AddLast(cadena_nueva.Replace(" ", ""));
                                    cadena_nueva = "";
                                    break;
                                case '*':
                                    cadena_nueva += caracter;
                                    expresion_estructurada.AddLast(cadena_nueva);
                                    cadena_nueva = "";
                                    break;
                                case '+':
                                    cadena_nueva += caracter;
                                    expresion_estructurada.AddLast(cadena_nueva);
                                    cadena_nueva = "";
                                    break;
                                case '?':
                                    cadena_nueva += caracter;
                                    expresion_estructurada.AddLast(cadena_nueva);
                                    cadena_nueva = "";
                                    break;

                            }
                        }

                        //_------------------------------------
                        contAux++;//auxiliar de preanalisis de caracter 
                    }
                }
                Console.WriteLine("\n\nantes_ " + expresion.getIdentiicador());
                foreach (String f in expresion_estructurada)
                {

                    Console.WriteLine(f + " ");
                }


                Informacion_de_cadaID.AddLast(new Tablas_de_informacion(expresion.getIdentiicador(), null, null, expresion_estructurada, null));

            }

        }

        Graficadora.Graficadora grafica = new Graficadora.Graficadora();

        int i = 0;
        String arbol_dot = "";
        int estado = 0;

        public void thompson()
        {
            //por cada expresion se grafica un arbol
            foreach (Tablas_de_informacion expression in Informacion_de_cadaID)
            {

                //si solo viene un dato 
                if (expression.expresionEstructurdaenLista.Count == 1)
                {
                    Nodo padre = new Nodo(expression.expresionEstructurdaenLista.ElementAt(i));
                    Nodo hijo1 = new Nodo(expression.expresionEstructurdaenLista.ElementAt(i));
                    Nodo hijo2 = new Nodo("#");
                    padre.agregarHijo(hijo1);
                    padre.agregarHijo(hijo2);
                    formarArbol(padre, expression.expresionEstructurdaenLista);

               
                    generarAFND(hijo1);
                    //analisis de transiciones
                    /*    LinkedList<Transicion> nueva_t_transiciones = new LinkedList<>();
                        System.out.println("inicio----");
                        Tabla_transiciones(padre, nueva_t_transiciones, nueva_tabla);
                        System.out.println("fin----\n\n");
                        */


                    grafica.escribir_fichero_grafo(arbol_dot, expression.id);


                    //se procede a graficar
                    grafica.escribir_fichero_grafo(grafica.recorrer_arbolito(padre) + "\n label=\"" + expression.id + "\";\n", expression.id);
                    grafica.generar_Dot_grafo(expression.id);


                }
                else
                {// si vienen mas 
                 //  MessageBox.Show("estoy aqui");
                    Nodo padre = new Nodo(".");
                    Nodo hijo1 = new Nodo(expression.expresionEstructurdaenLista.ElementAt(i));
                    Nodo hijo2 = new Nodo("#");
                    padre.agregarHijo(hijo1);
                    padre.agregarHijo(hijo2);
                    formarArbol(hijo1, expression.expresionEstructurdaenLista);


                    //analisis de transiciones
                    /*      LinkedList<Transicion> nueva_t_transiciones = new LinkedList<>();
                          System.out.println("inicio----");
                          Tabla_transiciones(padre, nueva_t_transiciones, nueva_tabla);
                          System.out.println("fin----\n\n");




                          graficar.escribir_fichero_tabla_transiciones(graficar.hacer_table_transiciones(nueva_t_transiciones) + "\n label=\"" + expression.getIdentificador() + "\";\n", "", expression.getIdentificador() + "TT");
                          graficar.generar_Dot_tabla_transiciones(expression.getIdentificador() + "TT");
                          rutas_transiciones.add("C:\\transiciones\\" + expression.getIdentificador() + "TT.jpg");
                          Tabla_transiciones.add(new Tabla_transiciones(expression.getIdentificador(), nueva_t_transiciones));
                          */


                    //se procede a graficar
                   
                    arbol_dot += "rankdir=LR; size = \"8,5\"\n";
                    arbol_dot += "node [shape = circle];\n";

                    generarAFND(hijo1);
              
                    // arbol_dot += " node[shape = doublecircle];" +estado.ToString();

                    grafica.escribir_fichero_grafo(arbol_dot, expression.id + "_AFND");
                    grafica.generar_Dot_grafo(expression.id + "_AFND");

                    /*para ver el recorrido del arbol*/
                    grafica.escribir_fichero_grafo("rankdir = LR; size = \"8,5\" \n"+ "node [shape = circle];\n" + grafica.recorrer_AFND(inicio_devuelta), expression.id + "_AFNDrecorrido");
                    grafica.generar_Dot_grafo(expression.id + "_AFNDrecorrido");

                    
                  

                    /*reccorido pulido*/
                    grafica.escribir_fichero_grafo("rankdir = LR; size = \"8,5\" \n" + "node [shape = circle];\n" +recorrer_AFND(inicio_devuelta), expression.id + "_AFNDpulido");
                    grafica.generar_Dot_grafo(expression.id + "_AFNDpulido");

                    grafica.escribir_fichero_grafo(grafica.recorrer_arbolito(padre) + "\n label=\"" + expression.id + "\";\n", expression.id);
                    grafica.generar_Dot_grafo(expression.id);

                }

                //limpiamos nuestros operadores
                i = 0;
                arbol_dot = "";
                
                estado = 0;
                pila.Clear();
            }

        }

        /*
          @formarArbol

          este metodo permite formar un arbol de lo que se obtiene de la cadena
          de la expresion regular

           */
        public void formarArbol(Nodo padre, LinkedList<String> elemento)
        {

            if (i < elemento.Count)
            {

                if (elemento.ElementAt(i).Equals(".") || elemento.ElementAt(i).Equals("|"))
                {

                    i++;
                    String simbolo = elemento.ElementAt(i).Replace("|", "(or)");
                    simbolo = simbolo.Replace("<", "menorque");
                    simbolo = simbolo.Replace(">", "mayorque");
                    Nodo hijo1 = new Nodo(elemento.ElementAt(i).Replace("|", "(or)"));
                    padre.agregarHijo(hijo1);
                    formarArbol(hijo1, elemento);
                    i++;
                    simbolo = elemento.ElementAt(i).Replace("|", "(or)");
                    simbolo = simbolo.Replace("<", "menorque");
                    simbolo = simbolo.Replace(">", "mayorque");
                    Nodo hijo2 = new Nodo(simbolo);
                    padre.agregarHijo(hijo2);
                    formarArbol(hijo2, elemento);

                }
                else if (elemento.ElementAt(i).Equals("*") || elemento.ElementAt(i).Equals("?") || elemento.ElementAt(i).Equals("+"))
                {

                    i++;
                    String simbolo = elemento.ElementAt(i).Replace("|", "(or)");
                    simbolo = simbolo.Replace("<", "menorque");
                    simbolo = simbolo.Replace(">", "mayorque");

                    Nodo hijo1 = new Nodo(simbolo);

                    padre.agregarHijo(hijo1);

                    formarArbol(hijo1, elemento);

                }
                else
                {

                    //  Nodo hijo1 = new Nodo("", elemento.get(i).replace("|", "(or)"), "", "", "");
                    // padre.agregarHijo(hijo1);
                    return;
                }

            }
            else
            {
                return;
            }

        }
        int hijoizquierdo = 0;
        int hijoderecho = 1;


        Nodo izquierda_inicio_and = null;
        Nodo izquierda_fin_and = null;

        Nodo derecha_inicio_and = null;
        Nodo derecha_fin_and = null;

        Nodo izquierda_inicio = null;
        Nodo izquierda_fin = null;

        Nodo derecha_inicio = null;
        Nodo derecha_fin = null;

        Nodo inicio_devuelta = null;
        Nodo fin_devuelta = null;


       // Nodo[] datoIzquierdo = null;
       // Nodo[] datoDerecho = null;

        public void generarAFND(Nodo raiz) {


            if (raiz.valor.Equals("."))
            {


                generarAFND(raiz.hijos.ElementAt(hijoizquierdo));
                izquierda_inicio_and = inicio_devuelta;
                izquierda_fin_and = fin_devuelta;
        
                generarAFND(raiz.hijos.ElementAt(hijoderecho));
                derecha_inicio_and = inicio_devuelta;
                derecha_fin_and = fin_devuelta;
                concatenacion(izquierda_inicio_and,izquierda_fin_and,derecha_inicio_and,derecha_fin_and);


            }
            else if (raiz.valor.Equals("(or)"))
            {
                //hereda dos hijos

                generarAFND(raiz.hijos.ElementAt(hijoizquierdo));
                izquierda_inicio = inicio_devuelta;
                izquierda_fin = fin_devuelta;
                generarAFND(raiz.hijos.ElementAt(hijoderecho));
                derecha_inicio = inicio_devuelta;
                derecha_fin = fin_devuelta;

                union(izquierda_inicio, izquierda_fin, derecha_inicio, derecha_fin);



            }
            else if (raiz.valor.Equals("*"))
            {
                //hereda un hijo
                generarAFND(raiz.hijos.ElementAt(hijoizquierdo));

                cerraduraasterisco(inicio_devuelta,fin_devuelta);


            }
            else if (raiz.valor.Equals("+"))
            {
                //hereda un hijo
                generarAFND(raiz.hijos.ElementAt(hijoizquierdo));


                cerradurapositiva(inicio_devuelta,fin_devuelta);

            } else if (raiz.valor.Equals("?")) {
                //herada un hijo
                 generarAFND(raiz.hijos.ElementAt(hijoizquierdo));


                 cerradurapregunta(inicio_devuelta,fin_devuelta);

            } else {

                //de una hoja
                //retornar un simbolo o epsilon
                simbolo(raiz.valor);
                return;

            }
            
        }






        /*VAMOS A INCLUIR METODOS PARA AGREGAR SOLAMENTE LOS BLOQUES SEGUN LA CERRADURA*/


        public void simbolo(String simbolo) {

         
            

           Nodo inicio = new Nodo(estado.ToString()); estado++;
            inicio.transicion = simbolo;
            inicio_devuelta = inicio;

            Nodo fin = new Nodo(estado.ToString()); estado++;
            fin_devuelta = fin;
            arbol_dot += inicio.valor + "->" + fin.valor;
            arbol_dot += "[label= \"" + inicio.transicion + "\"]\n";
            //inicio-> fin
            inicio.agregarHijo(fin);



           


        }

        public void concatenacion(Nodo inicio1aux, Nodo fin1aux,Nodo inicio2aux, Nodo fin2aux)
        {

            Nodo inicio1 = inicio1aux;
            Nodo fin1 = fin1aux;
            Nodo inicio2 = inicio2aux;
            Nodo fin2 = fin2aux;

            fin1.transicion = "ε";
            fin1.agregarHijo(inicio2);

          
            arbol_dot += fin1.valor+ "->" + inicio2.valor;
           // fin1.agregarHijo(inicio2);
            arbol_dot += "[label= \"" + "ε" + "\"]\n";


            //nuevos
            inicio_devuelta = inicio1;
            fin_devuelta = fin2;

        }


        public void union(Nodo inicio1aux, Nodo fin1aux, Nodo inicio2aux, Nodo fin2aux)
        {


            Nodo inicio1 = inicio1aux;
            Nodo fin1 = fin1aux;

            Nodo inicio2 = inicio2aux;
            Nodo fin2 = fin2aux;


            Nodo inicio_or = new Nodo(estado.ToString()); estado++;
            inicio_or.transicion = "ε";

            inicio_or.agregarHijo(inicio1);
            inicio_or.agregarHijo(inicio2);

            arbol_dot += inicio_or.valor + "->" + inicio1.valor;
            arbol_dot += "[label= \"" + inicio_or.transicion + "\"]\n";

            arbol_dot += inicio_or.valor + "->" + inicio2.valor;
            arbol_dot += "[label= \"" + inicio_or.transicion + "\"]\n";

            Nodo fin_or = new Nodo(estado.ToString()); estado++;

            fin1.agregarHijo(fin_or);
            fin1.transicion= "ε";
            fin2.agregarHijo(fin_or);
            fin2.transicion = "ε";

            arbol_dot += fin1.valor + "->" +fin_or.valor;
            arbol_dot += "[label= \"" + fin1.transicion + "\"]\n";

            arbol_dot += fin2.valor + "->" + fin_or.valor;
            arbol_dot += "[label= \"" + fin2.transicion + "\"]\n";



            //nuevos
            inicio_devuelta = inicio_or;
            fin_devuelta = fin_or;


        }

        public void cerraduraasterisco(Nodo inicio1aux, Nodo fin1aux)
        {
           

            Nodo inicio1 = inicio1aux;
            
            Nodo fin1 = fin1aux;
            fin1.aplicaRetorno = true;

            //inicio2->inicio1
            Nodo Inicio2 = new Nodo(estado.ToString()); estado++;
            Inicio2.transicion = "ε";
            Inicio2.agregarHijo(inicio1);
            arbol_dot += Inicio2.valor + "->" + inicio1.valor;
            arbol_dot += "[label= \"" + Inicio2.transicion + "\"]\n";

            //fin1 -> inicio1
          
            fin1.transicion= "ε";
            arbol_dot += fin1.valor + "->" + inicio1.valor;
            arbol_dot += "[label= \"" + fin1.transicion + "\"]\n";
                       
            //fin1 -> fin2
            Nodo fin2 = new Nodo(estado.ToString()); estado++;
            fin2.transicion = "ε";
            fin1.agregarHijo(fin2);
       //     fin1.agregarHijo(inicio1);
            arbol_dot += fin1.valor + "->" + fin2.valor;
            arbol_dot += "[label= \"" + "ε" + "\"]\n";

            //inicio2-> fin2
            Inicio2.agregarHijo(fin2);
            arbol_dot += Inicio2.valor + "->" + fin2.valor;
            arbol_dot += "[label= \"" + Inicio2.transicion + "\"]\n";

            inicio_devuelta = Inicio2;
            fin_devuelta = fin2;

           
        }


        public void cerradurapregunta(Nodo inicio1aux, Nodo fin1aux) {

          

            Nodo inicio1 = inicio1aux;
            Nodo fin1 = fin1aux;

            //inicio2->inicio1
            Nodo Inicio2 = new Nodo(estado.ToString()); estado++;
            Inicio2.transicion = "ε";
            Inicio2.agregarHijo(inicio1);
            arbol_dot += Inicio2.valor + "->" + inicio1.valor;
            arbol_dot += "[label= \"" + Inicio2.transicion + "\"]\n";

            
            //fin1 -> fin2
            Nodo fin2 = new Nodo(estado.ToString()); estado++;
            fin2.transicion = "ε";
            fin1.agregarHijo(fin2);
            arbol_dot += fin1.valor + "->" + fin2.valor;
            arbol_dot += "[label= \"" + "ε" + "\"]\n";

            //inicio2-> fin2
            Inicio2.agregarHijo(fin2);

            arbol_dot += Inicio2.valor + "->" + fin2.valor;
            arbol_dot += "[label= \"" + Inicio2.transicion + "\"]\n";

            inicio_devuelta = Inicio2;
            fin_devuelta = fin2;

      



        }


        public void cerradurapositiva(Nodo inicio1aux, Nodo fin1aux)
        {

          

            Nodo inicio1 = inicio1aux;
          
            Nodo fin1 = fin1aux;
            fin1.aplicaRetorno = true;
            //inicio2->inicio1
            Nodo Inicio2 = new Nodo(estado.ToString()); estado++;
            Inicio2.transicion = "ε";
            Inicio2.agregarHijo(inicio1);
            arbol_dot += Inicio2.valor + "->" + inicio1.valor;
            arbol_dot += "[label= \"" + Inicio2.transicion + "\"]\n";

            //fin1 -> inicio1
            
            fin1.transicion = "ε";
            arbol_dot += fin1.valor + "->" + inicio1.valor;
            arbol_dot += "[label= \"" + fin1.transicion + "\"]\n";

            //fin1 -> fin2
            Nodo fin2 = new Nodo(estado.ToString()); estado++;
            fin2.transicion= "ε";
            fin1.agregarHijo(fin2);
            //fin1 -> inicio1
          //  fin1.agregarHijo(inicio1);
            arbol_dot += fin1.valor + "->" + fin2.valor;
            arbol_dot += "[label= \"" + fin1.transicion + "\"]\n";

            
            inicio_devuelta = Inicio2;
            fin_devuelta = fin2;




        }
        int estadoo = 1;
        public String recorrer_AFND(Nodo nodo)
        {
            String concatena = "";

            String padre = nodo.valor;


            //   concatena += nodo.valor + "[label=\""+estadoo.ToString()+"\"]\n";
            // estadoo++;
            concatena += nodo.valor + "\n";
            foreach (Nodo hijo in nodo.hijos)
            {

                if (!hijo.aplicaRetorno)
                {

                    if (!pila.Contains(nodo.valor + "->" + hijo.valor))
                    {
                        MessageBox.Show(nodo.valor + "->" + hijo.valor);
                        concatena += nodo.valor + "->" + hijo.valor;
                        concatena += "[label= \"" + nodo.transicion + "\"]\n";

                        pila.AddLast(nodo.valor + "->" + hijo.valor);
                        concatena += recorrer_AFND(hijo);


                    }

                }
                else
                {
                    if (!pila.Contains(nodo.valor + "->" + hijo.valor))
                    {
                        MessageBox.Show(nodo.valor + "->" + hijo.valor);
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

    }
    }
