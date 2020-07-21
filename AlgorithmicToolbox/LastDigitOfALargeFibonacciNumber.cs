using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicToolbox
{
    class LastDigitOfALargeFibonacciNumber
    {
        public static int FibonacciLastDigit(int n)
        {
            return FibonacciNumber.FibonacciFast(n) % 10;
        }
    }
}
