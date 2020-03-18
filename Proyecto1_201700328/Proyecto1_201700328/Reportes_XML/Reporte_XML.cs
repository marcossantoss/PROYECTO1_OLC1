using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_201700328.Reportes_XML
{
  public  class Reporte_XML
    {
        public void reporte_tokens_xml(String datos)
        {

            string path = "Tokens_XML.xml";

            String texto="";
            texto+= "<ListaTokens>";
            texto += datos;
            texto += "</ListaTokens>";
            //pw.printlninfo;

            File.WriteAllLines(path, new String[] { texto });

        }


        public void reporte_tokens_errores(String datos)
        {

            string path = "errores_XML.xml";
            String texto = "";
            texto += "<ListaErrores>";
            texto += datos;
            texto += "</ListaErrores>";
            //pw.printlninfo;

            File.WriteAllLines(path, new String[] { texto });

        }


    }
}
