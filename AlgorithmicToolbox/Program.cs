using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;

namespace AlgorithmicToolbox
{
    public class Program
    {
        static void Main()
        {
            InputBinarySearch();
        }

        // Maximum pairwise product
        static void MPD()
        {
            //read qty elements of array
            var val = Convert.ToInt32(Console.ReadLine());
            //read from string, create and sort array
            var values = Console.ReadLine().Split(' ').Select(s => double.Parse(s)).OrderByDescending(el => el)
                .ToArray();
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

        static double FibonacciFast(int n)
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
                checked
                {
                    var c = (a + b); // compute next fibonacci number
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
                var c = (a + b) % 10; // compute next fibonacci number
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
            return Math.Round((double) a * (double) b / EuclidGCD(a, b));
        }

        /*
        Money Change 
        */
        static int MoneyChange(int m)
        {
            int[] denominationsCoins = new[] {1, 5, 10};
            int NumberOfCoins = 0;
            int i = denominationsCoins.Length - 1;
            while (i >= 0)
            {
                while (m >= denominationsCoins[i])
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
        */
        public static double GetOptimalValue(double capacity, List<int[]> valsWeights)
        {
            double value = 0;
            while (capacity > 0 && valsWeights.Count > 0)
            {
                if (capacity < valsWeights.Last()[1])
                {
                    value += Math.Round(capacity / valsWeights.Last()[1] * valsWeights.Last()[0], 4);
                }
                else
                {
                    value += valsWeights.Last()[0];
                }

                capacity -= valsWeights.Last()[1];
                valsWeights.RemoveAt(valsWeights.Count - 1);
            }

            return value;
        }

        static void InputForGetOptimalValue()
        {
            //Вводим входные параметры, первый эл массива - кол-во возможныйх вещей, второй эл массива - макс вместимость рюкзака.
            var init = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            //Create array for values and weights
            List<int[]> valsWeights = new List<int[]>();
            int[] values = new int[init[0]];
            int[] weights = new int[init[0]];
            var capacity = init[1];
            //Заполняем массивы для значений ценности и веса
            for (int i = 0; i < init[0]; i++)
            {
                var row = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                valsWeights.Add(new[] {row[0], row[1]});
            }

            CompareListItems cmpr = new CompareListItems();
            valsWeights.Sort(cmpr);
            Console.WriteLine(GetOptimalValue(capacity, valsWeights));
        }

        public class CompareListItems : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                // CompareTo() method 
                return (x[0] / (double) x[1]).CompareTo(y[0] / (double) y[1]);
            }
        }

        /*
        Implement Car Fueling algo
        */
        public static int ComputeMinRefills(int dist, int tank, int[] stops)
        {
            int numRefills = 0;
            int currentPosition = 0;
            while (currentPosition <= stops.Length - 2)
            {
                int lastPosition = currentPosition;
                while (currentPosition <= stops.Length - 2 && stops[currentPosition + 1] - stops[lastPosition] <= tank)
                {
                    currentPosition++;
                }

                if (currentPosition == lastPosition) return -1;
                if (currentPosition <= stops.Length - 2) numRefills++;
            }

            return numRefills;
        }

        public static void InputForComputeMinRefills()
        {
            //input values
            int dist = int.Parse(Console.ReadLine());
            int tank = int.Parse(Console.ReadLine());
            int valStops = int.Parse(Console.ReadLine());
            var tempStops = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            var stops = new int[tempStops.Length + 2];
            for (int i = 1; i < stops.Length - 1; i++)
            {
                stops[i] = tempStops[i - 1];
            }

            stops[stops.Length - 1] = dist;
            //sort stops arr;
            //Array.Sort(stops);
            Console.WriteLine(ComputeMinRefills(dist, tank, stops));
        }

        /*
        Binary search 
        */
        public static int BinarySearch(int[] arr, int value)
        {
            int l = 0;
            int r = arr.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (arr[m] == value) return m;
                if(arr[m] < value)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }
            return -1;
        }
        static void InputBinarySearch()
        {
            //Create array without first element
            var arr = Console.ReadLine().Split(' ').ToList().Select(s => int.Parse(s)).Where((x, idx) => idx > 0).ToArray();            
            var valuesForSearch = Console.ReadLine().Split(' ').Select(str => int.Parse(str)).Where((x, idx) => idx > 0);
            //Print solution
            var result = valuesForSearch.Select(el => BinarySearch(arr, el));
            Console.WriteLine(string.Join(" ", result));
        }
    }
}