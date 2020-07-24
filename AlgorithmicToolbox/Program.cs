using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmicToolbox
{
    class Program
    {
        static void Main()
        {

            InputForGetOptimalValue();
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
        /*
        Fibonacci numbers
        */
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
            // implementation with array
            // double[] fibArr = new double[n+1];
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
        /*
        Last digit of a large fibonacci number
        */
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
        /*
        Greatest common divisor
        */
        static int NaiveGCD(int a, int b)
        {
            int gcd = 1;
            int max = Math.Max(a, b);
            for (int d = 2; d <= max; d++)
            {
                if (a % d == 0 && b % d == 0) gcd = d;
            }
            return gcd;
        }
        static int EuclidGCD(int a, int b)
        {
            int gcd = 1;
            if (a == 0) return b;
            if (b == 0) return a;
            if (a >= b) return EuclidGCD(a % b, b);
            if (b >= a) return EuclidGCD(a, b % a);
            return gcd;
        }
        /*
        Least Common Multiple 
        */
        static double LCM(int a, int b)
        {
            return Math.Round((double)a * (double)b / EuclidGCD(a, b));
        }
        /*
        Money Change 
        */
        static int MoneyChange(int m)
        {
            int[] denominationsCoins = new[] { 1, 5, 10 };
            int NumberOfCoins = 0;
            int i = denominationsCoins.Length - 1;
            while(i >= 0)
            {
                while(m >= denominationsCoins[i])
                {
                    m -= denominationsCoins[i];                    
                    NumberOfCoins++;
                }
                i--;
            }

            return NumberOfCoins;
        }
        /*
        Maximum Value of the Loot 
        //WORK IN PROGRESS
        // DO: sort array bt val/weight before start
        */
        static double getOptimalValue(double capacity, int[] values, int[] weights)
        {
            double value = 0;
            double[] divideValByWeight = new double[values.Length];
            //fill array
            for (int i = 0; i < values.Length; i++)
            {
                divideValByWeight[i] = values[i] / weights[i];
            }
            if (values.Length == 1) return capacity > values[0] ? values[0] : Math.Round(capacity / weights[0] * values[0], 4);
            while (capacity > 0)
            {
                double max = divideValByWeight.Max();
                int p = Array.IndexOf(divideValByWeight, max);
                if (capacity < weights[p])
                {
                    divideValByWeight[p] = 0;
                }
                else
                {
                capacity -= weights[p];
                value += values[p];
                }
            }
            return value;
        }
        static void InputForGetOptimalValue()
        {
            //Вводим входные параметры, первый эл массива - кол-во возможныйх вещей, второй эл массива - макс вместимость рюкзака.
            var init = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray(); 
            //Create array for values and weights
            int[] values = new int[init[0]];
            int[] weights = new int[init[0]];
            var capacity = init[1];
            //Заполняем массивы для значений ценности и веса
            for (int i = 0; i < init[0]; i++)
            {
                var row = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                values[i] = row[0];
                weights[i] = row[1];
            }
            Console.WriteLine(getOptimalValue(capacity, values, weights));
        }


    }
}
