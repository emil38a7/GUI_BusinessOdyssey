using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public TimeSpan ScheduleHour { get; set; }

        public List<ScheduleMaster> ScheduleMaster { get; set; }

        public Schedule()
        {
            ScheduleMaster = new List<ScheduleMaster>(); //
        }

    }
}
