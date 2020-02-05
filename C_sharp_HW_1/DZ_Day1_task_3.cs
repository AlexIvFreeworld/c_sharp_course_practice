using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            ConsoleKeyInfo my_key;
            Console.WriteLine("Enter anyfing, for exit press key <~>");
            int conv_int;
            do
            {
                my_key = Console.ReadKey(true);
                if (char.IsLower(my_key.KeyChar))
                {
                    conv_int = (int)my_key.KeyChar - 32;
                    Console.Write((char)conv_int);
                }else if (char.IsUpper(my_key.KeyChar))
                {
                    conv_int = (int)my_key.KeyChar + 32;
                    Console.Write((char)conv_int);
                }
            } while (my_key.KeyChar != '~');
            Console.WriteLine("");
        }
    }
}
