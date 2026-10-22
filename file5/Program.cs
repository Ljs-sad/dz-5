using System;
using static file5.Graf;
using static file5.StudentTask2.Metods;
using static file5.grangmaTask3.GrandmaInput;
using file5.grangmaTask3;
using file5.StudentTask2;

namespace file5
{
    internal class Program
    {
        static void Task1()
        {
            Console.WriteLine("- Задание 1: Картинки -");

            string folderPath = @"..\..\..\FotoTask1";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Ошибка: Папка '{folderPath}' не найдена!");
                Console.WriteLine("Убедитесь, что папка FotoTask1 лежит в корне проекта.");
                return;
            }

            string[] files = Directory.GetFiles(folderPath, "*.jpg");

            if (files.Length == 0)
            {
                Console.WriteLine("Ошибка: В папке нет картинок с расширением .jpg");
                return;
            }

            List<string> originalList = new List<string>();

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);

                originalList.Add(fileName);
                originalList.Add(fileName);
            }

            Console.WriteLine("\nИзначальный список:");
            Console.WriteLine(string.Join(", ", originalList));

            List<string> shuffledList = new List<string>(originalList);
            Random rand = new Random();

            for (int i = shuffledList.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                string temp = shuffledList[i];
                shuffledList[i] = shuffledList[j];
                shuffledList[j] = temp;
            }

            Console.WriteLine("\nПеремешанный список:");
            Console.WriteLine(string.Join(", ", shuffledList));
        }
        static void Task2()
        {
            Console.WriteLine("- Задание 2 -");

            string file = "../../../StudentTask2/students.txt";

            Dictionary<Guid, Student> students = LoadStudent(file);

            if (students == null) return;

            Console.WriteLine("\nТекущий список студентов:");
            PrintStudent(students);

            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("\nВведите команду (Новый студент / Удалить / Сортировать / Выход): ");
                string? command = Console.ReadLine()?.Trim();

                switch (command)
                {
                    case "Новый студент":
                        AddNewStudent(students, file);
                        break;

                    case "Удалить":
                        RemoveStudent(students, file);
                        break;

                    case "Сортировать":
                        var sorted = students.OrderBy(x => x.Value.Ball).ToList();
                        Console.WriteLine("\nСтуденты по баллам (по возрастанию):");
                        PrintStudent(sorted);
                        break;

                    case "Выход":
                        Console.WriteLine("Завершение работы...");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка: Неизвестная команда.");
                        break;
                }
            }
        }
        static void Task3()
        {
            Disease cold = new Disease("Простуда");
            Disease flu = new Disease("Грипп");
            Disease heart = new Disease("Сердце");
            Disease back = new Disease("Радикулит");
            Disease eye = new Disease("Зрение");
            Disease brain = new Disease("Склероз");
            Disease stomach = new Disease("Желудок");
            Disease teeth = new Disease("Зубы");

            List<Hospital> allHospitals = new List<Hospital>
    {
        new Hospital("Городская №1", 2, new List<Disease> {cold, flu, heart}),
        new Hospital("Глазная клиника", 1, new List<Disease> {eye, cold}),
        new Hospital("Неврологическая", 2, new List<Disease> {brain, back, heart}),
        new Hospital("Гастроцентр", 1, new List<Disease> {stomach, cold, flu}),
        new Hospital("Стоматология", 1, new List<Disease> {teeth, back})
    };

            List<Grandma> allGrandmas = new List<Grandma>();

            Console.WriteLine("Вводите бабуль по одной. Чтобы закончить ввод, просто нажмите Enter.");

            bool isRunning = true;
            while (isRunning)
            {
                Grandma g = GrandmaFromInput();

                if (g == null)
                {
                    isRunning = false;
                }
                else
                {
                    allGrandmas.Add(g);
                    bool placed = false;

                    foreach (var h in allHospitals)
                    {
                        if (h.CanTreat(g) && h.Patients.Count < h.Capacity)
                        {
                            h.Patients.Add(g);
                            g.CurrentHospital = h;
                            Console.WriteLine($"--- Бабуля {g.Name} направлена в '{h.Name}'.");
                            placed = true;
                            break;
                        }
                    }

                    if (!placed)
                    {
                        Console.WriteLine($"--- Бабулю {g.Name} не приняли ни в одну больницу. Она плачет на улице.");
                    }
                }
            }

            Console.WriteLine("\n=== Итоговая статистика по больницам ===");
            foreach (var h in allHospitals)
            {
                string diseasesList = string.Join(", ", h.TreatableDiseases.Select(d => d.Name));

                double fillPercent = ((double)h.Patients.Count / h.Capacity) * 100;

                Console.WriteLine($"\nБольница: {h.Name}");
                Console.WriteLine($"Лечат: {diseasesList}");
                Console.WriteLine($"Заполненность: {h.Patients.Count} из {h.Capacity} мест ({fillPercent:F0}%)");

                Console.Write("Список бабуль: ");
                if (h.Patients.Count == 0)
                {
                    Console.WriteLine("пусто");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", h.Patients.Select(p => p.Name)));
                }
            }
        }
        static void Task4()
        {
            Console.WriteLine();

            int vertexCount = 8;
            int[,] edges =
            {
                    { 0, 1 }, { 0, 2 }, { 1, 3 }, { 2, 3 }, { 3, 4 },
                    { 4, 5 }, { 2, 6 }, { 6, 7 }, { 5, 7 }
            };

            List<int>[] graph = new List<int>[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int from = edges[i, 0];
                int to = edges[i, 1];
                graph[from].Add(to);
                graph[to].Add(from);
            }

            Console.WriteLine("Список смежности графа:");
            for (int i = 0; i < vertexCount; i++)
            {
                Console.WriteLine($"Вершина {i}: {string.Join(", ", graph[i])}");
            }

            int start;
            Console.Write($"\nВведите начальную вершину (от 0 до {vertexCount - 1}): ");
            while (!int.TryParse(Console.ReadLine(), out start) || start < 0 || start >= vertexCount)
            {
                Console.Write($"Ошибка! Введите целое число от 0 до {vertexCount - 1}: ");
            }

            int end;
            Console.Write($"Введите конечную вершину (от 0 до {vertexCount - 1}): ");
            while (!int.TryParse(Console.ReadLine(), out end) || end < 0 || end >= vertexCount)
            {
                Console.Write($"Ошибка! Введите целое число от 0 до {vertexCount - 1}: ");
            }

            Console.WriteLine($"\nИщем кратчайший путь из вершины {start} в вершину {end}");

            List<int> path = FindShortestGraf(graph, start, end);

            if (path.Count == 0)
            {
                Console.WriteLine("Пути между этими вершинами не существует.");
            }
            else
            {
                Console.WriteLine($"\nКратчайший путь {path.Count - 1} ребер(ра):");
            }
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }
    }
}
