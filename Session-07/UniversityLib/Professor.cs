﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public class Professor : Person
    {
        public string Rank { get; set; }
        public List<Course> Courses { get; set; }

        public Professor()
        {

        }
    }
}
