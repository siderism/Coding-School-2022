using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_03
{
    public class Grade
    {
        public Guid ID { get; }
        public Guid StudentID { get; }
        public Guid CourseID { get; }
        public int TheGrade { get; set; }

        public Grade(Guid studentID, Guid courseID, int grade)
        {
            ID = Guid.NewGuid();
            StudentID = studentID;
            CourseID = courseID;
            TheGrade = grade;
        }
    }
}
