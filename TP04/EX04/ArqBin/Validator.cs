using System;

namespace Compilador
{
    class numerosCaracteres
    {
        public bool Validate(char value)
        {
            bool achou = Char.IsNumber(value);
            if (achou) { return true; }
            return false;
        }
    }

    class stringCaracteres
    {
        public static bool Validate(char value)
        {
            bool achou = Char.IsLetter(value);
            if (achou) { return true; }
            return false;
        }
    }


    class BaseHandler
    {
        public char value { get; private set; }
        public string type { get; private set; }

        public bool valid { get; private set; }
        public void main(char value)
        {
            this.valid = false;
            this.value = value;

            if (Char.IsLetter(value))
            {
                this.valid = true;
                this.type = "string";
            }

            if (Char.IsNumber(value))
            {
                this.valid = true;
                this.type = "Int";
            }
        }
    }
    class IgnoreCaracteres
    {
        public bool Ignore { get => true; }
        public char[] Caracter => new char[] { '\n', '\r' };

        public bool Validate(char value)
        {
            bool achou = utils.Helpers.searchInArray(value, Caracter);
            if (achou) { return Ignore; }
            return !Ignore;
        }
    }

}
