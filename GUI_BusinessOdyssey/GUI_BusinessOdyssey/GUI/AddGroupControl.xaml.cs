using GUI_BusinessOdyssey.Entities;
using GUI_BusinessOdyssey.Management;
using Newtonsoft.Json;
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
    /// Interaction logic for AddGroupControl.xaml
    /// </summary>
    public partial class AddGroupControl : UserControl
    {
        Student student;
        StudentGroup sGroup;
        Office office;
        string groupName;
        List<int> studentIdList;
        List<int> groupIdList;
        List<Student> tempList;

        public AddGroupControl()
        {
            InitializeComponent();
            //student = new Student();
            //sGroup = new StudentGroup();
            office = new Office();
            studentIdList = new List<int>();
            this.DataContext = office;
            studentIdList =  office.getIDsList("student");
            groupIdList = office.getIDsList("studentGroupID");
            tempList = new List<Student>();

        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            
            int id = office.generateID(studentIdList);

            student = new Student
            {
                studentID = id,
                studentName = studentNameBox.Text,
                studentSchool = studentSchoolBox.Text
            };
            office.StudentList.Add(student);
            tempList.Add(student);
            studentIdList.Add(id);
            Console.ReadLine();
        }

        private void categoryNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var groupName = categoryNameComboBox.SelectedItem.ToString();
            groupName = groupNameTextBox.Text; //groupName.Substring(groupName.IndexOf(' ') + 1);
        }

        private void addStudentGroup_Click(object sender, RoutedEventArgs e)
        {
            groupName = groupNameTextBox.Text;

            sGroup = new StudentGroup();
            sGroup.SGroupId = office.generateID(groupIdList);
            sGroup.SGroupName = groupName;
            sGroup.TrackId = 1;
            student.groupID = sGroup.SGroupId;
            sGroup.student = new ObservableCollection<Student>();
          
            foreach(Student s in tempList)
            {
               sGroup.student.Add(s);
            }
            Console.WriteLine("Group ID" + sGroup.SGroupId);
            office.postObject(sGroup);
        }
    }
}
