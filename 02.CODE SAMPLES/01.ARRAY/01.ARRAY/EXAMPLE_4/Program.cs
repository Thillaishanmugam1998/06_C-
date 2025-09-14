using System;

namespace EXAMPLE_4
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 01. EasyProblem:
            EasyProblem obj1 = new EasyProblem();
            //obj1.Problem_1();
            //obj1.Problem_2();
            //obj1.Problem_3();
            //int index = obj1.LinearSearch(new int[] { 4, 2, 7, 1, 9 }, 7);
            //obj1.CalculateEvenOdd();
            #endregion

            #region 02. Medium Level Probelm:
            MediumProblem obj2 = new MediumProblem();

            int[] numbers = { 3, 2, 1, 5, 6, 4 ,99,98,-100};
            obj2.FindKthLargest(numbers,2);
            obj2.FindTarget(numbers, 6);
            obj2.MergeSortedArray();
            #endregion


        }
    }
}
