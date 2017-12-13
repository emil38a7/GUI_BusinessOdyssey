using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class ScoreSheetReg
    {
        public int ScoreSheetRegId { get; set; }
        public string SGroupName { get; set; }
        public string JGroupName { get; set; }
        public double? Points { get; set; }
        public int TrackId { get; set; }

        public JudgesGroup JGroupNameNavigation { get; set; }
        public StudentGroup SGroupNameNavigation { get; set; }
    }
}
