using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_03
{
    internal class Schedule
    {
        public Guid ID { get; }
        public Guid CourseId { get; }
        public Guid ProfessorID { get; }
        public DateTime Callendar { get; set; }

        public Schedule(Guid courseID, Guid professorID, DateTime datetime)
        {
            ID = Guid.NewGuid();
            CourseId = courseID;
            ProfessorID = professorID;
            Callendar = datetime;
        }
    }
}
