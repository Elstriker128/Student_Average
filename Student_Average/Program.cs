using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Average
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentContainer container = InOutUtils.ReadStudents(@"Data.txt", out string Faculty);
            InOutUtils.PrintStudents("Input data", container, Faculty);
            container.ReturnAverageMark();
            container.Sort();
            InOutUtils.PrintAverageInfo("Average data", container);
        }
    }
}
