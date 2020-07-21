using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmicToolbox
{
    class MaximumPairwiseProduct
    {
        public static void MPD()
        {
            //read qty elements of array
            var val = Convert.ToInt32(Console.ReadLine());
            //read from string, create and sort array
            var values = Console.ReadLine().Split(' ').Select(s => double.Parse(s)).OrderByDescending(el => el).ToArray();
            Console.WriteLine(values[0] * values[1]);
        }
    }
}
