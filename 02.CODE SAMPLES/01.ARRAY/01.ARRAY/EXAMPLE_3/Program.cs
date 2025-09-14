/*
 * ✅ Summary:
    Addition, Subtraction, Division → element-wise ✔️
    Multiplication → dot-product rule ✔️
 */

using System;

namespace EXAMPLE_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Matrix A (2x2)
            int[,] A = { { 1, 2 }, { 3, 4 } };

            // Matrix B (2x2)
            int[,] B = { { 1, 5 }, { 5, 10 } };

            Console.WriteLine("=== Matrix A ===");
            PrintMatrix(A);

            Console.WriteLine("=== Matrix B ===");
            PrintMatrix(B);

            // 1. Matrix Addition
            Console.WriteLine("=== Matrix Addition (A + B) ===");
            int[,] add = AddMatrices(A, B);
            PrintMatrix(add);

            // 2. Matrix Multiplication
            Console.WriteLine("=== Matrix Multiplication (A x B) ===");
            int[,] mul = MultiplyMatrices(A, B);
            PrintMatrix(mul);

            // 3. Matrix Division (Element-wise)
            Console.WriteLine("=== Matrix Division (A ÷ B) ===");
            double[,] div = DivideMatrices(A, B);
            PrintMatrix(div);
        }

        // 🔹 Function: Print int matrix
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // 🔹 Function: Print double matrix
        static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // 🔹 Matrix Addition
        static int[,] AddMatrices(int[,] A, int[,] B)
        {
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = A[i, j] + B[i, j];

            return result;
        }

        // 🔹 Matrix Multiplication
        static int[,] MultiplyMatrices(int[,] A, int[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (colsA != rowsB)
                throw new Exception("Matrix multiplication not possible: columns of A != rows of B");

            int[,] result = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsA; k++)
                        sum += A[i, k] * B[k, j];
                    result[i, j] = sum;
                }
            }
            return result;
        }

        // 🔹 Matrix Division (Element-wise)
        static double[,] DivideMatrices(int[,] A, int[,] B)
        {
            int rows = A.GetLength(0);
            int cols = A.GetLength(1);
            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (B[i, j] == 0)
                        throw new DivideByZeroException($"Division by zero at ({i},{j})");
                    result[i, j] = (double)A[i, j] / B[i, j];
                }
            }
            return result;
        }
    }
}
