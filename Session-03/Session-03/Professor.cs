using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_03
{
    internal class Professor : Person
    {
        public string Rank { get; set; }
        public Course[] Courses { get; set; }

        public Professor()
        {

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
