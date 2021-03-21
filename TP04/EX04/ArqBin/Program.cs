using System.Collections.Generic;
using System.IO;

namespace Compilador
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream infile, outfile;
            int tam;
            char caracter;
            Compilando compile = new Compilando();

            infile = new FileStream("teste.txt",
                                               FileMode.Open,
                                               FileAccess.Read);
            outfile = new FileStream("teste2.txt",
                                               FileMode.Create,
                                               FileAccess.Write);

            tam = (int)infile.Length;
            for (int i = 0; i < tam; ++i)
            {
                caracter = (char)infile.ReadByte();
                //System.Console.WriteLine(caracter);
                compile.validate(caracter);
            }

            printArrayString(outfile, compile.getResultado());

            infile.Close();
            outfile.Close();
            //System.Console.ReadLine();
        }

        static void printArrayString(FileStream file, List<string> Frase)
        {
            foreach (string frase in Frase)
            {
                char[] Bytes = frase.ToString().ToCharArray();
                foreach (char teste in Bytes)
                {
                    file.WriteByte((byte)teste);
                }
            }
        }
      
    }
}
