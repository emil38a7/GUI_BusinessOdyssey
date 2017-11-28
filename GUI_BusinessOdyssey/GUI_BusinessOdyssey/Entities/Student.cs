using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSchool { get; set; }
        public string SGroupName { get; set; }

        public StudentGroup SGroupNameNavigation { get; set; }
    }
}
