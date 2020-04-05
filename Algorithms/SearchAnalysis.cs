using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Algorithms
{
    class SearchAnalysis
    {
        public static void AnalysisLinear(List<int> arr, int[] searchNum, Stopwatch stop, ref int count)
        {
            for (int i = 0; i < 1; i++)
            {
                stop.Start();
                SearchForLinearAnalysis(arr, searchNum, ref count);
                stop.Stop();
            }
        }

        public static void AnalysisBinary(List<int> arr, int[] searchNum, Stopwatch stop, ref int count)
        {
            for (int i = 0; i < 1; i++)
            {
                stop.Start();
                SearchForBinaryAnalysis(arr, searchNum, ref count);
                stop.Stop();
            }
        }

        public static void SearchForBinaryAnalysis(List<int> arrShell, int[] searchNum, ref int count)
        {
            foreach (int num in searchNum)
            {
                Algorithms.BinarySearch(arrShell, 0, arrShell.Count - 1, num, ref count);
            }
        }

        public static void SearchForLinearAnalysis(List<int> arr, int[] searchNum, ref int count)
        {
            foreach (int num in searchNum)
            {
                Algorithms.LinearSearch(arr, num, ref count);
            }
        }
    }
}
