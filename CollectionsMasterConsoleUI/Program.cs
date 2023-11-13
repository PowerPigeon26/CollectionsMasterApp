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
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            int[] intArray = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(intArray, 0, 50);

            //TODO: Print the first number of the array
            Console.WriteLine("First num of array.");
            Console.WriteLine(intArray[0]);

            //TODO: Print the last number of the array
            Console.WriteLine("Last num of array.");
            Console.WriteLine(intArray[intArray.Length -1]);

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(intArray);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");
            NumberPrinter(intArray.Reverse());   //does NOT change intArray
            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(intArray);   //actually reverses intArray
            NumberPrinter(intArray);
            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(intArray); //does NOT actually change given array, just prints expected output
            

            Console.WriteLine("-------------------");
            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(intArray);  //seems to actually change the array, neato
            NumberPrinter(intArray);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            List<int> intList = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine($"Capacity: " + Convert.ToString(intList.Capacity));

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(intList, 50, 0, 50);
            //NumberPrinter(intList); //did this early for testing purposes
            //TODO: Print the new capacity
            Console.WriteLine($"Capacity: " + Convert.ToString(intList.Capacity));
            
            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
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


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(intList);
            NumberPrinter(intList);
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            intList.Sort();
            NumberPrinter(intList);
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            int[] superCoolArray = intList.ToArray();

            //TODO: Clear the list
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
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
