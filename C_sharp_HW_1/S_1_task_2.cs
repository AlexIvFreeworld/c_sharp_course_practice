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
            decimal S = 10000;
            decimal P;
            int K = 0;
            Console.WriteLine("Enter rate from 0 to 25");
            P = Convert.ToDecimal(Console.ReadLine());
            if (P < 0 || P > 25)
            {
                Console.WriteLine("Incorrect rate");
                return;
            }
            while (S <= 11000)
            {
                S = S += (S * P / 100);
                K++;
            }
            Console.WriteLine("Deposit amount = {0}, amount months = {1}", S, K);
        }
    }
}
