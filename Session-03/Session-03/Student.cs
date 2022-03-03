using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_03
{
    public class Student : Person
    {
        public int RegistrationNumber { get; set; }
        public Course[] Courses { get; set; }

        public Student(string name = "", int age = 0) : base(name, age)
        {

        }

        public void Attend(Course course, DateTime dateTime)
        {

        }

        public void WriteExam(Course course, DateTime dateTime)
        {

        }
    }
}
