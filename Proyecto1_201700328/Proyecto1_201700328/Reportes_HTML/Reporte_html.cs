using Proyecto1_201700328.Analizadores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201700328.Reportes_HTML
{
    public class Reporte_html
    {
        public void escribir_fichero_tokens(LinkedList<Token_lenguaje> datos){

            string fileName = @"Tokens.html";
            FileStream stream = null;
             // Create a FileStream with mode CreateNew  
                stream = new FileStream(fileName, FileMode.OpenOrCreate);
                // Create a StreamWriter from FileStream  
                using (StreamWriter pw = new StreamWriter(stream, Encoding.UTF8))
                {

                    //pw.println(info);
                    pw.WriteLine("<!DOCTYPE html>");
                    pw.WriteLine("<head>");
                    pw.WriteLine("<title>R e p o r t e</title>");
                    pw.WriteLine("<style>");
                    pw.WriteLine("table {");
                    pw.WriteLine("font-family: arial, sans-serif;");
                    pw.WriteLine("border: 1px solid #dddddd;");
                    pw.WriteLine("width: 100%;");
                    pw.WriteLine("}");
                    pw.WriteLine("td, th {");
                    pw.WriteLine("border: 1px solid #dddddd;");
                    pw.WriteLine("text-align: left;");
                    pw.WriteLine("padding: 8px;");
                    pw.WriteLine("}");
                    pw.WriteLine("th{");
                    pw.WriteLine("background-color:green;");
                    pw.WriteLine("color: white;");
                    pw.WriteLine("}");
                    pw.WriteLine("</style>");
                    pw.WriteLine("</head>");
                    pw.WriteLine("<body>");
                    pw.WriteLine("<h2>TABLA DE TOKENS</h2>");
                    pw.WriteLine("<table>");
                    pw.WriteLine("<tr>");
                    pw.WriteLine("<th>NO.</th>");
                    pw.WriteLine("<th>LEXEMA</th>");
                    pw.WriteLine("<th>TIPO</th>");
                    pw.WriteLine("<th>FILA</th>");
                    pw.WriteLine("<th>COLUMNA</th>");
                    pw.WriteLine("</tr>");
                    pw.WriteLine("<tr>");

                    int i = 1;
                    foreach (Token_lenguaje dato in datos)
                    {
                        pw.WriteLine("<td>" + i + "</td>");
                        pw.WriteLine("<td>" + dato.getLexema() + "</td>");
                        pw.WriteLine("<td>" + dato.tipo_detallado(dato.getTipo()) + "</td>");
                        pw.WriteLine("<td>" + dato.getFila() + "</td>");
                        pw.WriteLine("<td>" + dato.getColumna() + "</td>");

                        pw.WriteLine("</tr>");

                        i++;
                    }

                    pw.Write("</table>");
                    pw.WriteLine("</body>");
                    pw.WriteLine("</html>");
                }
          
        }

        public void probrando(LinkedList<Token_lenguaje> datos) {

            string path = "ErroresTokens.html";
            String texto="";

            //pw.printlninfo;
            texto += "<!DOCTYPE html>";
            texto += "<head>";
            texto += "<title>R e p o r t e</title>";
            texto += "<style>";
            texto += "table {";
            texto += "font-family: arial, sans-serif;";
            texto += "border: 1px solid #dddddd;";
            texto += "width: 100%;";
            texto += "}";
            texto += "td, th {";
            texto += "border: 1px solid #dddddd;";
            texto += "text-align: left;";
            texto += "padding: 8px;";
            texto += "}";
            texto += "th{";
            texto += "background-color:red;";
            texto += "color: white;";
            texto += "}";
            texto += "</style>";
            texto += "</head>";
            texto += "<body>";
            texto += "<h2>ERRORES LEXICOS</h2>";
            texto += "<table>";
            texto += "<tr>";
            texto += "<th>NO.</th>";
            texto += "<th>LEXEMA</th>";
            texto += "<th>TIPO</th>";
            texto += "<th>FILA</th>";
            texto += "<th>COLUMNA</th>";
            texto += "</tr>";
            texto += "<tr>";

            int i = 1;
            foreach (Token_lenguaje dato in datos){
                texto += "<td>"+  i + "</td>";
                texto += "<td>"+dato.getLexema()+ "</td>";
                texto += "<td>" + dato.getTipo() + "</td>";
                texto += "<td>" + dato.getFila() + "</td>";
                texto += "<td>" + dato.getColumna() + "</td>";

                texto += "</tr>";

                i++;
            }

            texto += "</table>";
            texto += "</body>";
            texto += "</html>";

            File.WriteAllLines(path, new String[] { texto });

        }


        public void mostrar_reporte_tokens()
        {
         

                Process.Start("Tokens.html");

           
        }

        
        public void mostrar_reporte_ErroresLexicos()
        {
      
              Process.Start("ErroresTokens.html");

           
        }


        public void escribir_macros(LinkedList<Expresion_Lexema> datos)
        {

            string path = "Macros.html";
            String texto = "";

            //pw.printlninfo;
            texto += "<!DOCTYPE html>";
            texto += "<head>";
            texto += "<title>R e p o r t e</title>";
            texto += "<style>";
            texto += "table {";
            texto += "font-family: arial, sans-serif;";
            texto += "border: 1px solid #dddddd;";
            texto += "width: 100%;";
            texto += "}";
            texto += "td, th {";
            texto += "border: 1px solid #dddddd;";
            texto += "text-align: left;";
            texto += "padding: 8px;";
            texto += "}";
            texto += "th{";
            texto += "background-color:blue;";
            texto += "color: white;";
            texto += "}";
            texto += "</style>";
            texto += "</head>";
            texto += "<body>";
            texto += "<h2>MACRO</h2>";
            texto += "<table>";
            texto += "<tr>";
            texto += "<th>NO.</th>";
            texto += "<th>ID</th>";
            texto += "<th>MACRO</th>";

            texto += "</tr>";
            texto += "<tr>";

            int i = 1;
            foreach (Expresion_Lexema dato in datos)
            {
                texto += "<td>" + i + "</td>";
                texto += "<td>" + dato.getIdentiicador() + "</td>";
                texto += "<td>" + dato.getContenido() + "</td>";
              

                texto += "</tr>";

                i++;
            }

            texto += "</table>";
            texto += "</body>";
            texto += "</html>";

            File.WriteAllLines(path, new String[] { texto });

        }


        public void mostrar_macros() {

            Process.Start("Macros.html");
        }


        public void escribir_lexemas(LinkedList<Expresion_Lexema> datos)
        {

            string path = "Lexemas.html";
            String texto = "";

            //pw.printlninfo;
            texto += "<!DOCTYPE html>";
            texto += "<head>";
            texto += "<title>R e p o r t e</title>";
            texto += "<style>";
            texto += "table {";
            texto += "font-family: arial, sans-serif;";
            texto += "border: 1px solid #dddddd;";
            texto += "width: 100%;";
            texto += "}";
            texto += "td, th {";
            texto += "border: 1px solid #dddddd;";
            texto += "text-align: left;";
            texto += "padding: 8px;";
            texto += "}";
            texto += "th{";
            texto += "background-color:blue;";
            texto += "color: white;";
            texto += "}";
            texto += "</style>";
            texto += "</head>";
            texto += "<body>";
            texto += "<h2>LEXEMAS</h2>";
            texto += "<table>";
            texto += "<tr>";
            texto += "<th>NO.</th>";
            texto += "<th>ID</th>";
            texto += "<th>LEXEMA</th>";

            texto += "</tr>";
            texto += "<tr>";

            int i = 1;
            foreach (Expresion_Lexema dato in datos)
            {
                texto += "<td>" + i + "</td>";
                texto += "<td>" + dato.getIdentiicador() + "</td>";
                texto += "<td>" + dato.getContenido() + "</td>";


                texto += "</tr>";

                i++;
            }

            texto += "</table>";
            texto += "</body>";
            texto += "</html>";

            File.WriteAllLines(path, new String[] { texto });

        }


        public void mostrar_lexemas()
        {

            Process.Start("Lexemas.html");
        }

        public void escribir_expresionesregulares(LinkedList<Expresion_Lexema> datos)
        {

            string path = "Expresiones.html";
            String texto = "";

            //pw.printlninfo;
            texto += "<!DOCTYPE html>";
            texto += "<head>";
            texto += "<title>R e p o r t e</title>";
            texto += "<style>";
            texto += "table {";
            texto += "font-family: arial, sans-serif;";
            texto += "border: 1px solid #dddddd;";
            texto += "width: 100%;";
            texto += "}";
            texto += "td, th {";
            texto += "border: 1px solid #dddddd;";
            texto += "text-align: left;";
            texto += "padding: 8px;";
            texto += "}";
            texto += "th{";
            texto += "background-color:blue;";
            texto += "color: white;";
            texto += "}";
            texto += "</style>";
            texto += "</head>";
            texto += "<body>";
            texto += "<h2>EXPRESIONES REGULARES</h2>";
            texto += "<table>";
            texto += "<tr>";
            texto += "<th>NO.</th>";
            texto += "<th>ID</th>";
            texto += "<th>LEXEMA</th>";

            texto += "</tr>";
            texto += "<tr>";

            int i = 1;
            foreach (Expresion_Lexema dato in datos)
            {
                texto += "<td>" + i + "</td>";
                texto += "<td>" + dato.getIdentiicador() + "</td>";
                texto += "<td>" + dato.getContenido() + "</td>";


                texto += "</tr>";

                i++;
            }

            texto += "</table>";
            texto += "</body>";
            texto += "</html>";

            File.WriteAllLines(path, new String[] { texto });

        }


        public void mostrar_expresionesregulares()
        {

            Process.Start("Expresiones.html");
        }

    }

}


    

