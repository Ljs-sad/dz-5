using System;
using System.Collections.Generic;
using System.Text;

namespace file5.StudentTask2
{
    internal class Metods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        /// <param name="path"></param>
        public static void AddNewStudent(Dictionary<Guid, Student> students, string path)
        {
            Console.Write("Фамилия: ");
            string surname = Console.ReadLine();
            Console.Write("Имя: ");
            string name = Console.ReadLine();

            Console.Write("Дата рождения (дд.мм.гггг): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthDay))
            {
                Console.WriteLine("Ошибка: неверный формат даты.");
                return;
            }

            Console.Write("Экзамен: ");
            string examen = Console.ReadLine();

            Console.Write("Баллы (0-100): ");
            if (!byte.TryParse(Console.ReadLine(), out byte ball) || ball > 100)
            {
                Console.WriteLine("Ошибка: баллы должны быть от 0 до 100.");
                return;
            }

            Student newStudent = new Student(surname, name, birthDay, examen, ball);
            students.Add(newStudent.Id, newStudent);

            SaveStudent(students, path);
            Console.WriteLine("Студент добавлен и сохранен в файл!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        /// <param name="path"></param>
        public static void RemoveStudent(Dictionary<Guid, Student> students, string path)
        {
            Console.Write("Введите ID студента для удаления: ");

            if (!Guid.TryParse(Console.ReadLine()?.Trim(), out Guid id))
            {
                Console.WriteLine("Ошибка: это не ID (ожидался вид xxxxxxxx-xxxx...).");
                return;
            }
            if (students.Remove(id))
            {
                SaveStudent(students, path);
                Console.WriteLine("Студент удален.");
            }
            else
            {
                Console.WriteLine("Студент с таким ID не найден.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Dictionary<Guid, Student> LoadStudent(string path)
        {
            var dict = new Dictionary<Guid, Student>();

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден.");
            }
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    string[] parts = line.Split(';');
                    if (parts.Length == 6)
                    {
                        Guid id = Guid.Parse(parts[0]);
                        string surname = parts[1];
                        string name = parts[2];
                        DateTime birth = DateTime.Parse(parts[3]);
                        string exam = parts[4];
                        byte score = byte.Parse(parts[5]);

                        Student s = new Student(surname, name, birth, exam, score);
                        s.Id = id;

                        dict.Add(s.Id, s);
                    }
                }
                return dict;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        /// <param name="path"></param>
        public static void SaveStudent(Dictionary<Guid, Student> students, string path)
        {
            List<string> lines = new List<string>();

            foreach (var student in students.Values)
            {
                string line = $"{student.Id};{student.SurName};{student.Name};{student.BirthDay:yyyy-MM-dd};{student.Examen};{student.Ball}";
                lines.Add(line);
            }

            File.WriteAllLines(path, lines);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        public static void PrintStudent(Dictionary<Guid, Student> students)
        {
            int number = 1;
            foreach (var pair in students)
            {
                Console.WriteLine($"{number}. {pair.Value.PrintInfo()}");
                number++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        // Вывод для отсортированного списка (List<KeyValuePair>)
        public static void PrintStudent(List<KeyValuePair<Guid, Student>> students)
        {
            int number = 1;
            foreach (var pair in students)
            {
                Console.WriteLine($"{number}. {pair.Value.PrintInfo()}");
                number++;
            }
        }
    }
}
