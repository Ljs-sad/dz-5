using System;
using System.IO;
using static dz_5.Metods;

namespace dz_5
{
    internal class Program
    {
        static void Task1()
        {
            Console.WriteLine("- Упражнение 6.1 -");
            string file = "../../../textFile.txt";

            if (!File.Exists(file))
            {
                Console.WriteLine("Ошибка. Файл не найден.");
            }
            string text = File.ReadAllText(file);
            char[] arrChar = text.ToCharArray();
            (int vowels, int consonant) result = CountChars(arrChar);

            Console.WriteLine($"Количество согласных букв: {result.consonant}\nКоличество гласных букв: {result.vowels}");

        }
        static void Task2()
        {
            Console.WriteLine("\n- Упражнение 6.2 -");

            int rowsA = Metods.ReadInt("Введите количество строк в матрице А: ");
            int colsArowsB = Metods.ReadInt("Введите количество столбцов в A и строк в В (одно число): ");
            int colsB = Metods.ReadInt("Введите количество столбцов в матрице В: ");

            int[,] matricaA = new int[rowsA, colsArowsB];
            int[,] matricaB = new int[colsArowsB, colsB];

            Random rnd = new Random();

            for (int i = 0; i < rowsA; i++)
                for (int j = 0; j < colsArowsB; j++)
                    matricaA[i, j] = rnd.Next(1, 50);

            for (int i = 0; i < colsArowsB; i++)
                for (int j = 0; j < colsB; j++)
                    matricaB[i, j] = rnd.Next(1, 50);

            Console.WriteLine("\nПервая матрица: ");
            Print(matricaA);
            Console.WriteLine("\nВторая матрица: ");
            Print(matricaB);

            int[,] resultMatrica = Metods.Multiply(matricaA, matricaB, rowsA, colsArowsB, colsB);

            Console.WriteLine("\nРезультат умножения двух матриц: ");
            Print(resultMatrica);

        }
        static void Task3()
        {
            Console.WriteLine("\n- Упражнение 6.3 -");

            string[] monthNames =
            {
                "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
            };

            int[,] temperature = new int[12, 30];

            Random rnd = new Random();

            for (int i = 0;i < 12; i++)
            {
                for (int j = 0;j < 30; j++)
                {
                    temperature[i, j] = rnd.Next(-30, 31);
                }
            }
            double[] averageTemperatures = AverageTemperature(temperature);
            Console.WriteLine("Средние температуры по месяцам:");
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"{monthNames[i]}: {averageTemperatures[i]:F1}");
            }

            Array.Sort(averageTemperatures);

            Console.WriteLine("\nСредние температуры по возрастанию:");
            foreach (double temp in averageTemperatures)
            {
                Console.WriteLine($"{temp:F1}");
            }
            Console.WriteLine();
        }
        static void Homework1()
        {
            Console.WriteLine("- Домашнее задание 6.1 -");
            string file = "../../../textFile.txt";

            if (!File.Exists(file))
            {
                Console.WriteLine("Ошибка. Файл не найден.");
            }
            string text = File.ReadAllText(file);
            List<char> arrChar = text.ToList();
            (int vowels, int consonant) result = CountCharsList(arrChar);

            Console.WriteLine($"Количество согласных букв: {result.consonant}\nКоличество гласных букв: {result.vowels}");
        }
        static void Homework2()
        {
            Console.WriteLine("- Домашнее задание 6.2 -");

            int n = Metods.ReadInt("Введите кол-во строк матрицы А (n): ");
            int m = Metods.ReadInt("Введите кол-во столбцов А и строк В (m): ");
            int k = Metods.ReadInt("Введите кол-во столбцов матрицы В (k): ");

            var matrixA = CreateAndFillMatrix(n, m);
            var matrixB = CreateAndFillMatrix(m, k);

            Console.WriteLine("\nМатрица A:");
            PrintLinkedListMatrix(matrixA);

            Console.WriteLine("\nМатрица B:");
            PrintLinkedListMatrix(matrixB);

            var result = MultiplyLinkedListMatrices(matrixA, matrixB);
            Console.WriteLine("\nРезультат умножения:");
            PrintLinkedListMatrix(result);

        }
            static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Homework1();
            Homework2();
        }
    }
}
