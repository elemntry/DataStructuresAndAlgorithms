using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmicToolbox;
using Xunit;

namespace Tests
{
    public class TestsBinarySearch
    {
        [Fact]
        public void TestsBinarySearch1()
        {
            int[] arr = new int[] { 1, 5, 8, 12, 13 };
            
            int[] valuesForSearch = new int[] {8, 1, 23, 1, 11};
            int[] result = new int[5];
            for (int i = 0; i < valuesForSearch.Length; i++)
            {
                result[i] = Program.BinarySearch(arr, valuesForSearch[i]);
            }
            Assert.Equal("2 0 -1 0 -1", string.Join(" ", result));
        }
        [Fact]
        public void TestsBinarySearch2()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };

            int[] valuesForSearch = new int[] { 1, 2, 3, 4, 5 };
            int[] result = new int[5];
            for (int i = 0; i < valuesForSearch.Length; i++)
            {
                result[i] = Program.BinarySearch(arr, valuesForSearch[i]);
            }
            Assert.Equal("0 1 2 3 4", string.Join(" ", result));
        }
    }
}
