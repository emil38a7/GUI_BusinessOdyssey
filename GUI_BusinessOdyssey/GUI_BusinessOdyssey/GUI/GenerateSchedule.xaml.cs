using GUI_BusinessOdyssey.Management;
using System.Windows;
using System.Windows.Controls;

namespace GUI_BusinessOdyssey.GUI
{
    public partial class GenerateSchedule : UserControl
    {
        Office office = null;
        public GenerateSchedule()
        {
            InitializeComponent();
            office = EventMenuControl.office;
            this.DataContext = office;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if ((string)button.Content == "Delete Schedule")
            {
                office.deleteSchedule();
            }
            else if ((string)button.Content == "Create Schedule")
            {
                office.createTimeSchedule();
            }
        }
    }
}
