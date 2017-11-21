using GUI_BusinessOdyssey.Entities;
using GUI_BusinessOdyssey.Management;
using Newtonsoft.Json;
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
    /// Interaction logic for AddGroupControl.xaml
    /// </summary>
    public partial class AddGroupControl : UserControl
    {
        Student student;
        StudentGroup sGroup;
        Office office;
        List<int> idList;

        public AddGroupControl()
        {
            InitializeComponent();
            student = new Student();
            sGroup = new StudentGroup();
            office = new Office();
            idList = new List<int>();
            this.DataContext = sGroup;
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {

            student.studentID = office.generateID("SGroupName");
            Console.WriteLine(student.studentID);
            Console.ReadLine();
        }

        private void categoryNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = categoryNameComboBox.SelectedItem;
            //Console.WriteLine("****" + selectedCategory);
        }
    }
}
