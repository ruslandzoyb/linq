using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Abiturient
    {
        public string Surname { get; set; }
        public int School { get; set; }
        public int Year { get; set; }

        public Abiturient(string surname,int school,int year)
        {
            Surname = surname;
            School = school;
            Year = year;
        }

    }
}
