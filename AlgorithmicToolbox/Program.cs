using System;
using System.Linq;

namespace AlgorithmicToolbox
{
    class Program
    {
        static void Main()
        {
            var val = Convert.ToInt32(Console.ReadLine());
            var values = Console.ReadLine().Split(" ").Select(s => double.Parse(s)).OrderByDescending(el => el).ToArray();
            //double result = 0;
            //if (values.Length > 1) result = values[0] * values[1];
            //for (int i = 2; i < values.Length; i++)
            //{
            //    for (int j = i + 1; j < values.Length; j++)
            //    {
            //        if (result % values[i] != 0) result *= values[j];
            //    }
            //}
            Console.WriteLine(values[0]*values[1]);
        }
    }
}
