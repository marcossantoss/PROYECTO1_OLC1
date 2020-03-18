using Proyecto1_201700328.Analizadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_201700328.Analsis_thompson
{


    public class Analisis_lexemas
    {

        LinkedList<Expresion_Lexema> lista_macros;
        LinkedList<Expresion_Lexema> lista_lexemas;
        LinkedList<Transicion> Transiciones;

        String Id;

        String salida_xml = "";
        int contador_de_malos = 0;
        public Analisis_lexemas(LinkedList<Expresion_Lexema> lista_macros, LinkedList<Expresion_Lexema> lista_lexemas, LinkedList<Transicion> Transiciones, String id)
        {
            this.lista_macros = lista_macros;
            this.lista_lexemas = lista_lexemas;
            this.Transiciones = Transiciones;
            this.Id = id;
        }
        //variable que contendra el contenido a retornar
      public String system_out_println = "";
        //aqui iniciamos con el analsis de las cadenas y ejecucion de reportes xml
        public String analizar_lexema() {



            //iniciamos con el analisis de cada cadena segun el id
            foreach (Expresion_Lexema lexema in lista_lexemas) {
                String contendio = "";
              //  MessageBox.Show("Id actual: " + Id);
                //aqui le decimos que solo analice las que tengan el id actual
                if (lexema.getIdentiicador().Equals(Id)) {

                    //limpiamo el contenido porque se cuelan algunos comentarios


                    contendio = lexema.getContenido();

                    int tamanio_lexema = contendio.Length - 1;
                    int posicion = -1;
                    for (int i = tamanio_lexema; i > -1; i--)
                    {
                        //inicia de atras para adelante;
                        if (contendio[i] == '"')
                        {
                            posicion = i;
                            break;
                        }

                    }

                    //limpiamos la cadena quitandole las comillas doble de inicio fin
                    contendio = contendio.Substring(1, posicion - 1);
                   // MessageBox.Show(Id + " - " + contendio);

                    //ahora que ya tenemos la cadena limpia sin comillas dobles
                    //eestado inicial siempre es 0
                    int index_de_recorrido_de_estado = 0;
                    String estado = Transiciones.ElementAt(index_de_recorrido_de_estado).estado;


                  //  MessageBox.Show("el estado inicial :" + estado);
                    Boolean lexema_valido = true;


                    for (int caracter_del_lexema = 0; caracter_del_lexema < contendio.Length; caracter_del_lexema++) {
                        //vamos a recorrer la cadena 
                        estado = Transiciones.ElementAt(index_de_recorrido_de_estado).estado;
                        char CaracterActual = contendio[caracter_del_lexema];

                        //vamos a obtener las transciones del estado actual
                        LinkedList<String> traslados = Transiciones.ElementAt(index_de_recorrido_de_estado).estados_siguientes;
                        bool caracter_valido = false;
                        String estadoalquevoy = "";
                     //  MessageBox.Show("El estado actual es: " + Transiciones.ElementAt(index_de_recorrido_de_estado).estado+"\n y el index es: "+index_de_recorrido_de_estado);
                        foreach (String traslado in traslados)
                        {

                            String[] tran = traslado.Split('¬');
                            String estado_alvoy = tran[0];
                            estadoalquevoy = estado_alvoy;
                            String elemento_transicion = tran[1];
                            //esto a primera instancia puede devolver esto
                            //si viene una cadena ´datos´
                       //   MessageBox.Show("El estado de transicion es: " + estadoalquevoy + " el elemento de transisicon " + elemento_transicion + "   caracteractual: " + CaracterActual);
                            if (elemento_transicion.Contains("´"))
                            {
                          //   MessageBox.Show("el carater actual es: " + CaracterActual + " y estamos en analsis del ´posibles cadenitas´");

                                if (elemento_transicion.Equals("´´"))
                                {
                                   
                                        if (CaracterActual == ' ')
                                        {
                                  //      MessageBox.Show("Se trata de un espacio en blanco");

                                        caracter_valido = true;
                                        }
                                        else
                                        {
                                            caracter_valido = false;
                                        }
                                                                    

                                }
                                else if (elemento_transicion.Contains("mayorque"))
                                {
                                    if (CaracterActual == '>')
                                    {
                                        caracter_valido = true;
                                    }

                                }
                                else if (elemento_transicion.Contains("menorque"))
                                {
                                    if (CaracterActual == '<')
                                    {
                                        caracter_valido = true;
                                    }

                                }
                               else if (elemento_transicion.Contains("\\") && elemento_transicion.Contains("n"))
                                {

                                    if (CaracterActual == '\n')
                                    {
                                        caracter_valido = true;
                                    }
                                }
                                else if (elemento_transicion.Contains("\\") && elemento_transicion.Contains("'"))
                                {
                                    if (CaracterActual == '\'')
                                    {
                                        caracter_valido = true;
                                    }
                                }
                                else if (elemento_transicion.Contains("\\") && elemento_transicion.Contains("\""))
                                {
                                    if (CaracterActual == '\"')
                                    {
                                        caracter_valido = true;
                                    }
                                }
                                else if (elemento_transicion.Contains("\\") && elemento_transicion.Contains("t"))
                                {
                                    if (CaracterActual == '\t')
                                    {
                                        caracter_valido = true;
                                    }
                                }
                                else
                                {

                                    //limpiamos la cadena
                                    elemento_transicion = elemento_transicion.Replace("´", "");
                                //    MessageBox.Show("Vamos a comparar el tamaño del arreglo de la cadena entre comillas   " + " el tamanio es: " + elemento_transicion.Length);
                                    foreach (char c in elemento_transicion)
                                    {

                                        caracter_valido = compara_cadenita_con_caracteres(elemento_transicion, contendio[caracter_del_lexema]);

                                        if (caracter_valido)
                                        {
                                            caracter_del_lexema++;
                                        }
                                        else
                                        {
                                            caracter_valido = false;
                                            break;
                                        }
                                    }
                                    //como este despues que finaliza siempre aumenta pero para evitar saltarno ese caracter le damos un menos menos
                                    if (caracter_valido) {
                                        caracter_del_lexema--;
                                    }


                                }



                                //venga el conjunto todo
                            }
                            else if (elemento_transicion.StartsWith("[:") && elemento_transicion.EndsWith(":]"))
                            {
                                caracter_valido = comparar_conjunto_todo(CaracterActual);

                                //si viene epsilon tiene que venir esta palabra que se entiende como un espacion en blanco
                            }
                            else if (elemento_transicion.Equals("epsilon") || elemento_transicion.Equals("ε"))
                            {
                                if (CaracterActual == ' ')
                                {
                                    caracter_valido = true;
                                }

                            }else if (elemento_transicion.Equals("saltolinea"))
                            {

                                if (CaracterActual == '\n')
                                {
                                    caracter_valido = true;
                                }
                            }
                            else if (elemento_transicion.Equals("comillasimple"))
                            {
                                if (CaracterActual == '\'')
                                {
                                    caracter_valido = true;
                                }
                            }
                            else if (elemento_transicion.Equals("comilladoble"))
                            {
                                if (CaracterActual == '\"')
                                {
                                    caracter_valido = true;
                                }
                            }
                            else if (elemento_transicion.Equals("tabulacion"))
                            {
                                if (CaracterActual == '\t')
                                {
                                    caracter_valido = true;
                                }

                            } else {//si elemento de transicion no se encuentra vamos a buscar una macro


                                //vamos a buscar a la lista de macros si existe el id
                                String macroEncontra = buscarMacro(elemento_transicion, lista_macros);
                                //si retorna "°" es porque no encontro se id
                             //   MessageBox.Show("La macro encontrada es: " + macroEncontra);
                                if (macroEncontra.Equals("°°"))
                                {
                                    caracter_valido = false;
                                    system_out_println += "La macro  \"" + elemento_transicion + "  no existe,debes crear la macro primero!\n";
                                }else
                                {//sino se encontró la macro

                                    //puede venir o una macro o conjunto o todo
                               //     MessageBox.Show("esto es una coma : " + macroEncontra[1] +" y su longitud es: "+ macroEncontra.Length);
                                    if (macroEncontra[1] == ',' && macroEncontra.Length != 1)
                                    {
                                        //es un conjunto de caracteres
                                   caracter_valido=  compara_conjunto_de_simbolitos(macroEncontra, CaracterActual);
                                    }//si es un conjunto con un solo elemento
                                    else if (macroEncontra.Length == 1) {

                                    caracter_valido= compara_conjunto_de_simbolitos(macroEncontra, CaracterActual);

                                    }//venga el conjunto todo
                                    else if (macroEncontra.StartsWith("[:") && macroEncontra.EndsWith(":]"))
                                    {
                                        caracter_valido = comparar_conjunto_todo(CaracterActual);


                                    }//si viene epsilon tiene que venir esta palabra que se entiende como un espacion en blanco
                                    else if (macroEncontra.Equals("epsilon") || macroEncontra.Equals("ε"))
                                    {
                                        if (CaracterActual == ' ')
                                        {
                                            caracter_valido = true;
                                        }


                                    }
                                    else
                                    {
                              //        MessageBox.Show("Verificando si es un rango");
                                        //viene un rango de 3 o 5 
                                        caracter_valido = compara_rangos(macroEncontra, CaracterActual);

                                    }
                                }
                            } // o si viene un id
                            //MessageBox.Show("EL caracter fue valido "+caracter_valido+" el caracter es: "+ CaracterActual);
                            if (caracter_valido) {
                                break;
                            }
                        //termina las transiciones   
                        }


                        if (caracter_valido)
                        {
                          // MessageBox.Show("EL caracter en el que estoy es: " + estado + " y al voy es: " + estadoalquevoy);
                            if (estado.Equals(estadoalquevoy))
                            {
                                //no aumento el index porque quiere decir que enconre el dato correpondiente
                              // MessageBox.Show("No se aumento el index");
                            }
                            else if (Convert.ToChar(estadoalquevoy) <Convert.ToChar(estado)) {
                                int resta = Convert.ToChar(estado) - Convert.ToChar(estadoalquevoy);
                                index_de_recorrido_de_estado = resta;
                            //  MessageBox.Show("el index ahora es: "+index_de_recorrido_de_estado);
                            }else if (Convert.ToChar(estadoalquevoy) > Convert.ToChar(estado))
                            {
                                int suma = Convert.ToChar(estadoalquevoy) - Convert.ToChar(estado);
                                index_de_recorrido_de_estado = suma+index_de_recorrido_de_estado;
                             //   MessageBox.Show("el index ahora es: " + index_de_recorrido_de_estado);
                            }
                            else if (!estado.Equals(estadoalquevoy))
                            {
                                index_de_recorrido_de_estado ++;
                            //    MessageBox.Show("el index se aumenta a: "+index_de_recorrido_de_estado);
                            }


                        } else {
                        //    MessageBox.Show("El caracter no fue valido -> "+CaracterActual);
                            contador_de_malos++;
                                                        
                        }

                      //   MessageBox.Show("el Index o estado resultante es: "+index_de_recorrido_de_estado);
                        //termina un caracter
                    }

                   // MessageBox.Show("mostrando mensajes");
                    if (lexema_valido && contador_de_malos==0)
                    {
                        system_out_println += "\n-> El lexema \"" + contendio + "\" con el id " + Id + " ACEPTADO";
                       
                    }
                    else {
                        system_out_println += "\n-> El lexema \"" + contendio + "\" con el id " + Id + " RECHAZADO";
                        
                    }
                }
                contador_de_malos = 0;
            }
            // MessageBox.Show("VAMOS A RETORNAR ESTOOOOOO");
            // MessageBox.Show("esto es lo que hay en sout -> " + system_out_println);
           
            return system_out_println;
        }

        public bool compara_cadenita_con_caracteres(String cadenita, char caracter) {
            Boolean caracterValido=false;
            //limpiar la cadenita
          
              

                //antes de limpiarla
               // MessageBox.Show("La cadenita antes de limpiarla es: " + cadenita);

                cadenita =cadenita.Replace("´","");
               // MessageBox.Show("La cadenita limpia es: " + cadenita);
                //ante de recorrer el for each preguntamos


                char[] letras = cadenita.ToCharArray();
                caracterValido = false;

                foreach (char letra in letras) {
                  //  MessageBox.Show("comparando este " + letra + " con  " + caracter);
                    if (letra == caracter)
                    {
                  //      MessageBox.Show("encontrado letras iguales");
                        caracterValido = true;
                        break;
                    }
                    else {

                        caracterValido = false;
                    }
                }
            

            return caracterValido;




        }


        public String buscarMacro(String id, LinkedList<Expresion_Lexema> macros_sistema) {
            String info_macro = "°°";



            foreach (Expresion_Lexema macro_sistema in macros_sistema) {


                if (macro_sistema.getIdentiicador().Equals(id)) {

                    info_macro = macro_sistema.getContenido();
                    break;
                }

            }
            return info_macro;
        }

        public bool comparar_conjunto_todo(char caracterActual) {

            if (caracterActual != '\n')
            {
                return true;
            }
            else {
                return false;
            }



        }

        public bool compara_conjunto_de_simbolitos(String miniconjunto, char caracter)
        {

            Boolean esValidoElCaracter = false;

            if (miniconjunto.Length == 1)
            {

                if (miniconjunto[0] == caracter)
                {
                    esValidoElCaracter = true;
                }
            }
            else {

                String[] datos = miniconjunto.Split(',');

                foreach (String cadenita in datos)
                {

                    if (cadenita.Contains("\\") && cadenita.Contains("n"))
                    {

                        if (caracter == '\n')
                        {
                            return true;
                        }
                    }
                    else if (cadenita.Contains("\\") && cadenita.Contains("'"))
                    {
                        if (caracter == '\'')
                        {
                            return true;
                        }
                    }
                    else if (cadenita.Contains("\\") && cadenita.Contains("\""))
                    {
                        if (caracter == '\"')
                        {
                            return true;
                        }
                    }
                    else if (cadenita.Contains("\\") && cadenita.Contains("t"))
                    {
                        if (caracter == '\t')
                        {
                            return true;
                        }
                    }

                //    MessageBox.Show("Comparando cadenita[0]: "+cadenita[0]+ " con caracter: "+ caracter);
                    if (cadenita[0] == caracter)
                    {
                        esValidoElCaracter = true;
                        return true;
                    }



                }

            }
            return esValidoElCaracter;
        }

        public bool compara_rangos(String miniconjunto, char caracter) {

            Boolean esValidoelcaracter = false;
            char limite_inferior;
            char limite_superior;

            String[] cadenita = miniconjunto.Split('~');



            if (cadenita[0].Contains("\\") && cadenita[0].Contains("n"))
            {

                limite_inferior = '\n';
            }
            else if (cadenita[0].Contains("\\") && cadenita[0].Contains("'"))
            {
                limite_inferior = '\'';
            }
            else if (cadenita[0].Contains("\\") && cadenita[0].Contains("\""))
            {
                limite_inferior = '\"';
            }
            else if (cadenita[0].Contains("\\") && cadenita[0].Contains("t"))
            {
                limite_inferior = '\t';
            }
            else {
                limite_inferior = Convert.ToChar(cadenita[0]);
            }


            //para el limite superior
            if (cadenita[1].Contains("\\") && cadenita[1].Contains("n"))
            {

                limite_superior = '\n';
            }
            else if (cadenita[1].Contains("\\") && cadenita[1].Contains("'"))
            {
                limite_superior = '\'';
            }
            else if (cadenita[1].Contains("\\") && cadenita[1].Contains("\""))
            {
                limite_superior= '\"';
            }
            else if (cadenita[1].Contains("\\") && cadenita[1].Contains("t"))
            {
                limite_superior = '\t';
            }
            else
            {
                limite_superior = Convert.ToChar(cadenita[1]);
            }

            if (limite_inferior < limite_superior)
            {

                if (caracter >= limite_inferior && caracter <= limite_superior) {

                    esValidoelcaracter = true;
                    return true;
                }

            }
            else {

                system_out_println += "\nLa macro no tiene sentido en sus limites, CAMBIE EL RANGO\n";
            }


            return esValidoelcaracter;
        }
    

    
    }
}
