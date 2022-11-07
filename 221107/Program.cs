using System;
using System.Linq;


namespace _221107
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Q1
            if (false)
            {
                int num = int.Parse(Console.ReadLine());
                int total = int.Parse(Console.ReadLine());

                int sum = Enumerable.Range(1, num).Sum();
                int offset = (total - sum) / num;
                Console.WriteLine(Enumerable.Range(1 + offset, num).ToArray());
            }

            // Q2
            if (false)
            {
                int[] array = new int[] { };
                int n = 0;
                array.Where(x => x == n).Count();
                /*var answer = from a in array
                             where a == n
                             select a;
                answer.Count();*/
            }


            





        }
    }
}
