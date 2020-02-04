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
            int N = 345;
            string str = N.ToString();
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(str);
            Console.WriteLine(arr);
        }
    }
}
