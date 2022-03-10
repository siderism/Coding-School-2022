using System;

namespace UniversityLibrary
{
    public class Institute
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int YearInService { get; set; }

        public Institute()
        {
            ID = Guid.NewGuid();
            Name = String.Empty;
            YearInService = 0;
        }
    }
}