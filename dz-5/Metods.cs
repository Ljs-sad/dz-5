using System;
using System.Collections.Generic;
using System.Text;

namespace dz_5
{
    public static class Metods
    {
        static public int ReadInt(string message)
        {
            int num;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
            {
                Console.Write("Ошибка. Введите положительное число: ");
            }
            return num;
        }

        static public (int, int) CountChars(char[] charArr)
        {
            int vowels = 0;
            int consonant = 0;
            string vowelsString = "аеёиуиоэюяыАЕЁИУОЭЮЯЫ";

            foreach (char c in charArr)
            {
                if (vowelsString.Contains(c))
                {
                    vowels++;
                }
                else
                {
                    consonant++;
                }
            }
            return (vowels, consonant);
        }

        static public void Print(int[,] matrica)
        {
            for (int i = 0; i < matrica.GetLength(0); i++)
            {
                for (int j = 0; j < matrica.GetLength(1); j++)
                {
                    Console.Write(matrica[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static public int[,] Multiply(int[,] matricaA, int[,] matricaB, int rowsA, int colsArowsB, int colsB)
        { 
            int[,] result = new int[rowsA, colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsArowsB; k++)
                    {
                        result[i, j] += matricaA[i, k] * matricaB[k, j];
                    }
                }
            }
            return result;
        }

        public static double[] AverageTemperature(int[,] arrTemp)
        {
            double[] averageTemp = new double[12];

            for (int i = 0;i < 12; i++)
            {
                double summ = 0;
                for (int j = 0;j < 30; j++)
                {
                    summ += arrTemp[i, j];
                }
                averageTemp[i] = summ / 30.0;
            }
            return averageTemp;
        }

        static public (int, int) CountCharsList(List<char> charArr)
        {
            int vowels = 0;
            int consonant = 0;
            string vowelsString = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";

            foreach (char c in charArr)
            {
                if (vowelsString.Contains(c))
                {
                    vowels++;
                }
                else
                {
                    consonant++;
                }
            }
            return (vowels, consonant);
        }

        static public LinkedList<LinkedList<int>> CreateAndFillMatrix(int rows, int cols)
        {
            var matrix = new LinkedList<LinkedList<int>>();
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                var row = new LinkedList<int>(); 
                for (int j = 0; j < cols; j++)
                {
                    row.AddLast(rnd.Next(1, 10)); 
                }
                matrix.AddLast(row);
            }
            return matrix;
        }

        static public LinkedList<LinkedList<int>> MultiplyLinkedListMatrices(
            LinkedList<LinkedList<int>> matrixA,
            LinkedList<LinkedList<int>> matrixB)
        {
            int rowsA = matrixA.Count;
            int colsA = matrixA.First.Value.Count;
            int colsB = matrixB.First.Value.Count;

            var result = new LinkedList<LinkedList<int>>();

            for (int i = 0; i < rowsA; i++)
            {
                var newRow = new LinkedList<int>();
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int t = 0; t < colsA; t++)
                    {
                        int valA = matrixA.ElementAt(i).ElementAt(t);
                        int valB = matrixB.ElementAt(t).ElementAt(j);
                        sum += valA * valB;
                    }
                    newRow.AddLast(sum);
                }
                result.AddLast(newRow);
            }
            return result;
        }

        static public void PrintLinkedListMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var val in row)
                {
                    Console.Write(val + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
    
