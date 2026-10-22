using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace file5.StudentTask2
{
    public struct Student
    {
        public Guid Id;
        public string SurName;
        public string Name;
        public DateTime BirthDay;
        public string Examen;
        public byte Ball;

        public Student(string surname, string name, DateTime birthday, string examen, byte ball)
        {
            Id = Guid.NewGuid();
            SurName = surname;
            Name = name;
            BirthDay = birthday;
            Examen = examen;
            Ball = ball;
        }

        public string PrintInfo()
        {
            return $"ID: {Id}\nФИО: {SurName} {Name}\nДата рождения: {BirthDay}\nЭкзамен: {Examen}\nБаллы: {Ball}";
        }
    }
}
