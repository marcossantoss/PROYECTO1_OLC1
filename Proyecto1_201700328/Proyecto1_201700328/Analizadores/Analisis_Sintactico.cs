using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto1_201700328.Analizadores.Token_lenguaje;

namespace Proyecto1_201700328.Analizadores
{
    public class Analisis_Sintactico
    {
        int numero_preanalisis;//sirve para saber que elemento de la lista buscar
        Token_lenguaje simbolo_preanalisis;//seteamos el simbolo actual de analisis
        LinkedList<Token_lenguaje> Lista_Tokens;//lista que se obtiene del scanner
        Boolean analisisCorrecto = false;//verifica si fue satisfactorio el analisis

        String id_auxiliar = "";//nos va servir para almacenar en la lista el id ya que no se encuentran en el mismo estado

        public LinkedList<Expresion_Lexema> Lexemas = new LinkedList<Expresion_Lexema>();
        public LinkedList<Expresion_Lexema> Macros = new LinkedList<Expresion_Lexema>();
        public LinkedList<Expresion_Lexema> ExpresionesRegulares = new LinkedList<Expresion_Lexema>();

        public Analisis_Sintactico(LinkedList<Token_lenguaje> Lista_tokens)
        {
            this.Lista_Tokens = Lista_tokens;
        }

        public Boolean parser()
        {
            analisisCorrecto = true;
            numero_preanalisis = 0;
            simbolo_preanalisis = Lista_Tokens.ElementAt(0);

            INICIO();

            return analisisCorrecto;
        }

        private void INICIO()
        {
            // INICIO -> { CUERPO 
            match(Token_lenguaje.TOKEN.LLAVE_A);
            CUERPO();

            match(Token_lenguaje.TOKEN.ACEPTACION);

        }

        int contador = 0;

        private void CUERPO()
        {

            // CUERPO -> CUERPO SENTENCIA }
            // |SENTENCIA;
            if (simbolo_preanalisis.getTipo() == Token_lenguaje.TOKEN.LLAVE_C || simbolo_preanalisis.getTipo() == Token_lenguaje.TOKEN.ACEPTACION)
            {
                match(Token_lenguaje.TOKEN.LLAVE_C);
            }
            else
            {
                SENTENCIA();

            }
        }

        private void SENTENCIA()
        {

            //sentencia -> CONJ  CONJUNTOS
            if (simbolo_preanalisis.getTipo() == Token_lenguaje.TOKEN.CONJ)
            {
                match(Token_lenguaje.TOKEN.CONJ);
                CONJUNTOS();
            }
            else if (simbolo_preanalisis.getTipo() == Token_lenguaje.TOKEN.ID)
            {
                //sentencia -> ID  EXPRESIONES_LEXEMAS
                id_auxiliar = simbolo_preanalisis.getLexema().ToString();
                match(Token_lenguaje.TOKEN.ID);
                EXPRESIONES_LEXEMAS();
            }
            else if (simbolo_preanalisis.getTipo() == Token_lenguaje.TOKEN.PORCENTAJES)
            {
                //sentencia -> %%
                match(Token_lenguaje.TOKEN.PORCENTAJES);
            }
            CUERPO();

        }

        private void CONJUNTOS()
        {

            //CONJUNTOS ->: id flecha TIPO_C
            match(Token_lenguaje.TOKEN.DOSPUNTOS);
            id_auxiliar = simbolo_preanalisis.getLexema().ToString();

            match(Token_lenguaje.TOKEN.ID);

            match(Token_lenguaje.TOKEN.FLECHA);
            TIPO_C();

        }

        private void EXPRESIONES_LEXEMAS()
        {

            if (simbolo_preanalisis.getTipo() == Token_lenguaje.TOKEN.FLECHA)
            {
                //EXPRESIONES_LEXEMAS -> flecha EXPRESION
                match(Token_lenguaje.TOKEN.FLECHA);
                EXPRESION();
            }
            else if (simbolo_preanalisis.getTipo() == Token_lenguaje.TOKEN.DOSPUNTOS)
            {
                //EXPRESIONES_LEXEMAS -> flecha EXPRESION
                match(Token_lenguaje.TOKEN.DOSPUNTOS);
                LEXEMA();
            }
            else
            {
            
                MessageBox.Show("Error sintactico, se esperaba una->o un: ");
                Error_fatal();

            }
        }

        private void EXPRESION()
        {
            ExpresionesRegulares.AddLast(new Expresion_Lexema(id_auxiliar, simbolo_preanalisis.getLexema().ToString()));
            match(Token_lenguaje.TOKEN.EXPRESION);
            match(Token_lenguaje.TOKEN.PTOCOMA);
        }

        private void LEXEMA()
        {
            Lexemas.AddLast(new Expresion_Lexema(id_auxiliar, simbolo_preanalisis.getLexema().ToString()));
            match(Token_lenguaje.TOKEN.CADENA);
            match(Token_lenguaje.TOKEN.PTOCOMA);
        }

