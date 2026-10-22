using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace file5.grangmaTask3
{
    public class GrandmaInput
    {
        static public Grandma GrandmaFromInput()
        {
            Console.Write("\nИмя бабули (или Enter для выхода): ");
            string name = Console.ReadLine() ?? "";

            if (name.Trim() == "")
            {
                return null;
            }

            Console.Write("Дата рождения (ДД.ММ.ГГГГ): ");
            DateTime birthDate;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.Write("Ошибка! Введите дату в формате ДД.ММ.ГГГГ: ");
            }

            Console.Write("Болезни через запятую (например: Простуда, Грипп): ");
            string diseasesInput = Console.ReadLine() ?? "";

            List<Disease> diseases = new List<Disease>();

            string[] diseaseNames = diseasesInput.Split(',');
            foreach (string d in diseaseNames)
            {
                if (d.Trim() != "")
                {
                    diseases.Add(new Disease(d.Trim()));
                }
            }

            return new Grandma(name, birthDate, diseases);
        }
    }
}
