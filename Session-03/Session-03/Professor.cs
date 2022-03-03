using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_03
{
    public class Professor : Person
    {
        public string Rank { get; set; }
        public Course[] Courses { get; set; }

        public Professor(string name = null, int age = 0, string rank = null) : base(name, age)
        {
            Rank = rank;
        }

        public void Teach(Course course, DateTime dateTime)
        {

        }

        public void SetGrade(Guid studentID, Guid courseID, int grade)
        {
            
        }

        public string GetName()
        {
            return "Dr. " + Name;
        }
    }
}
