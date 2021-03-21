
using System.Collections.Generic;
using System;

namespace Compilador
{
    class Compilando
    {
        static int linha = 1;
        static List<string> resultado = new List<string>();
        static bool status = false;
        static string texto = "";
        static string tipo = null;
        static string old_tipo = "";

        public void validate(char value)
        {
            char recebendo = value;
            if (value == '\n' || value == '\r')
            {
                if (texto != "")
                {
                    resultado.Add("Linha " + getLinha() + "(" + tipo + ")" + "   => " + texto + "\n");
                    texto = "";
                }
                status = false;
                linha++;
                return;
            }
            if (value == ' ')
            {
                if (texto != "")
                {
                    resultado.Add("Linha " + getLinha() + "(" + tipo + ")" + "   => " + texto + "\n");
                    texto = "";
                }
                status = false;
                return;
            }


            if (Char.IsLetter(value))
            {
                tipo = "String";
                texto += value;

                if (tipo == old_tipo) {
                    status = true;
                }
                else if(old_tipo == "" || old_tipo == null)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            else if (Char.IsNumber(value))
            {
                tipo = "Int";
                texto += value;
                if (tipo == old_tipo)
                {
                    status = true;
                }
                else if (old_tipo == "" || old_tipo == null)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            else { 
                status = false;
            }

            if (!status)
            {
                if (texto != "")
                {
                    resultado.Add("Linha " + getLinha() + "(" + old_tipo + ")" + "   => " + texto + "\n");
                    texto = "";
                }
            }
            old_tipo = tipo;
        }

        public int getLinha()
        {
            return ((int)(linha / 2)) + 1;
        }

        public List<string> getResultado()
        {
            if (texto != "")
            {
                resultado.Add("Linha " + getLinha() + "          => " + texto + "\n");
                texto = "";
            }
            return resultado;
        }
    }
}
