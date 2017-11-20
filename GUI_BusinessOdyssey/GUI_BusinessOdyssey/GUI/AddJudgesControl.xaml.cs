using GUI_BusinessOdyssey.Entities;
using System;
using System.Collections.Generic;
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
        JudgeTeam jTeam;

        public AddJudgesControl()
        {
            InitializeComponent();
            judge = new Judge();
            jTeam = new JudgeTeam();
            this.DataContext = jTeam;
        }

        private void addJudgeButton_Click(object sender, RoutedEventArgs e)
        {
            judge.judgeName = judgeNameBox.Text;
            jTeam.JudgeTeamList.Add(judge);
        }
    }
}
