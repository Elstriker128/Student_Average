using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Average
{
     class StudentContainer
    {
        private Students[] students;
        private int Capacity;
        public int Count { get; set; }
        public StudentContainer(int capacity = 100)
        {
            this.Capacity = capacity;
            this.students= new Students[capacity];
        }
        public void Add(Students student)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.students[this.Count++] = student;
        }
        public Students Get(int index)
        {
            return this.students[index];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (this.Capacity < minimumCapacity)
            {
                Students[] temp = new Students[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.students[i];
                }
                this.Capacity = minimumCapacity;
                this.students = temp;
            }
        }
        public void ReturnAverageMark()
        {
            for (int i = 0; i < this.Count; i++)
            {
                decimal sum = 0;
                Students student=this.Get(i);
                for(int j = 0; j < student.GradeAmount; j++)
                {
                    sum += student.Grades[j];
                }
                student.Average=sum/student.GradeAmount;
            }
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Students a = this.students[i];
                    Students b = this.students[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.students[i] = b;
                        this.students[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
