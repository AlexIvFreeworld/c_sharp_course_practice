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
            string num;
            string part_1, part_2;
            int sum_part_1 = 0, sum_part_2 = 0;
            Console.WriteLine("Enter six digits number :");
            num = Console.ReadLine();
            part_1 = num.Substring(0, 3);
            part_2 = num.Substring(3, 3);
            Console.WriteLine("part_1 = {0} part_2 = {1}", part_1, part_2);
            for (int i = 0; i < 3; i++)
            {
                //	Console.WriteLine(part_1[i]);
                //	Console.WriteLine(part_1[i].GetType());
                sum_part_1 += Int32.Parse(part_1[i].ToString());
                sum_part_2 += Int32.Parse(part_2[i].ToString());
                //	Console.WriteLine(sum_part_1);
                //	Console.WriteLine(sum_part_1.GetType());

            }
            Console.WriteLine("sum_part_1 = {0} sum_part_2 = {1} ", sum_part_1, sum_part_2);
            if (sum_part_1 == sum_part_2)
            {
                Console.WriteLine("You have a happy ticket!");
            }
            else
            {
                Console.WriteLine("You have not a happy ticket....");
            }
        }
    }
}
