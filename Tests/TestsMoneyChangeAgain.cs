using AlgorithmicToolbox;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TestsMoneyChangeAgain
    {
        [Fact]
        public void TestsGreedyMoneyChangeAgain1()
        {
            int n = 2;
            int[] coins = { 1, 3, 4 };
            int result = Program.GreedyMoneyChangeAgain(n, coins).Count;
            Assert.Equal("2", result.ToString());
        }
        [Fact]
        public void TestsGreedyMoneyChangeAgain2()
        {
            int n = 34;
            int[] coins = { 1, 3, 4 };
            int result = Program.GreedyMoneyChangeAgain(n, coins).Count;
            Assert.Equal("10", result.ToString());
        }
        [Fact]
        public void TestsRecursiveMoneyChangeAgain1()
        {
            int n = 2;
            int[] coins = { 1, 3, 4 };
            int result = Program.RecursiveMoneyChangeAgain(n, coins);
            Assert.Equal("2", result.ToString());
        }
        [Fact]
        public void TestsRecursiveMoneyChangeAgain2()
        {
            int n = 34;
            int[] coins = { 1, 3, 4 };
            int result = Program.RecursiveMoneyChangeAgain(n, coins);
            Assert.Equal("9", result.ToString());
        }
        [Fact]
        public void TestsDynamicMoneyChangeAgain1()
        {
            int n = 2;
            int[] coins = { 1, 3, 4 };
            int result = Program.DynamicProgrammingMoneyChangeAgain(n, coins);
            Assert.Equal("2", result.ToString());
        }
        [Fact]
        public void TestsDynamicMoneyChangeAgain2()
        {
            int n = 34;
            int[] coins = { 1, 3, 4 };
            int result = Program.DynamicProgrammingMoneyChangeAgain(n, coins);
            Assert.Equal("9", result.ToString());
        }
    }
}
