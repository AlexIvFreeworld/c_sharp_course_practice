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
            int A, B, C, Sc, Sres, Na, Nb, N;
            Console.WriteLine("Enter A: ");
            A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter B: ");
            B = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter C: ");
            C = Convert.ToInt32(Console.ReadLine());
            //найти количество квадратов по стороне A -Na 
            Na = A / C;
            //найти количество квадратов по стороне B - Nb
            Nb = B / C;
            //Если Na or Nb < 1 вывести ответ N = 0
            if (Na < 1 || Nb < 1)
            {
                Console.WriteLine("Amount squares = 0, the residue of place = {0}", A * B);
                return;
            }
            //Найти количество квадратов в прямоугольнике N = Na*Nb
            N = Na * Nb;
            //найти площадь квадратов Sc = N * C * C
            Sc = N * C * C;
            //найти оставшуюся площадь Sres = Sab - Sc
            Sres = A * B - Sc;
            Console.WriteLine("Amount squares = {0}, the residue of place = {1}", N, Sres);
        }
    }
}
