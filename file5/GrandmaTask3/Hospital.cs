using System;
using System.Collections.Generic;
using System.Text;

namespace file5.grangmaTask3
{
    public class Hospital
    {
        public string Name {get; set;}
        public int Capacity {get; set;}
        public List<Disease> TreatableDiseases {get; set;}
        public List<Grandma> Patients {get; set;}

        public Hospital(string name, int capacity, List<Disease> treatableDiseases)
        {
            Name = name;
            Capacity = capacity;
            TreatableDiseases = treatableDiseases;
            Patients = new List<Grandma>();
        }

        public bool CanTreat(Grandma grandma)
        {
            if (grandma.Diseases.Count == 0) return false;

            int matchCount = 0;
            foreach (var gDisease in grandma.Diseases)
            {
                foreach (var hDisease in TreatableDiseases)
                {
                    if (gDisease.Name == hDisease.Name)
                    {
                        matchCount++;
                        break;
                    }
                }
            }

            double percent = (double)matchCount / grandma.Diseases.Count;
            return percent > 0.5;
        }
    }

}

