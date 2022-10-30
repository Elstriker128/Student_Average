using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Average
{
    class Students
    {
        public string Surname { get; set; }
        public string Name { get; set; }        
        public string Group { get; set; }
        public int GradeAmount { get; set; }
        public int[] Grades { get; set; }
        public decimal Average { get; set; }
        public Students(string surname, string name, string group, int gradeAmount, int[] grades)
        {
            this.Surname = surname;
            this.Name = name;
            this.Group = group;
            this.GradeAmount = gradeAmount;
            this.Grades = grades;

        }
        public int CompareTo(Students other)
        {
            if (this.Surname != other.Surname)
            {
                return this.Surname.CompareTo(other.Surname);
            }
            else if (this.Average > other.Average)
            {
                return other.Average.CompareTo(this.Average);
            }
            else
            {
                return -1;
            }
        }
    }
}
