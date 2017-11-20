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
                AddJudgePanel.Visibility = Visibility.Hidden;
               // AddScoreSheet.Visibility = Visibility.Hidden;

                AddGroupPanel.Visibility = Visibility.Visible;
            }
            else if ((string)button.Content == "Create Judge team")
            {
                AddGroupPanel.Visibility = Visibility.Hidden;
                //AddScoreSheet.Visibility = Visibility.Hidden;

                AddJudgePanel.Visibility = Visibility.Visible;
            }
            else
            {
                AddJudgePanel.Visibility = Visibility.Hidden;
                AddGroupPanel.Visibility = Visibility.Hidden;

                //AddScoreSheet.Visibility = Visibility.Visible;
            }
        }
    }
}
