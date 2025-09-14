using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMPLE_4
{
    class MediumProblem
    {

        #region Problem 1:
        public void FindKthLargest(int[] numbers, int k)
        {
            
            int temp = numbers[0];

            for(int i=0; i<numbers.Length-1;i++)
            {
                for(int j=i+1; j<numbers.Length;j++)
                {
                    if(numbers[i] < numbers[j])
                    {
                        temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            if(k>=0 && k<numbers.Length)
            {
                if(k!=0)
                {
                    Console.WriteLine("Kth Largest values in: " + numbers[k]);
                }
                else
                {
                    Console.WriteLine("Kth Largest values in: " + numbers[k - 1]);
                }
                
            }
            else
            {
                Console.WriteLine("Out of Range");
            }
        }
        #endregion

        #region Problem 2:
        public void MergeSortedArray()
        {
            int[] a = { 2, 5, 8, 9 };
            int[] b = { 1, 5, 6, 10 };
            int[] result = new int[a.Length+b.Length];
            int k = 0;
            int i = 0;
            int j = 0;
            while(i<a.Length && j<b.Length)
            {
                if(a[i]<b[j])
                {
                    result[k] = a[i];
                    i++;
                }
                else
                {
                    result[k] = b[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements from array 'a' (if any)
            while (i < a.Length)
            {
                result[k] = a[i];
                i++;
                k++;
            }

            // Copy remaining elements from array 'b' (if any)
            while (j < b.Length)
            {
                result[k] = b[j];
                j++;
                k++;
            }


        }
        #endregion

        #region Problem 3:
        public int[] FindTarget(int[] numbers, int target)
        {
            int sum = 0;

            for(int i=0; i<numbers.Length;i++)
            {
                for(int j=0;j<numbers.Length;j++)
                {
                   sum = numbers[i] + numbers[j];
                   if(sum == target)
                   {
                        return new int[] { i,j};
                   }
                }
            }
            return new int[] { };

        }
        #endregion
    }
}
