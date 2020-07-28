using AlgorithmicToolbox;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class TestsQuickSort
    {
        [Fact]
        public void TestsQuickSort1()
        {
            int[] arr = new int[] { 1, 5, 8, 12, 13 };

            Program.QuickSort(arr, 0, arr.Length - 1);
            Assert.Equal("1, 5, 8, 12, 13", string.Join(", ", arr));
        }
        [Fact]
        public void TestsQuickSort2()
        {
            int[] arr = new int[] { 12, 13, 8, 1, 5 };

            Program.QuickSort(arr, 0, arr.Length - 1);
            Assert.Equal("1, 5, 8, 12, 13", string.Join(", ", arr));
        }
    }
}
