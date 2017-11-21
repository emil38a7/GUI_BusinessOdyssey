using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class StudentGroup
    {

        public int SGroupId { get; set; }
        public string SGroupName { get; set; }
        public int TrackId { get; set; }

        public ObservableCollection<ScoreSheetReg> ScoreSheetReg { get; set; }

        public ObservableCollection<Student> student { get; set; }

        /*public ObservableCollection<Student> Student
        {
            get { return student; }
            set { student = value; }
        }
        */
    }
}
