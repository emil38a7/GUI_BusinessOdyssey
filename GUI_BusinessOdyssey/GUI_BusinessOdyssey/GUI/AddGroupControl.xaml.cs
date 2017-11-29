using GUI_BusinessOdyssey.Entities;
using GUI_BusinessOdyssey.Management;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for AddGroupControl.xaml
    /// </summary>
    public partial class AddGroupControl : UserControl
    {
        
        Office office;
        
        public AddGroupControl()
        {
            InitializeComponent();
            office = new Office();
            this.DataContext = office;
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {           
            office.createStudent();
        }

        private void addStudentGroup_Click(object sender, RoutedEventArgs e)
        {
            //office.postObject(office.createSGroup());
            office.postJ(office.createSGroup());
        }       
    }
}
