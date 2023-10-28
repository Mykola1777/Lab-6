using System;

public class MathOperations
{
    public static dynamic Add(dynamic a, dynamic b)
    {
        return a + b;
    }

    public static dynamic Subtract(dynamic a, dynamic b)
    {
        return a - b;
    }

    public static dynamic Multiply(dynamic a, dynamic b)
    {
        return a * b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int result1 = MathOperations.Add(5, 3);
        int result2 = MathOperations.Subtract(7, 2);
        int result3 = MathOperations.Multiply(4, 6);

        Console.WriteLine($"Addition: {result1}");
        Console.WriteLine($"Subtraction: {result2}");
        Console.WriteLine($"Multiplication: {result3}");

        double[] array1 = { 1.5, 2.5, 3.5 };
        double[] array2 = { 0.5, 0.5, 0.5 };

        var arrayResult = MathOperations.Add(array1, array2);

        Console.WriteLine("Array Addition:");
        foreach (var item in arrayResult)
        {
            Console.WriteLine(item);
        }

        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 2, 3 }, { 4, 5 } };

        var matrixResult = MathOperations.Multiply(matrix1, matrix2);

        Console.WriteLine("Matrix Multiplication:");
        for (int i = 0; i < matrixResult.GetLength(0); i++)
        {
            for (int j = 0; j < matrixResult.GetLength(1); j++)
            {
                Console.Write(matrixResult[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

