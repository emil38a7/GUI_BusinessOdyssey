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
        public string SGroupName { get; set; }
        public int TrackId { get; set; }

        public ObservableCollection<ScheduleMaster> ScheduleMaster { get; set; }
        public ObservableCollection<ScoreSheetReg> ScoreSheetReg { get; set; }
        public ObservableCollection<Student> Student { get; set; }

        public StudentGroup()
        {
            ScheduleMaster = new ObservableCollection<Entities.ScheduleMaster>();
            ScoreSheetReg = new ObservableCollection<Entities.ScoreSheetReg>();
            Student = new ObservableCollection<Entities.Student>();
        }
    }
}
