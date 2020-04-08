using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Algorithms
{
    class Program
    {
        private static Stopwatch stopwatch;
        private static int count;

        static void Main(string[] args)
        {
            List<int> arr = new List<int>();
            int[] searchNum = { 575154, 182339, 17132, 773788, 296934, 991395, 303270, 45231, 580, 629822 };
            
            Menu(arr, searchNum);
        }

        public static void Menu(List<int> arr, int[] searchNum)
        {
            
            int choice = 0;
            

            while (choice != 8)
            {
                Console.WriteLine("Select from the Following Options" +
                "\n1. Import Elements to Array\n2. Display Original Array" +
                "\n3. Display Shell Sorted Array\n4. Display Insertion Sorted Array" +
                "\n5. Linear Search\n6. Binary Search\n7. Time Analysis\n8. Exit");

                Console.Write("Enter Choice:  ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        arr.Clear();
                        ImportArrayElements(arr);
                        break;
                    case 2:
                        Console.WriteLine("Original Array Elements :");
                        DisplayArray(arr);
                        Console.WriteLine("\n");

                        break;
                    case 3:
                        count = 0;
                        Algorithms.ShellSort(arr, ref count);
                        Console.WriteLine("\nShell Sorted Array Elements :");
                        DisplayArray(arr);
                        Console.WriteLine("\nShel Sort Looped: " + count + " times\n");
                        break;
                    case 4:
                        count = 0;
                        Algorithms.InsertionSort(arr, ref count);
                        Console.WriteLine("\nInsertion Sorted Array Elements :");
                        DisplayArray(arr);
                        Console.WriteLine("\nInsertion Sort Looped: " + count + " times\n");
                        break;
                    case 5:
                        SearchForLinear(arr, searchNum);
                        break;
                    case 6:
                        SearchForBinary(arr, searchNum);
                        break;
                    case 7:
                        count = 0;
                        stopwatch = new Stopwatch();
                        Algorithms.AnalysisLinear(arr, searchNum, stopwatch, ref count);
                        Console.WriteLine("\nLinear Search");
                        Console.WriteLine($"Looped {count} Times");
                        Console.WriteLine($"Elapsed Time is {stopwatch.Elapsed}\n");
                        stopwatch = new Stopwatch();
                        count = 0;
                        Algorithms.AnalysisBinary(arr, searchNum, stopwatch, ref count);
                        Console.WriteLine("Binary Search");
                        Console.WriteLine($"Looped {count} Times");
                        Console.WriteLine($"Elapsed Time is {stopwatch.Elapsed}");
                        Console.WriteLine();
                        break;
                    case 8:
                        break;
                }
            }
        }

        public static void ImportArrayElements(List<int> arr)
        {
            try
            {
                StreamReader reader = new StreamReader("unsorted_numbers.csv");
                //StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "\\unsorted_numbers.csv");

                while (!reader.EndOfStream)
                {
                    arr.Add(Convert.ToInt32(reader.ReadLine()));
                }
                Console.WriteLine("\nFile Imported Successfully\n");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

        }

        public static void SearchForBinary(List<int> arrShell, int[] searchNum)
        {
            Console.WriteLine();
            foreach (int num in searchNum)
            {
                int result = Algorithms.BinarySearch(arrShell, 0, arrShell.Count - 1, num, ref count);

                if (result == -1)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Search Unsuccessful");
                    Console.WriteLine($"Element {num} not present");
                }
                else
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Search successful");
                    Console.WriteLine($"Element {num} found at index {result}");
                }

            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Binary Search for Elements\n");
        }

        public static void SearchForLinear(List<int> arr, int[] searchNum)
        {
            Console.WriteLine();
            foreach (int num in searchNum)
            {
                if (Algorithms.LinearSearch(arr, num, ref count) > -1)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Search successful");
                    Console.WriteLine($"Element {num} found at index {Algorithms.LinearSearch(arr, num, ref count)}");
                }
                else
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Search Unsuccessful");
                    Console.WriteLine($"Element {num} Not Found");
                }
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Linear Search for Elements\n");
        }

        public static void DisplayArray(List<int> arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + "\t");
            }
        }
    }
}
