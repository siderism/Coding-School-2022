﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.Model
{
    public class Person : Item
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }

        public Person()
        {
        }
    }
}
