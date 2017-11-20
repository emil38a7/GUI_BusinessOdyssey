using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class Student
    {
        public int studentID { get; set; }

        public string studentName;
        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        public string studentSchool;
        public string StudentSchool
        {
            get { return studentSchool; }
            set { studentSchool = value; }
        }

        public int groupID { get; set; }
    }
}
