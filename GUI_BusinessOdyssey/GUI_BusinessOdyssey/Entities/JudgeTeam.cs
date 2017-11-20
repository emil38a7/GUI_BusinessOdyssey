using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class JudgeTeam
    {
        public int jGroupNumber { get; set; }
        public string jGroupName { get; set; }
        public ObservableCollection<Judge> judgeTeamList = new ObservableCollection<Judge>();


        public ObservableCollection<Judge> JudgeTeamList
        {
            get { return judgeTeamList; }
            set { judgeTeamList = value; }
        }
    }
}
