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
            int sum_whitespace = 0;
            Console.WriteLine("Enter anyfing");
            do
            {
                my_key = Console.ReadKey(false);
                 sum_whitespace = (my_key.KeyChar == ' ')? sum_whitespace + 1 : sum_whitespace;
            } while (my_key.KeyChar != '.');
            Console.WriteLine("");
            Console.WriteLine("Amount whitespace = {0}", sum_whitespace);
        }
    }
}
