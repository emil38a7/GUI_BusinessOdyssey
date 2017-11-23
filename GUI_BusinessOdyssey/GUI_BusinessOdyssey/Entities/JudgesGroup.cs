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
        public int JGroupId { get; set; }
        public string JGroupName { get; set; }

        public ObservableCollection<Judge> Judge { get; set; }

        public string JGroupKey { get; set; }
        public ICollection<ScheduleMaster> ScheduleMaster { get; set; }

    }
}