        private void TIPO_C()
        {

            if (simbolo_preanalisis.getTipo() == Token_lenguaje.TOKEN.CONJUNTOFINITIO)
            {
                //EXPRESIONES_LEXEMAS -> flecha EXPRESION
                String contenido = simbolo_preanalisis.getLexema().ToString();
                Macros.AddLast(new Expresion_Lexema(id_auxiliar, contenido));

                match(Token_lenguaje.TOKEN.CONJUNTOFINITIO);
                match(Token_lenguaje.TOKEN.PTOCOMA);

            }
            else if (simbolo_preanalisis.getTipo() == Token_lenguaje.TOKEN.MACROS)
            {
                //EXPRESIONES_LEXEMAS -> flecha EXPRESION
                String contenido = simbolo_preanalisis.getLexema().ToString();
                Macros.AddLast(new Expresion_Lexema(id_auxiliar, contenido));

                match(Token_lenguaje.TOKEN.MACROS);

                match(Token_lenguaje.TOKEN.PTOCOMA);

            }
            else
            {
                match(Token_lenguaje.TOKEN.MACROS);
                Error_fatal();
            }

            id_auxiliar = "";
        }

        //--------------------------------------------------------------------
        private void Error_fatal()
        {

           
            MessageBox.Show("Error faltal de sintaxis");
        }

        //------------------------------------------------------
        private void match(Token_lenguaje.TOKEN token_a_verificar)
        {
            try
            {

                //si hace match y no es el ultimo token ,pasa al siguiente
                if (token_a_verificar == simbolo_preanalisis.getTipo() && simbolo_preanalisis.getTipo() != Lista_Tokens.Last.Value.getTipo())
                {

                    numero_preanalisis++;
                    simbolo_preanalisis = Lista_Tokens.ElementAt(numero_preanalisis);

                }
                else if (simbolo_preanalisis.getTipo() == Lista_Tokens.Last.Value.getTipo())
                {

                    MessageBox.Show("Analisis Sintactico Concluido");
                }
                else
                {
           
                    MessageBox.Show("Analisis Sintactico Incorrecto Se esperaba : " + especificar_error(token_a_verificar));


                    analisisCorrecto = false;
                }
            }
            catch (Exception e)
            {
              
                MessageBox.Show("Error Fatal de sintaxis");

            }
        }

        //----------------------------------------------------------------
        private String especificar_error(Token_lenguaje.TOKEN tipo)
        {
            switch (tipo)
            {

                case TOKEN.LLAVE_A:
                    return "Llave de apertura";
                case TOKEN.LLAVE_C:
                    return "Llave de cierre";
                case TOKEN.COMILLA_DOBLE:
                    return "Comilla doble";
                case TOKEN.SIMBOLO_OR:
                    return "Simbolo OR |";
                case TOKEN.SIMBOLO_0_1vez:
                    return "Simbolo cerradura ?";
                case TOKEN.SIMBOLO_0_MAS:
                    return "Simbolo cerradura *";
                case TOKEN.SIMBOLO_1_MAS:
                    return "Simbolo cerradura +";
                case TOKEN.SIMBOLO_RANGO:
                    return "Simbolo de rango de una macro ~";
                case TOKEN.PTOCOMA:
                    return "Punto y coma";
                case TOKEN.DOSPUNTOS:
                    return "Dos puntos";
                case TOKEN.SIMBOLO_AND:
                    return "Simbolo AND .";
                case TOKEN.PORCENTAJES:
                    return "Simbolos de porcentaje doble";
                case TOKEN.FLECHA:
                    return "Simbolo de asignacion de expresion regular";
                case TOKEN.COMENAMUL:
                    return "Comentario multilinea apertura";
                case TOKEN.COMENSIMPLE:
                    return "Comentario simple";
                case TOKEN.CONJ:
                    return "Palabra reservada CONJ";
                case TOKEN.ASCIII:
                    return "Simbolos ASCCI comprendidos del 32-47, 58-64, 91-96, 123-125";
                case TOKEN.COMENCMUL:
                    return "Comentario multulinea cierre";
                case TOKEN.ID:
                    return "Identificador";
                case TOKEN.DIGITO:
                    return "Digito";
                case TOKEN.CADENA:
                    return "Cadena";
                case TOKEN.EXPRESION:
                    return "expresion regular";
                case TOKEN.MACROS:
                    return "Macro de rangos de caracteres ASCII 32 al 125";
                case TOKEN.ERROR:
                    return "Error Lexico, simbolo no admitido";
                case TOKEN.COMA:
                    return "Coma ,";
                case TOKEN.CONJUNTOFINITIO:
                    return "Conjunto finito de caracteres ASCCI 32 al 125";
                case TOKEN.CARACTERESPECIAL:
                    return "Caracter Especial";
                case TOKEN.CARACTERTODO:
                    return "Caracter especial excepto salto de linea";
                default:
                    return "error!";
            }

        }

    }
}
