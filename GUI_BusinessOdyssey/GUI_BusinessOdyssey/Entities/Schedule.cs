using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class Schedule
    {
        public int ScheduleId { get; set; }
        public TimeSpan ScheduleHour { get; set; }

        public ICollection<ScheduleMaster> ScheduleMaster { get; set; }
    }
}
