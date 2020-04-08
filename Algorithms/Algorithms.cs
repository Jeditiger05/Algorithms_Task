using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Algorithms
{
    class Algorithms
    {
        public static void AnalysisLinear(List<int> arr, int[] searchNum, Stopwatch stop, ref int count)
        {
            for (int i = 0; i < 1; i++)
            {
                stop.Start();
                foreach (int num in searchNum)
                {
                    LinearSearch(arr, num, ref count);
                }
                stop.Stop();
            }
        }

        public static void AnalysisBinary(List<int> arr, int[] searchNum, Stopwatch stop, ref int count)
        {
            for (int i = 0; i < 1; i++)
            {
                stop.Start();
                foreach (int num in searchNum)
                {
                    BinarySearch(arr, 0, arr.Count - 1, num, ref count);
                }
                stop.Stop();
            }
        }

        public static int BinarySearch(List<int> arr, int lower, int upper, int element, ref int count)
        {
            count++;
            if (upper >= lower)
            {
                int mid = lower + (upper - lower) / 2;

                if (arr[mid] == element)
                {
                    return mid;
                }

                if (arr[mid] > element)
                {
                    return BinarySearch(arr, lower, mid - 1, element, ref count);
                }

                return BinarySearch(arr, mid + 1, upper, element, ref count);
            }

            return -1;
        }

        public static int LinearSearch(List<int> arr, int num, ref int count)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                count++;
                if (arr[i] == num)
                {
                    return i;
                }
            }

            return -1;
        }

        public static void ShellSort(List<int> arr, ref int count)
        {
            int reduceGap = 2;

            for (int gap = arr.Count / reduceGap; gap > 0; gap /= reduceGap)
            {
                count++;
                for (int i = gap; i < arr.Count; i++)
                {
                    count++;
                    int temp = arr[i];

                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        count++;
                        arr[j] = arr[j - gap];
                    }

                    arr[j] = temp;
                }
            }
        }

        public static void InsertionSort(List<int> arr, ref int count)
        {
            for (int i = 1; i < arr.Count; ++i)
            {
                count++;
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    count++;
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
    }
}