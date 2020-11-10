using AlgorithmicToolbox;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Tests
{
    public class TestsPrimitiveCalculator
    {
        [Fact]
        public void TestGreedyPrimitiveCalculator1()
        {
            int n = 1;
            Assert.Equal(0, Program.GreedyPrimitiveCalculator(n));

        }
        [Fact]
        public void TestGreedyPrimitiveCalculator2()
        {
            int n = 5;
            Assert.Equal(3, Program.GreedyPrimitiveCalculator(n));

        }
        [Fact]
        public void TestGreedyPrimitiveCalculator3()
        {
            int n = 96234;
            Assert.Equal(14, Program.GreedyPrimitiveCalculator(n)); // not be equal, because algo isn't optimal

        }

    }
}
