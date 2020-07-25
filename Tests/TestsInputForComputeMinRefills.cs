using System;
using Xunit;

namespace Tests
{
    public class TestsInputForComputeMinRefills
    {
        [Fact]
        public void TestsInputForComputeMinRefills1()
        {
            var result = AlgorithmicToolbox.Program.ComputeMinRefills(950, 400, new int[] {0, 200, 375, 550, 750, 950});
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestsInputForComputeMinRefills2()
        {
            var result = AlgorithmicToolbox.Program.ComputeMinRefills(10, 3, new int[] {0, 1, 2, 5, 9, 10});
            Assert.Equal(-1, result);
        }

        [Fact]
        public void TestsInputForComputeMinRefills3()
        {
            var result = AlgorithmicToolbox.Program.ComputeMinRefills(700, 200, new int[] {0, 100, 200, 300, 400, 700});
            Assert.Equal(-1, result);
        }
    }
}