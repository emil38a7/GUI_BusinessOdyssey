using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class Judge
    {
        public int judgeID;

        public int JudgeID
        {
            get { return judgeID; }
            set { judgeID = value; }
        }

        public string judgeName;

        public string JudgeName
        {
            get { return judgeName; }
            set { judgeName = value; }
        }
        public int JGroupID { get; set; }
    }
}
