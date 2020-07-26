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
            List<int[]> valsWeights = new List<int[]>();
            valsWeights.Add(new[] {60, 20});
            valsWeights.Add(new[] {100, 50});
            valsWeights.Add(new[] {120, 30});
            Program.CompareListItems cmpr = new Program.CompareListItems();
            valsWeights.Sort(cmpr);
            double result = Program.GetOptimalValue(50, valsWeights);
            Assert.Equal(180.0000, result);
        }

        [Fact]
        public void TestsGetOptimalValue2()
        {
            List<int[]> valWeights = new List<int[]>();
            valWeights.Add(new[] {500, 30});
            double result = Program.GetOptimalValue(10, valWeights);
            Assert.Equal(Math.Round(((double) 10 / 30 * 500), 4), result);
        }

        [Fact]
        public void TestsGetOptimalValue3()
        {
            List<int[]> valsWeights = new List<int[]>();
            valsWeights.Add(new[] {60, 20});
            valsWeights.Add(new[] {100, 50});
            valsWeights.Add(new[] {240, 80});
            Program.CompareListItems cmpr = new Program.CompareListItems();
            valsWeights.Sort(cmpr);
            double result = Program.GetOptimalValue(50, valsWeights);
            Assert.NotEqual(180.0000, result);
        }
    }
}