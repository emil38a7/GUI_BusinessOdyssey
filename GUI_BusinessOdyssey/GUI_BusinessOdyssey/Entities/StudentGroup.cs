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
        public int sGroup_ID { get; set; }
        public string sGroup_Name { get; set; }
        public int track_ID { get; set; }

/*
        private ObservableCollection<Student> studentGroupList = new ObservableCollection<Student>();

        public ObservableCollection<Student> StudentGroupList
        {
            get { return studentGroupList; }
            set { studentGroupList = value; }
        }
        */
    }
}
