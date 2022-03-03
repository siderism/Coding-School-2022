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

        public Student(string name = null, int age = 0, int registrationNumber = 0) : base(name, age)
        {
            RegistrationNumber = registrationNumber;
        }

        public void Attend(Course course, DateTime dateTime)
        {

        }

        public void WriteExam(Course course, DateTime dateTime)
        {

        }
    }
}
