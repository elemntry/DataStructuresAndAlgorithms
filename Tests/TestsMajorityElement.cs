using AlgorithmicToolbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests
{
    public class TestsMajorityElement
    {
        [Fact]
        public void TestsMajorityElement1()
        {
            int[] arr = new int[] {1, 1, 8, 12, 1};

            int result = Program.MajorityElement(arr);
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestsMajorityElement2()
        {
            int[] arr = new int[] {1, 5, 8, 12, 1};

            int result = Program.MajorityElement(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestsMajorityElement3()
        {
            int[] arr = new int[]
            {
                1, 2, 60, 8, 12, 12, 12, 12, 12, 1, 2, 60, 8, 12, 12, 12, 12, 12, 1, 2, 60, 8, 12, 12, 12, 12, 12, 1, 2,
                60, 8, 12, 12, 12, 12, 12, 1, 2, 60, 8, 12, 12, 12, 12, 12, 1, 2, 60, 8, 12, 12, 12, 12, 12, 1, 2, 60,
                8, 12, 12, 12, 12, 12, 1, 2, 60, 8, 12, 12, 12, 12, 12, 1, 2, 60, 8, 12, 12, 12, 12, 12, 1, 2, 60, 8,
                12, 12, 12, 12, 12, 1, 2, 60, 8, 12, 12, 12, 12, 12, 1, 2, 60, 8, 12, 12, 12, 12, 12, 1, 2, 60, 8, 12,
                12, 12, 12, 12, 1, 2, 60, 8, 12, 12, 12, 12, 12
            };

            int result = Program.MajorityElement(arr);
            Assert.Equal(1, result);
        }
    }
}