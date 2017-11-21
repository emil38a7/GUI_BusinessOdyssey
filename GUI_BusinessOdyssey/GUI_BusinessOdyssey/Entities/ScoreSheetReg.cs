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
        public int SGroupId { get; set; }
        public int? JGroupId { get; set; }
        public double? Points { get; set; }
        public int TrackId { get; set; }

        public StudentGroup SGroup { get; set; }
        public Track Track { get; set; }
    }
}
