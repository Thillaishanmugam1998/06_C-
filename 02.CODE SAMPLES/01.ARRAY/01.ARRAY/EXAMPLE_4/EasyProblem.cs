using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMPLE_4
{
    class EasyProblem
    {
        #region Problem:1
        public void Problem_1()
        {
            //Find the Maximum Element: Write a program to find the largest element in a given integer array.
            //Input:[10, 5, 20, 8, 15]
            //Output: 20

            int[] numbers = { 10, 40, 55, -9, 99, 97, 100 };
            int largest = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (largest < numbers[i])
                {
                    largest = numbers[i];
                }
            }
            Console.WriteLine($"Largest value in array: {largest}");
        }
        #endregion

        #region Problem:2
        public void Problem_2()
        {
            //Reverse an Array: Write a program to reverse the elements of an integer array.
            //Try to do this in-place(without creating a new array).
            //Input: [1, 2, 3, 4, 5]
            //Output:[5, 4, 3, 2, 1]

            #region Solution:1
            //Wrong Way Because Array.Reverse will create a New array
            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            Array.Reverse(numbers);
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            #endregion

            #region Solution 2 
            int[] _numbers = { 5, 10, 15, 20, 25 };
            int temp = 0;

            for (int i = 0; i < _numbers.Length / 2; i++)
            {
                temp = _numbers[i];
                _numbers[i] = _numbers[_numbers.Length - 1 - i];
                _numbers[_numbers.Length - 1 - i] = temp;
            }
            #endregion


        }
        #endregion

        #region Problem:3 

        #region Problem:3
        public static double CalculateAverage(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0; // Or throw ArgumentException? Based on requirement.
            }

            long sum = 0; // Use long to avoid overflow for large arrays
            foreach (int num in numbers)
            {
                sum += num;
            }
            return (double)sum / numbers.Length;
        }
        #endregion

        #region Problem:3
        public void Problem_3()
        {
            //Calculate the Average: Write a program to calculate the average of all elements in a
            //given integer array.
            //Input:[2, 4, 6, 8, 10]
            //Output: 6

            #region Solution 1 
            int[] numbers = { 2, 4, 6, 8, 10 };
            int length = numbers.Length;
            int sum = 0;
            decimal avg = 0;

            for(int i=0; i<length;i++)
            {
                sum = sum + numbers[i];
            }
            avg = sum / length;
            #endregion


        }
        #endregion

        #endregion

        #region problem:4
       
        //Linear Search: Write a function that takes an array and a target value.
        //Return the index of the target value if it exists in the array, otherwise return -1.
        //Input: arr = [4, 2, 7, 1, 9], target = 7
        //Output: 2
        //Input: arr = [4, 2, 7, 1, 9], target = 5
        //Output: -1

        public int LinearSearch(int[] array, int target)
        {
            if (array == null)
                return -1;

            return Array.IndexOf(array, target);
        }

        #endregion

        #region 5. Count Even/Odd Numbers
        /*
            ❓ Problem:
            Write a program to count the number of even and odd numbers 
            in a given integer array.

            🔹 Input:
               [12, 5, 8, 21, 16, 7]

            🔹 Expected Output:
               Even: 3, Odd: 3
        */

        public void CalculateEvenOdd()
        {
            int[] numbers = { 0, -5, 2, 4, 3, 9, 10, 7, 8, 99, 45 };
            int oddCount = 0;
            int evenCount = 0;

            foreach (int num in numbers)
            {
                // Even numbers are those divisible by 2 (including 0 and negatives)
                if (num % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            Console.WriteLine("Total Even Number Count: " + evenCount);
            Console.WriteLine("Total Odd Number Count: " + oddCount);
        }

        #endregion


    }
}
