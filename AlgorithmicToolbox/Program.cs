﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AlgorithmicToolbox
{
    public class Program
    {
        static void Main()
        {
            InputDPPrimitiveCalculator();
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
                if (arr[m] < value)
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
            var arr = Console.ReadLine().Split(' ').ToList().Select(s => int.Parse(s)).Where((x, idx) => idx > 0)
                .ToArray();
            var valuesForSearch =
                Console.ReadLine().Split(' ').Select(str => int.Parse(str)).Where((x, idx) => idx > 0);
            //Print solution
            var result = valuesForSearch.Select(el => BinarySearch(arr, el));
            Console.WriteLine(string.Join(" ", result));
        }

        /*
        Majority Element ver.1
        */
        public static int MajorityElement(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int majority = arr.Length / 2;

            //Stores the number of occcurences of each item in the passed array in a dictionary
            foreach (int i in arr)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i]++;
                    //Checks if element just added is the majority element
                    if (dict[i] > majority)
                        return 1;
                }
                else dict.Add(i, 1);
            }

            return 0;
        }

        static void InputMajorityElement()
        {
            int arrLength = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            Console.WriteLine(MajorityElement(arr));
        }

        /*
       Majority Element ver.2
       Quick sort and n
       */
        public static int MajorityElementVer2(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
            int count = 1;
            int temp = arr[0];
            int m = arr.Length / 2;
            for (int i = 1; i < arr.Length; i++)
            {
                if (temp == arr[i])
                {
                    count++;
                }
                else
                {
                    count = 1;
                    temp = arr[i];
                }

                if (count > m)
                {
                    return 1;
                }
            }

            return 0;
        }

        public static void QuickSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = Partition(arr, l, r);

                // Recursively sort elements before 
                // partition and after partition 
                QuickSort(arr, l, pi - 1);
                QuickSort(arr, pi + 1, r);
            }
        }

        static int Partition(int[] arr, int l, int r)
        {
            int pivot = arr[r];

            // index of smaller element 
            int i = (l - 1);
            for (int j = l; j < r; j++)
            {
                // If current element is smaller  
                // than the pivot 
                if (arr[j] < pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[r] (or pivot) 
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[r];
            arr[r] = temp1;

            return i + 1;
        }

        /*
        Majority Element ver.3
        unfinished
        */
        public static int MajorityElementVariant3(int[] arr)
        {
            return MajorityElementVariant3Rec(arr, 0, arr.Length - 1);
        }

        static int MajorityElementVariant3Rec(int[] arr, int lo, int hi)
        {
            if (lo == hi) return arr[lo];
            int mid = (hi - lo) / 2 + lo;
            int left = MajorityElementVariant3Rec(arr, lo, mid);
            int right = MajorityElementVariant3Rec(arr, mid + 1, hi);
            if (left == right)
            {
                return left;
            }

            int leftCount = CountInRange(arr, left, lo, hi);
            int rightCount = CountInRange(arr, right, lo, hi);

            return leftCount > rightCount ? left : right;
        }

        static int CountInRange(int[] arr, int num, int lo, int hi)
        {
            int count = 0;
            for (int i = lo; i <= hi; i++)
            {
                if (arr[i] == num)
                {
                    count++;
                }
            }

            return count;
        }
        /*
        Money Change Again ver.1
        greedy algo
        */
        static void InputGreedyMoneyChangeAgain()
        {
            int n = int.Parse(Console.ReadLine());
            int[] coins = { 1, 3, 4 };
            List<int> result = GreedyMoneyChangeAgain(n, coins);
            result.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
            Console.WriteLine(result.Count);
        }
        public static List<int> GreedyMoneyChangeAgain(int n, int[] coins)
        {
            
            List<int> change = new List<int>();
            while (n > 0) {
                int coin = 0;
                for(int i = coins.Length - 1; i >= 0; i--)
                {
                    if (n >= coins[i]) 
                    {
                        coin = coins[i];
                        break;
                    }
                }
                change.Add(coin);
                n -= coin;
            }
            return change;
        }
        /*
        Money Change Again ver.2
        recursive algo
        */
        static void InputRecursiveMoneyChangeAgain()
        {
            int n = int.Parse(Console.ReadLine());
            int[] coins = { 1, 3, 4 };                        
            Console.WriteLine(RecursiveMoneyChangeAgain(n, coins));
            
        }
        public static int RecursiveMoneyChangeAgain(int n, int[] coins)
        {
            if (n == 0) return 0;
            int minNumCoins = int.MaxValue;
            for (int i = 0; i < coins.Length; i++)
            {
                if (n >= coins[i])
                {
                    int numCoins = RecursiveMoneyChangeAgain(n - coins[i], coins);
                    if (numCoins + 1 < minNumCoins)
                    {
                        minNumCoins = numCoins + 1;
                    }
                }
            }
            return minNumCoins;
        }
        /*
        Money Change Again ver.3
        dynamic algo
        */
        static void InputDynamicProgrammingMoneyChangeAgain()
        {
            int n = int.Parse(Console.ReadLine());
            int[] coins = { 1, 3, 4 };
            Console.WriteLine(DynamicProgrammingMoneyChangeAgain(n, coins));
        }

        public static int DynamicProgrammingMoneyChangeAgain(int n, int[] coins)
        {
            int[] minNumCoins = new int[n+1];
            for (int m = 1; m <= n; m++)
            {
                minNumCoins[m] = int.MaxValue;
                for (int i = 0; i < coins.Length; i++)
                {
                    if (m >= coins[i])
                    {
                        int numCoins = minNumCoins[m - coins[i]] + 1;
                        if (numCoins < minNumCoins[m]) minNumCoins[m] = numCoins;
                    }
                }
            }
            return minNumCoins[n];
        }

        /*
        Primitive calculator ver.1
        dynamic algo
        */
        //static void InputDPPrimitiveCalculator()
        //{
        //    int n = int.Parse(Console.ReadLine());
        //    DPPrimitiveCalculator(n);
        //}
        //public static void DPPrimitiveCalculator(int n)
        //{
        //    int[] ops = new int[n + 1];
        //    ops[1] = 0;

        //    int min;
        //    for (int i = 2; i < n+1; i++)
        //    {
        //        min = ops[i - 1] + 1;
        //        if (i % 2 == 0) min = Math.Min(min, ops[i / 2] + 1);
        //        if (i % 3 == 0) min = Math.Min(min, ops[i / 3] + 1);
        //        ops[i] = min;
        //    }

        //    List<int> result = new List<int>();
        //    { 
        //    int i = n;
        //    while (i > 1)
        //    {
        //        if (ops[i] == ops[i - 1] + 1)
        //        {
        //            result.Add(1);
        //            i--;
        //            continue;
        //        }
        //        if (i%2 ==0 && ops[i] == ops[i/2] + 1)
        //        {
        //            result.Add(2);
        //            continue;
        //        }

        //        result.Add(3);
        //        i = i / 3;
        //    }
        //    }
        //    Console.WriteLine(ops[n]);
        //    result.ForEach(el => Console.Write(el));
        //}

        static void InputGreedyPrimitiveCalculator()
        {
            int n = int.Parse(Console.ReadLine());
            GreedyPrimitiveCalculator(n);
        }
        public static int GreedyPrimitiveCalculator(int n)
        {
            List<int> result = new List<int>();
            while(n >= 1)
            {

                if (n % 3 == 0)
                {
                    n = n / 3;
                }
                else if (n % 2 == 0) 
                { 
                    n = n / 2; 
                }
                else n = n - 1;
                result.Add(n);
            }
            return result.Count - 1;
        }
        //don't work

        static void InputDPPrimitiveCalculator()
        {
            int n = int.Parse(Console.ReadLine());
            DPPrimitiveCalculator(n);
        }
        public static int DPPrimitiveCalculator(int n)
        {
            List<int> result = new List<int>();
            int[] arr = new int[n + 1];
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = arr[i - 1] + 1;
                if (i % 2 == 0) arr[i] = Math.Min(1 + arr[i / 2], arr[i]);
                if (i % 3 == 0) arr[i] = Math.Min(1 + arr[i / 3], arr[i]);
            }
            for (int i = n; i > 1; )
            {
                result.Add(i);
                if (arr[i - 1] == arr[i] - 1) i = i - 1;
                else if (i % 2 == 0 && (arr[i / 2] == arr[i] - 1)) i = i / 2;
                else if (i % 3 == 0 && (arr[i / 3] == arr[i] - 1)) i = i / 3;

            }
            result.Add(1);
            return result.Count;
        }
    }
}