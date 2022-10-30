using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Student_Average
{
    class InOutUtils
    {
        public static StudentContainer ReadStudents(string filename, out string Faculty)
        {
            StudentContainer studentContainer = new StudentContainer();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            Faculty = lines[0];
           foreach(string line in lines.Skip(1))
           {
                string[] Values = line.Split(';');
                string surname=Values[0];
                string name = Values[1];
                string group=Values[2];
                int gradeAmount=int.Parse(Values[3]);
                int[] grades = new int[gradeAmount];
                for (int i = 0; i < gradeAmount; i++)
                {
                    grades[i] = int.Parse(Values[i + 3]);
                }
                Students student = new Students(surname,name, group,gradeAmount,grades);
                studentContainer.Add(student);
           }
           return studentContainer;
        }
        public static void PrintStudents(string label, StudentContainer students, string Faculty)
        {
            Console.WriteLine(new string('-', 77));
            Console.WriteLine("| {0,-73} |", label);
            Console.WriteLine(new string('-', 77));
            Console.WriteLine("| {0,-73} |", Faculty);
            Console.WriteLine(new string('-', 77));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-8} | {3,-12} | {4,-11} |","Surname","Name","Group", "Grade amount", "Grades");
            Console.WriteLine(new string('-', 77));
            for (int i = 0; i < students.Count; i++)
            {
                Students info = students.Get(i);
                Console.Write("| {0,-15} | {1,-15} | {2,-8} | {3,-12} |",info.Surname, info.Name, info.Group, info.GradeAmount);
                Console.WriteLine("{0,12} |", string.Join(" ", info.Grades));
            }
            Console.WriteLine(new string('-', 77));

        }
        public static void PrintAverageInfo(string label, StudentContainer students)
        {
            Console.WriteLine(new string('-', 77));
            Console.WriteLine("| {0,-73} |", label);
            Console.WriteLine(new string('-', 77));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-8} | {3,-12} | {4,-11} | ", "Surname", "Name", "Group", "Grade amount", "Average");
            Console.WriteLine(new string('-', 77));
            for (int i = 0; i < students.Count; i++)
            {
                Students info = students.Get(i);
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-8} | {3,-12} | {4,-11:f} |", info.Surname, info.Name, info.Group, info.GradeAmount, info.Average);
            }
            Console.WriteLine(new string('-', 77));
        }
    }
}
