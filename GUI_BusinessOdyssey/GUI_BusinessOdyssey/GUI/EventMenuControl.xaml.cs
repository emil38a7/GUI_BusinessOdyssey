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
    /// Interaction logic for EventMenuControl.xaml
    /// </summary>
    public partial class EventMenuControl : UserControl
    {
        public EventMenuControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if ((string)button.Content == "Create Student Team")
            {
                AddGroupPanel.Visibility = Visibility.Visible;
                AddJudgePanel.Visibility = Visibility.Hidden;
                ViewAllTeamsPanel.Visibility = Visibility.Hidden;
                FindWinnersPanel.Visibility = Visibility.Hidden;
                CreateSchedulePanel.Visibility = Visibility.Hidden;

                // AddScoreSheet.Visibility = Visibility.Hidden;
            }
            else if ((string)button.Content == "Create Judge team")
            {
                AddJudgePanel.Visibility = Visibility.Visible;
                AddGroupPanel.Visibility = Visibility.Hidden;
                ViewAllTeamsPanel.Visibility = Visibility.Hidden;
                FindWinnersPanel.Visibility = Visibility.Hidden;
                CreateSchedulePanel.Visibility = Visibility.Hidden;

                //AddScoreSheet.Visibility = Visibility.Hidden;
            }
            else if ((string)button.Content == "View All Teams")
            {
                ViewAllTeamsPanel.Visibility = Visibility.Visible;
                AddGroupPanel.Visibility = Visibility.Hidden;
                AddJudgePanel.Visibility = Visibility.Hidden;
                FindWinnersPanel.Visibility = Visibility.Hidden;
                CreateSchedulePanel.Visibility = Visibility.Hidden;

            }
            else if((string)button.Content == "Find winner")
            {
                FindWinnersPanel.Visibility = Visibility.Visible;
                ViewAllTeamsPanel.Visibility = Visibility.Hidden;
                AddGroupPanel.Visibility = Visibility.Hidden;
                AddJudgePanel.Visibility = Visibility.Hidden;
                CreateSchedulePanel.Visibility = Visibility.Hidden;

                //WinnerWindow ww = new WinnerWindow();
                //ww.Show();
            }
            else if ((string)button.Content == "Create Time Schedule")
            {
                CreateSchedulePanel.Visibility = Visibility.Visible;
                ViewAllTeamsPanel.Visibility = Visibility.Hidden;
                AddGroupPanel.Visibility = Visibility.Hidden;
                AddJudgePanel.Visibility = Visibility.Hidden;
                FindWinnersPanel.Visibility = Visibility.Hidden;

            }

           
                

               // ScheduleWindow sw = new ScheduleWindow();
                //sw.Show();

                ////AddScoreSheet.Visibility = Visibility.Visible;
            
        }
    }
}
