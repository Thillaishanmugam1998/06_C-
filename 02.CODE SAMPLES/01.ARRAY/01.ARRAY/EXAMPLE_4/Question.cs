#region Easy Difficulty Problems

/*
--------------------------------------------------------
Problem 1: Find the Maximum Element
--------------------------------------------------------
❓ Description:
   Write a program to find the largest element 
   in a given integer array.

🔹 Example:
   Input:  [10, 5, 20, 8, 15]
   Output: 20
--------------------------------------------------------
Problem 2: Reverse an Array
--------------------------------------------------------
❓ Description:
   Write a program to reverse the elements of 
   an integer array. 
   Try to do this in-place (without creating a new array).

🔹 Example:
   Input:  [1, 2, 3, 4, 5]
   Output: [5, 4, 3, 2, 1]
--------------------------------------------------------
Problem 3: Calculate the Average
--------------------------------------------------------
❓ Description:
   Write a program to calculate the average of 
   all elements in a given integer array.

🔹 Example:
   Input:  [2, 4, 6, 8, 10]
   Output: 6
--------------------------------------------------------
Problem 4: Linear Search
--------------------------------------------------------
❓ Description:
   Write a function that takes an array and a target value. 
   Return the index of the target value if it exists 
   in the array, otherwise return -1.

🔹 Example 1:
   Input:  arr = [4, 2, 7, 1, 9], target = 7
   Output: 2

🔹 Example 2:
   Input:  arr = [4, 2, 7, 1, 9], target = 5
   Output: -1
--------------------------------------------------------
Problem 5: Count Even/Odd Numbers
--------------------------------------------------------
❓ Description:
   Write a program to count the number of even 
   and odd numbers in a given integer array.

🔹 Example:
   Input:  [12, 5, 8, 21, 16, 7]
   Output: Even: 3, Odd: 3
--------------------------------------------------------
*/

#endregion

#region Medium Difficulty Problems

/*
--------------------------------------------------------
Problem 1: Find the Kth Largest Element
--------------------------------------------------------
❓ Description:
   Given an array and a number k, find the kth largest element.
   (For a challenge, try not to use built-in sort functions).

🔹 Example:
   Input:  arr = [3, 2, 1, 5, 6, 4], k = 2
   Output: 5  
   Explanation: Sorted array = [1, 2, 3, 4, 5, 6], 
                2nd largest = 5.
--------------------------------------------------------
Problem 2: Merge Two Sorted Arrays
--------------------------------------------------------
❓ Description:
   Given two sorted integer arrays nums1 and nums2, 
   merge them into a single sorted array.

🔹 Example:
   Input:  nums1 = [1, 3, 5], nums2 = [2, 4, 6]
   Output: [1, 2, 3, 4, 5, 6]
--------------------------------------------------------
Problem 3: Two Sum
--------------------------------------------------------
❓ Description:
   Given an array of integers nums and an integer target, 
   return the indices of the two numbers such that 
   they add up to the target.

   Assume each input has exactly one solution.

🔹 Example:
   Input:  nums = [2, 7, 11, 15], target = 9
   Output: [0, 1]  
   Explanation: nums[0] + nums[1] = 2 + 7 = 9
--------------------------------------------------------
Problem 4: Matrix Multiplication
--------------------------------------------------------
❓ Description:
   Multiply two 2D rectangular matrices (if possible).
   Rule: Number of columns in the first matrix must equal 
         number of rows in the second matrix.

🔹 Example:
   Input:
      matrixA = { {1, 2, 3}, {4, 5, 6} }   // 2x3
      matrixB = { {7, 8}, {9, 10}, {11, 12} } // 3x2

   Output:
      { {58, 64}, {139, 154} }   // 2x2 matrix
--------------------------------------------------------
Problem 5: Jagged Array Operations
--------------------------------------------------------
❓ Description:
   Create a jagged array where the user specifies 
   the number of rows and then the size of each row. 
   Fill it with values and calculate the sum of all elements.

🔹 Example Flow:
   Number of rows: 3
   Size of row 0: 2
   Size of row 1: 4
   Size of row 2: 1
   Enter values for each row...
   Output: Total sum of all elements
--------------------------------------------------------
*/

#endregion

