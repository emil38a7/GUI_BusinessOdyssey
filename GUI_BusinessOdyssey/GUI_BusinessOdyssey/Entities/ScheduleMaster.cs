using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class ScheduleMaster
    {
        public int ScheduleMasterId { get; set; }
        public int JGroupId { get; set; }
        public int SGroupId { get; set; }
        public int ScheduleId { get; set; }

        public JudgesGroup JGroup { get; set; }
        public StudentGroup SGroup { get; set; }
        public Schedule Schedule { get; set; }
    }
}
