using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    public class ScheduleMaster
    {
        public int ScheduleMasterId { get; set; }
        public string JGroupName { get; set; }
        public string SGroupName { get; set; }
        public int ScheduleId { get; set; }

        public JudgesGroup JGroupNameNavigation { get; set; }
        public StudentGroup SGroupNameNavigation { get; set; }
        public Schedule Schedule { get; set; }

    }
}
