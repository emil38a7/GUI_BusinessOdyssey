using GUI_BusinessOdyssey.Entities;
using GUI_BusinessOdyssey.Management;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_BusinessOdyssey.GUI
{
    /// <summary>
    /// Interaction logic for AddJudgesControl.xaml
    /// </summary>
    public partial class AddJudgesControl : UserControl
    {
        Judge judge;
        JudgesGroup jTeam;
        Office office;
        List<int> judgetIdList;
        List<int> groupIdList;
        List<string> judgeKeyList;
        List<Judge> tempJudgeList;
        int track = 0;

        public AddJudgesControl()
        {
            InitializeComponent();
            office = new Office();
            //studentIdList = new List<int>();
            this.DataContext = office;
            judgetIdList = office.getIDsList("judge");
            groupIdList = office.getIDsList("judgeGroupID");
            judgeKeyList = office.getKeyList("judgeKey");
            tempJudgeList = new List<Judge>();
        }

        private void resetController()
        {
            judgetIdList.Clear();
            judgetIdList = office.getIDsList("judge");
            groupIdList = office.getIDsList("judgeGroupID");
            judgeKeyList = office.getKeyList("judgeKey");
            tempJudgeList.Clear();
            office.DisplayList.Clear();
        }

        private void addJudgeButton_Click(object sender, RoutedEventArgs e)
        {
            int id = office.generateID(judgetIdList);

            judge = new Judge
            {
                judgeId = id,
                judgeName = judgeNameBox.Text,
            };
            office.DisplayList.Add(judge);
            tempJudgeList.Add(judge);
            judgetIdList.Add(id);
        }

        private void addJudgesTeamGroup_Click(object sender, RoutedEventArgs e)
        {
            jTeam = new JudgesGroup
             {
                 JGroupId = office.generateID(groupIdList),
                 JGroupName = groupNameTextBox.Text,
                 JGroupKey = office.generateKey(judgeKeyList),
                 
                 Judge = new ObservableCollection<Judge>()
             };
            //judge.JGroupId = jTeam.JGroupId;

            foreach (Judge j in tempJudgeList)
            {
                j.JGroupId = jTeam.JGroupId;
                jTeam.Judge.Add(j);
            }
            Console.WriteLine("Group ID" + jTeam.JGroupId + "key" + jTeam.JGroupKey);
            office.postObject(jTeam);
            MessageBox.Show("Judge Team " + jTeam.JGroupName + "is registered" + Environment.NewLine + "The key is: " + jTeam.JGroupKey);

            resetController();
        }
    }
}
