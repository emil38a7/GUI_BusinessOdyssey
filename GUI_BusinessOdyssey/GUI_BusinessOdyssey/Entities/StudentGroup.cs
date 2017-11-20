using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Entities
{
    class StudentGroup
    {
        public int sGroupNumber { get; set; }
        public string sGroupName { get; set; }
        private ObservableCollection<Student> studentGroupList = new ObservableCollection<Student>();

        public ObservableCollection<Student> StudentGroupList
        {
            get { return studentGroupList; }
            set { studentGroupList = value; }
        }
    }
}
