using System;
using System.Linq;

namespace AlgorithmicToolbox
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(FibonacciLastDigit(Convert.ToInt32(Console.ReadLine())));
        }
        // Maximum pairwise product
        static void MPD()
        {
            //read qty elements of array
            var val = Convert.ToInt32(Console.ReadLine());
            //read from string, create and sort array
            var values = Console.ReadLine().Split(' ').Select(s => double.Parse(s)).OrderByDescending(el => el).ToArray();
            Console.WriteLine(values[0] * values[1]);
        }
        // Fibonacci numbers
        static int FibonacciNaive(int n)
        {
            if (n <= 1) return n;
            return FibonacciNaive(n - 1) + FibonacciNaive(n - 2);
        }

        static double FibonacciFast (int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            /*// double[] fibArr = new double[n+1];
            // fibArr[0] = 0;
            // fibArr[1] = 1;
            // for (int i = 2; i <= n; i++)
            //     checked
            // {
            //     fibArr[i] = fibArr[i - 2] + fibArr[i - 1];
            // }
            // return fibArr[^1];*/
            double a = 1;
            double b = 1;
            for (var i = 3; i <= n; i++)
            checked {
                var c = (a + b);// compute next fibonacci number
                a = b;
                b = c;
            }
            return b;
        }
        // Last digit of a large fibonacci number
        static int FibonacciLastDigit(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            int a = 1;
            int b = 1;
            for (var i = 3; i <= n; i++)
            {
                    var c = (a + b) % 10;// compute next fibonacci number
                    a = b;
                    b = c;
            }
            return b;
        }
        // Greatest common divisor
        private int GCD(int a, int b)
        {
            return 1;
        }
    }
}
