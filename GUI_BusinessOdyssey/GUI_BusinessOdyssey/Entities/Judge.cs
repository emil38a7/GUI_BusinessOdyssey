using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    public class Judge
    {
        public int JudgeId { get; set; }
        public string JudgeName { get; set; }
        public string JGroupName { get; set; }

        public JudgesGroup JGroupNameNavigation { get; set; }
    }
}
