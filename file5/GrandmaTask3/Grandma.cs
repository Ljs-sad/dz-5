using System;
using System.Collections.Generic;
using System.Text;

namespace file5.grangmaTask3
{
    public class Grandma
    {
        public string Name {get; set;}
        public DateTime BirthDay {get; set;}
        public List<Disease> Diseases {get; set;}
        public Hospital CurrentHospital {get; set;}

        public Grandma(string name, DateTime birthDay, List<Disease> diseases)
        {
            Name = name;
            BirthDay = birthDay;
            Diseases = diseases;
        }

        public int GetAge()
        {
            int age = DateTime.Now.Year - BirthDay.Year;
            if (DateTime.Now.DayOfYear < BirthDay.DayOfYear) age--;
            return age;
        }
    }
}
