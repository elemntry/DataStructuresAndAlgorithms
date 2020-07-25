using System;
using System.Collections.Generic;
using AlgorithmicToolbox;
using Xunit;

namespace Tests
{
    public class TestsGetOptimalValue
    {
        [Fact]
        public void TestsGetOptimalValue1()
        {
            List<int[]> valWeights = new List<int[]>();
            valWeights.Add(new[] {60, 20});
            valWeights.Add(new[] {100, 50});
            valWeights.Add(new[] {120, 30});
            double result = Program.GetOptimalValue(50, valWeights);
            Assert.Equal(180.0000, result);
        }

        [Fact]
        public void TestsGetOptimalValue2()
        {
            List<int[]> valWeights = new List<int[]>();
            valWeights.Add(new[] {500, 30});
            double result = Program.GetOptimalValue(10, valWeights);
            Assert.Equal(166.6667, result);
        }
    }
}