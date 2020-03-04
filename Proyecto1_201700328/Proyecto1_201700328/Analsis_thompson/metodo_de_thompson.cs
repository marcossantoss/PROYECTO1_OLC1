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

        LinkedList<Tablas_de_informacion> Informacion_de_cadaID = new LinkedList<Tablas_de_informacion>();

        Nodo Raiz_temporal_final = null;

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
                            expresion_estructurada.AddLast(cadena_nueva.Replace("\"","´"));
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

        Graficadora.Graficadora grafica =new Graficadora.Graficadora();

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


                    Nodo NodoInicio = new Nodo(estado.ToString());

                    Raiz_temporal_final = NodoInicio;
                    generarAFND(hijo1);
                    //analisis de transiciones
                    /*    LinkedList<Transicion> nueva_t_transiciones = new LinkedList<>();
                        System.out.println("inicio----");
                        Tabla_transiciones(padre, nueva_t_transiciones, nueva_tabla);
                        System.out.println("fin----\n\n");
                        */


                    grafica.escribir_fichero_grafo(arbol_dot,expression.id);


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
                    Nodo NodoInicio = new Nodo(estado.ToString());
                    arbol_dot += "rankdir=LR; size = \"8,5\"\n";
                    arbol_dot += "node [shape = circle];\n";
                   
                    Raiz_temporal_final = NodoInicio;
                    generarAFND(hijo1);
                   // arbol_dot += " node[shape = doublecircle];" +estado.ToString();

                    grafica.escribir_fichero_grafo(arbol_dot, expression.id+"_AFND");
                    grafica.generar_Dot_grafo(expression.id + "_AFND");

                    grafica.escribir_fichero_grafo(grafica.recorrer_arbolito(padre) + "\n label=\"" + expression.id + "\";\n", expression.id);
                    grafica.generar_Dot_grafo(expression.id);

                }

                //limpiamos nuestros operadores
                i = 0;
                arbol_dot = "";
                Raiz_temporal_final = null;
                estado = 0;
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
        String datoIzquierdo = "";
        String datoDerecho = "";

        public String generarAFND(Nodo raiz) {

          
                if (raiz.valor.Equals("."))
                {

                Raiz_temporal_final = concatenacion(Raiz_temporal_final, datoIzquierdo, datoDerecho);

                datoIzquierdo = generarAFND(raiz.hijos.ElementAt(hijoizquierdo));
                datoDerecho = generarAFND(raiz.hijos.ElementAt(hijoderecho));
          
                  
                
                }
                else if (raiz.valor.Equals("(or)"))
                {
                Raiz_temporal_final = union(Raiz_temporal_final, datoIzquierdo, datoDerecho);//hereda dos hijos

                datoIzquierdo = generarAFND(raiz.hijos.ElementAt(hijoizquierdo));
                datoDerecho = generarAFND(raiz.hijos.ElementAt(hijoderecho));

                

            }
                else if (raiz.valor.Equals("*"))
                {
                //hereda un hijo
                datoIzquierdo = generarAFND(raiz.hijos.ElementAt(hijoizquierdo));
            

                Raiz_temporal_final = cerraduraasterisco(Raiz_temporal_final, datoIzquierdo);


            }
                else if (raiz.valor.Equals("+"))
                {
                //hereda un hijo
                datoIzquierdo = generarAFND(raiz.hijos.ElementAt(hijoizquierdo));


                Raiz_temporal_final = cerradurapositiva(Raiz_temporal_final, datoIzquierdo);

            }
                else if (raiz.valor.Equals("?"))
                {
                //herada un hijo
                datoIzquierdo = generarAFND(raiz.hijos.ElementAt(hijoizquierdo));


                Raiz_temporal_final = cerradurapregunta(Raiz_temporal_final, datoIzquierdo);

            }
                else
                {

                //de una hoja
                return raiz.valor;

                }
            return "";
            }

                     

        


        /*VAMOS A INCLUIR METODOS PARA AGREGAR SOLAMENTE LOS BLOQUES SEGUN LA CERRADURA*/

        public Nodo epsilon(Nodo padre_anterior,String simbolo) {

            padre_anterior.transicion = "ε";

            Nodo nuevo_nodo = new Nodo(estado.ToString());     estado++;

            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + nuevo_nodo.GetHashCode().ToString();
            arbol_dot += "[label= \"" + padre_anterior.transicion + "\"]\n";
            padre_anterior.agregarHijo(nuevo_nodo);

            return nuevo_nodo;

        }


        public Nodo simbolo(Nodo padre_anterior, String simbolo) {

            padre_anterior.transicion = simbolo;

            Nodo nuevo_nodo = new Nodo(estado.ToString());    estado++;
            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + nuevo_nodo.GetHashCode().ToString();
            arbol_dot += "[label= \"" + padre_anterior.transicion + "\"]\n";
            padre_anterior.agregarHijo(nuevo_nodo);

            return nuevo_nodo;


        }

        public Nodo concatenacion(Nodo padre_anterior, String simbolo1,String simbolo2)
        {
            //LR_0 -> LR_2 [ label = "SS(B)" ];
            padre_anterior.transicion = simbolo1;

          
            Nodo nuevo_nodo = new Nodo(estado.ToString());   estado++;
            nuevo_nodo.transicion = "ε";


            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + nuevo_nodo.GetHashCode().ToString();
            arbol_dot += "[label= \"" + padre_anterior.transicion + "\"]\n";
            padre_anterior.agregarHijo(nuevo_nodo);

            Nodo nuevo_nodo1 = new Nodo(estado.ToString());   estado++;
            nuevo_nodo1.transicion = simbolo2;

            arbol_dot += nuevo_nodo.GetHashCode().ToString() + "->" + nuevo_nodo1.GetHashCode().ToString();
            arbol_dot += "[label= \"" + nuevo_nodo.transicion + "\"]\n";
            nuevo_nodo.agregarHijo(nuevo_nodo1);

            Nodo nuevo_nodo2 = new Nodo(estado.ToString()); estado++;
           

            arbol_dot += nuevo_nodo1.GetHashCode().ToString() + "->" + nuevo_nodo2.GetHashCode().ToString();
            arbol_dot += "[label= \"" + "ε" + "\"]\n";
            nuevo_nodo1.agregarHijo(nuevo_nodo2);

            return nuevo_nodo2;

        }


        public Nodo union(Nodo padre_anterior, String simbolo1, String simbolo2)
        {

            padre_anterior.transicion = "ε";

            Nodo arriba1= new Nodo(estado.ToString()); estado++;
            arriba1.transicion = simbolo1;

            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + arriba1.GetHashCode().ToString();
            arbol_dot += "[label= \"" + padre_anterior.transicion + "\"]\n";
            padre_anterior.agregarHijo(arriba1);


            Nodo arriba2 = new Nodo(estado.ToString()); estado++;
            arriba2.transicion = "ε";

            arbol_dot += arriba1.GetHashCode().ToString() + "->" + arriba2.GetHashCode().ToString();
            arbol_dot += "[label= \"" + arriba1.transicion + "\"]\n";
            arriba1.agregarHijo(arriba2);

           Nodo abajo1 = new Nodo(estado.ToString()); estado++;
            abajo1.transicion = simbolo2;

            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + abajo1.GetHashCode().ToString();
            arbol_dot += "[label= \"" + padre_anterior.transicion + "\"]\n";
            padre_anterior.agregarHijo(abajo1);

            Nodo abajo2 = new Nodo(estado.ToString()); estado++;
            abajo2.transicion = "ε";

            arbol_dot += abajo1.GetHashCode().ToString() + "->" + abajo2.GetHashCode().ToString();
            arbol_dot += "[label= \"" + abajo1.transicion + "\"]\n";
            abajo1.agregarHijo(abajo2);


            Nodo fin = new Nodo(estado.ToString()); estado++;

            arbol_dot += arriba2.GetHashCode().ToString() + "->" + fin.GetHashCode().ToString();
            arbol_dot += "[label= \"" + arriba2.transicion + "\"]\n";
            arriba2.agregarHijo(fin);

            arbol_dot += abajo2.GetHashCode().ToString() + "->" + fin.GetHashCode().ToString();
            arbol_dot += "[label= \"" + abajo2.transicion + "\"]\n";
            abajo2.agregarHijo(fin);


            return fin;

        }

        public Nodo cerraduraasterisco(Nodo padre_anterior, String simbolo1)
        {
            padre_anterior.transicion = "ε";

            Nodo nuevo = new Nodo(estado.ToString()); estado++;
            nuevo.transicion = simbolo1;
            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + nuevo.GetHashCode().ToString();
            arbol_dot += "[label= \"" + padre_anterior.transicion + "\"]\n";
            padre_anterior.agregarHijo(nuevo);

            Nodo nuevo1 = new Nodo(estado.ToString()); estado++;
            nuevo1.transicion = "ε";


            arbol_dot += nuevo.GetHashCode().ToString() + "->" + nuevo1.GetHashCode().ToString();
            arbol_dot += "[label= \"" + nuevo.transicion + "\"]\n";
            nuevo.agregarHijo(nuevo1);

            arbol_dot += nuevo1.GetHashCode().ToString() + "->" + nuevo.GetHashCode().ToString();
            arbol_dot += "[label= \"" + nuevo1.transicion + "\"]\n";
            nuevo1.agregarHijo(nuevo);

            Nodo nuevo2 = new Nodo(estado.ToString()); estado++;

            arbol_dot += nuevo1.GetHashCode().ToString() + "->" + nuevo2.GetHashCode().ToString();
            arbol_dot += "[label= \"" + nuevo1.transicion + "\"]\n";
            nuevo1.agregarHijo(nuevo2);

            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + nuevo2.GetHashCode().ToString();
            arbol_dot += "[label= \"" + "ε" + "\"]\n";
            padre_anterior.agregarHijo(nuevo2);



            return nuevo2;

        }


        public Nodo cerradurapregunta(Nodo padre_anterior,String simbolo) {

            padre_anterior.transicion = "ε";

            Nodo nuevo = new Nodo(estado.ToString()); estado++;
            nuevo.transicion = simbolo;
            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + nuevo.GetHashCode().ToString();
            arbol_dot += "[label= \"" + padre_anterior.transicion + "\"]\n";
            padre_anterior.agregarHijo(nuevo);

            Nodo nuevo1 = new Nodo(estado.ToString()); estado++;
            nuevo1.transicion = "ε";

            arbol_dot += nuevo.GetHashCode().ToString() + "->" + nuevo1.GetHashCode().ToString();
            arbol_dot += "[label= \"" + nuevo.transicion + "\"]\n";
            nuevo.agregarHijo(nuevo1);

            Nodo nuevo2 = new Nodo(estado.ToString()); estado++;
            arbol_dot += nuevo1.GetHashCode().ToString() + "->" + nuevo2.GetHashCode().ToString();
            arbol_dot += "[label= \"" + nuevo1.transicion + "\"]\n";
            nuevo1.agregarHijo(nuevo2);

            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + nuevo2.GetHashCode().ToString();
            arbol_dot += "[label= \"" + "ε" + "\"]\n";
            padre_anterior.agregarHijo(nuevo2);



            return nuevo2;



        }


        public Nodo cerradurapositiva(Nodo padre_anterior, String simbolo)
        {

            padre_anterior.transicion = "ε";

            Nodo nuevo = new Nodo(estado.ToString()); estado++;
            nuevo.transicion = simbolo;
            arbol_dot += padre_anterior.GetHashCode().ToString() + "->" + nuevo.GetHashCode().ToString();
            arbol_dot += "[label= \"" + padre_anterior.transicion + "\"]\n";
            padre_anterior.agregarHijo(nuevo);

            Nodo nuevo1 = new Nodo(estado.ToString()); estado++;
            nuevo1.transicion = "ε";
            arbol_dot += nuevo.GetHashCode().ToString() + "->" + nuevo1.GetHashCode().ToString();
            arbol_dot += "[label= \"" + nuevo.transicion + "\"]\n";
            nuevo.agregarHijo(nuevo1);

            arbol_dot += nuevo1.GetHashCode().ToString() + "->" + nuevo.GetHashCode().ToString();
            arbol_dot += "[label= \"" + nuevo1.transicion + "\"]\n";
            nuevo1.agregarHijo(nuevo);

            Nodo nuevo2 = new Nodo(estado.ToString()); estado++;

            arbol_dot += nuevo1.GetHashCode().ToString() + "->" + nuevo2.GetHashCode().ToString();
            arbol_dot += "[label= \"" + nuevo1.transicion + "\"]\n";
            nuevo1.agregarHijo(nuevo2);
           



            return nuevo2;




        }

    }
    }
