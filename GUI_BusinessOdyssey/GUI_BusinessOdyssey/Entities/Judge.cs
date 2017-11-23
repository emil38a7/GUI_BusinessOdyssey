using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class Judge
    {
        [NonSerialized]

        public int judgeId;
        public int JudgeId
        {
            get { return judgeId; }
            set { judgeId = value; }
        }

        [NonSerialized]
        public string judgeName;
        public string JudgeName
        {
            get { return judgeName; }
            set { judgeName = value; }
        }

        public int JGroupId { get; set; }

        public string JGroupKey { get; set; }
    }
}
