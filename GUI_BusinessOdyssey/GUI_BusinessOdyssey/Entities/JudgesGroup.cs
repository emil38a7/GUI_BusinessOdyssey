using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class JudgesGroup
    {
        public string JGroupName { get; set; }
        public string JGroupKey { get; set; }

        public ObservableCollection<Judge> Judge { get; set; }
        public ObservableCollection<ScheduleMaster> ScheduleMaster { get; set; }
        public ObservableCollection<ScoreSheetReg> ScoreSheetReg { get; set; }

    }
}
