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
        Student student;
        StudentGroup sGroup;
        Office office;
        List<int> studentIdList;
        List<int> groupIdList;
        List<string> sGroupNameList;
        List<Student> tempStudentList;
        int track = 0;

        public AddGroupControl()
        {
            InitializeComponent();
            office = new Office();
            //studentIdList = new List<int>();
            this.DataContext = office;
            studentIdList =  office.getIDsList("student");
            groupIdList = office.getIDsList("studentGroupID");
            sGroupNameList = office.getKeyList("SGroupName");
            tempStudentList = new List<Student>();
        }

        private void resetController()
        {
            studentIdList = new List<int>();
            studentIdList = office.getIDsList("student");
            Console.WriteLine("second list is" + studentIdList);
            groupIdList = office.getIDsList("studentGroupID");
            sGroupNameList = office.getKeyList("SGroupName");
            tempStudentList = new List<Student>();
            office.StudentList.Clear();
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
            tempStudentList.Add(student);
            studentIdList.Add(id);
        }

        private void categoryNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            track = categoryNameComboBox.SelectedIndex + 1;  
        }

        private void addStudentGroup_Click(object sender, RoutedEventArgs e)
        {
            sGroup = new StudentGroup
            {
                SGroupId = office.generateID(groupIdList),
                SGroupName = office.verifyStudentGroupName(sGroupNameList, groupNameTextBox.Text),
                TrackId = track,
                student = new ObservableCollection<Student>()
            };
            student.groupID = sGroup.SGroupId;
          
            foreach(Student s in tempStudentList)
            {
               sGroup.student.Add(s);
            }
            Console.WriteLine("Group ID" + sGroup.SGroupId);
            office.postObject(sGroup);

            resetController();
        }

        private void studentNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
