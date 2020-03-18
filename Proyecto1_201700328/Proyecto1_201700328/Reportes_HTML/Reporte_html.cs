using Proyecto1_201700328.Analizadores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net;
using System.Windows.Forms;

namespace Proyecto1_201700328.Reportes_HTML
{
    public class Reporte_html
    {
        public void escribir_fichero_tokens_y_errores(LinkedList<Token_lenguaje> tokens, LinkedList<Token_lenguaje> errores) {
            String nombre = "reportepdf.html";
            String texto = "";
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
            texto += "background-color:green;";
            texto += "color: white;";
            texto += "}";
            texto += "</style>";
            texto += "</head>";
            texto += "<body>";
            texto += "<h2>TABLA DE TOKENS</h2>";
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
            foreach (Token_lenguaje token in tokens)  {
                texto += "<td>" + i + "</td>";
                texto += "<td>" + token.getLexema() + "</td>";
                texto += "<td>" + token.tipo_detallado(token.getTipo()) + "</td>";
                texto += "<td>" + token.getFila() + "</td>";
                texto += "<td>" + token.getColumna() + "</td>";

                texto += "</tr>";

                i++;
            }
            texto += "</table>";
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

            int ii = 1;
            foreach (Token_lenguaje dato in errores)
            {
                texto += "<td>" + ii + "</td>";
                texto += "<td>" + dato.getLexema() + "</td>";
                texto += "<td>" + dato.getTipo() + "</td>";
                texto += "<td>" + dato.getFila() + "</td>";
                texto += "<td>" + dato.getColumna() + "</td>";

                texto += "</tr>";

                ii++;
            }

            texto += "</table>";
            texto += "</body>";
            texto += "</html>";


            File.WriteAllLines(nombre, new String[] { texto });
        }

        public void mostrar_reporte__tokens_y_errores()
        {


            
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();
            v.ConvertHtmlFileToPDFFile(@"C:/Users/marco/Documents/GitHub/PROYECTO1_OLC1/Proyecto1_201700328/Proyecto1_201700328/bin/Debug/reportepdf.html", @"C:/Users/marco/Documents/GitHub/PROYECTO1_OLC1/Proyecto1_201700328/Proyecto1_201700328/bin/Debug/salida.pdf");
            Process.Start("salida.pdf");

        }

        public void escribir_fichero_tokens(LinkedList<Token_lenguaje> datos){

            string fileName = "Tokens.html";
            String texto = "";
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
            texto += "background-color:green;";
            texto += "color: white;";
            texto += "}";
            texto += "</style>";
            texto += "</head>";
            texto += "<body>";
            texto += "<h2>TABLA DE TOKENS</h2>";
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
            foreach (Token_lenguaje token in datos)
            {
                texto += "<td>" + i + "</td>";
                texto += "<td>" + token.getLexema() + "</td>";
                texto += "<td>" + token.tipo_detallado(token.getTipo()) + "</td>";
                texto += "<td>" + token.getFila() + "</td>";
                texto += "<td>" + token.getColumna() + "</td>";

                texto += "</tr>";

                i++;
            }

            texto += "</table>";
            texto += "</body>";
            texto += "</html>";
            File.WriteAllLines(fileName, new String[] { texto });

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
            SautinSoft.PdfVision v = new SautinSoft.PdfVision();
            v.ConvertHtmlFileToPDFFile(@"C:/Users/marco/Documents/GitHub/PROYECTO1_OLC1/Proyecto1_201700328/Proyecto1_201700328/bin/Debug/Tokens.html", @"C:/Users/marco/Documents/GitHub/PROYECTO1_OLC1/Proyecto1_201700328/Proyecto1_201700328/bin/Debug/salida.pdf");
          

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

        public void escribir_lexemas_salida(LinkedList<Expresion_Lexema> datos)
        {

            string path = "Lexemassalida.html";
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
            texto += "background-color:green;";
            texto += "color: white;";
            texto += "}";
            texto += "</style>";
            texto += "</head>";
            texto += "<body>";
            texto += "<h2>SAlIDA</h2>";
            texto += "<table>";
            texto += "<tr>";
            texto += "<th>NO.</th>";
            texto += "<th>ID</th>";
            texto += "<th>LEXEMA</th>";
            texto += "<th>ESTADO</th>";

            texto += "</tr>";
            texto += "<tr>";

            int i = 1;
            foreach (Expresion_Lexema dato in datos)
            {
                texto += "<td>" + i + "</td>";
                texto += "<td>" + dato.getIdentiicador() + "</td>";
                texto += "<td>" + dato.getContenido() + "</td>";
                texto += "<td>" + dato.estado + "</td>";


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

        public void mostrar_lexemas_salida()
        {

            Process.Start("Lexemassalida.html");
            

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


    

