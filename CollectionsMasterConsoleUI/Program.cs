using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Arrays
            int[] intArray = new int[50];

            Populater(intArray, 0, 50);

            Console.WriteLine("First num of array.");
            Console.WriteLine(intArray[0]);

            Console.WriteLine("Last num of array.");
            Console.WriteLine(intArray[intArray.Length -1]);

            Console.WriteLine("All Numbers Original");
            NumberPrinter(intArray);
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers Reversed:");
            NumberPrinter(intArray.Reverse());
            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(intArray);
            NumberPrinter(intArray);
            Console.WriteLine("-------------------");

            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(intArray);
            

            Console.WriteLine("-------------------");
            Console.WriteLine("Sorted numbers:");
            Array.Sort(intArray);
            NumberPrinter(intArray);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            List<int> intList = new List<int>();

            Console.WriteLine($"Capacity: " + Convert.ToString(intList.Capacity));
          
            Populater(intList, 50, 0, 50);

            Console.WriteLine($"Capacity: " + Convert.ToString(intList.Capacity));
            
            Console.WriteLine("---------------------");

            Console.WriteLine("What number will you search for in the number list?");
            int userInput;
            while (int.TryParse(Console.ReadLine(), out userInput) == false)
            {
                Console.WriteLine("Bad number, try again.");
            }
            NumberChecker(intList, userInput);


            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            NumberPrinter(intList);
            Console.WriteLine("-------------------");

            Console.WriteLine("Evens Only!!");
            OddKiller(intList);
            NumberPrinter(intList);
            Console.WriteLine("------------------");

            Console.WriteLine("Sorted Evens!!");
            intList.Sort();
            NumberPrinter(intList);
            Console.WriteLine("------------------");

            int[] superCoolArray = intList.ToArray();

            intList.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            int oddsKilled = 0;
            int total = numberList.Count;
            for (int i = 0; i < total; i++)
            {
                if (numberList[i-oddsKilled] % 2 != 0)
                {
                    numberList.RemoveAt(i-oddsKilled);
                    oddsKilled++;
                }
            }
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            int sum = 0;
            foreach (int i in numberList)
            {
                if (i == searchNumber)
                {
                    sum += 1;
                }
            }
            Console.WriteLine($"There are {sum} instance(s) of the searched number {searchNumber}!");
        }

        private static void Populater(int[] intArray, int low, int high)
        {
            Random rng = new Random();
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = rng.Next(low, high+1);
            }
        }
        private static void Populater(List<int> numberList, int addAmount, int low, int high)
        {
            Random rng = new Random();
            for (int i = 0; i < addAmount; i++)
            {
                numberList.Add(rng.Next(low, high+1));
            }
        }

        private static void ReverseArray(int[] array)
        {
            int[] revArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                revArray[i] = array[array.Length - 1 - i];
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = revArray[i];
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