#region Hard Difficulty Problems

/*
--------------------------------------------------------
Problem 1: Kadane's Algorithm (Maximum Subarray Sum)
--------------------------------------------------------
❓ Description:
   Given an integer array nums, find the contiguous subarray 
   (containing at least one number) which has the largest sum 
   and return its sum.

🔹 Example:
   Input:  [-2, 1, -3, 4, -1, 2, 1, -5, 4]
   Output: 6
   Explanation: Subarray [4, -1, 2, 1] has the largest sum = 6

💡 Challenge:
   Can you solve this in O(n) time complexity?
--------------------------------------------------------
Problem 2: Find the Duplicate Number
--------------------------------------------------------
❓ Description:
   Given an array of integers nums containing n + 1 integers 
   where each integer is in the range [1, n]. 
   There is only one repeated number in nums, return it.

   Constraint: 
   - Do not modify the array
   - Use only constant extra space

🔹 Example 1:
   Input:  [1, 3, 4, 2, 2]
   Output: 2

🔹 Example 2:
   Input:  [3, 1, 3, 4, 2]
   Output: 3
--------------------------------------------------------
Problem 3: Spiral Order Traversal of a Matrix
--------------------------------------------------------
❓ Description:
   Given an m x n 2D rectangular array, 
   return all elements of the matrix in spiral order.

🔹 Example 1:
   Input:  
     { {1, 2, 3}, 
       {4, 5, 6}, 
       {7, 8, 9} }
   Output: [1, 2, 3, 6, 9, 8, 7, 4, 5]

🔹 Example 2:
   Input:  
     { {1, 2, 3, 4}, 
       {5, 6, 7, 8}, 
       {9, 10, 11, 12} }
   Output: [1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7]
--------------------------------------------------------
Problem 4: Product of Array Except Self
--------------------------------------------------------
❓ Description:
   Given an integer array nums, return an array answer such 
   that answer[i] is equal to the product of all elements of 
   nums except nums[i].

   Constraint: 
   - Time complexity: O(n)
   - Do not use division

🔹 Example:
   Input:  [1, 2, 3, 4]
   Output: [24, 12, 8, 6]
--------------------------------------------------------
Problem 5: Sliding Window Maximum
--------------------------------------------------------
❓ Description:
   You are given an array of integers nums, and a sliding 
   window of size k. Return the maximum values from each 
   sliding window.

🔹 Example:
   Input:  nums = [1, 3, -1, -3, 5, 3, 6, 7], k = 3
   Output: [3, 3, 5, 5, 6, 7]

   Window Position → Max
   [1  3 -1] -3  5  3  6  7  → 3
    1 [3 -1 -3] 5  3  6  7  → 3
    1  3 [-1 -3 5] 3  6  7  → 5
    1  3 -1 [-3 5 3] 6  7  → 5
    1  3 -1 -3 [5 3 6] 7   → 6
    1  3 -1 -3  5 [3 6 7]  → 7

💡 Challenge:
   Can you find a solution better than O(n*k)?
--------------------------------------------------------
Bonus Conceptual Questions (Interview Style)
--------------------------------------------------------
1. Memory Layout:
   🔹 What is the fundamental difference in memory between 
      a 2D rectangular array (int[,]) and a jagged array (int[][]) 
      in C#?

2. Params Keyword:
   🔹 How does the "params" keyword simplify working with arrays 
      in method parameters? 
      Write an example method that accepts a variable number of 
      integers using params.

3. Array.Copy vs. Clone:
   🔹 What is the difference between Array.Copy() and the Clone() 
      method? 
      When would you use a shallow copy vs. a deep copy with arrays 
      of reference types?

4. Array Bounds:
   🔹 What happens if you try to access an element outside the bounds 
      of an array (e.g., arr[arr.Length])? 
      How do you handle this safely?
--------------------------------------------------------
*/

#endregion

#region Time and Space Complexity
/*
🔹 What does O(n²) mean?

It’s time complexity — a way to describe how the execution time grows as the input size (n) increases.

O(n) → Linear → if array size doubles, operations double.

O(n²) → Quadratic → if array size doubles, operations become 4 times bigger(because n × n).

O(1) → Constant → execution time does not depend on input size.
*/
#endregion