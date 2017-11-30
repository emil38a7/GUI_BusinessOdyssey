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
        Office office;
       
        public AddJudgesControl()
        {
            InitializeComponent();
            office = new Office();
            this.DataContext = office;
        }

        private void addJudgeButton_Click(object sender, RoutedEventArgs e)
        {
            office.createJudge();
        }

        private void addJudgesTeamGroup_Click(object sender, RoutedEventArgs e)
        {
            office.postJ(office.createJudgesGroup());
        }
    }
}
