using GUI_BusinessOdyssey.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_BusinessOdyssey.Management
{
    class Office
    {
        string studentController = "http://localhost:55290/api/students";
        string studentGroupController = "http://localhost:55290/api/studentGroups";
        string judgeController = "http://localhost:55290/api/Judges";
        string judgeGroupController = "http://localhost:55290/api/JudgesGroups";
        string studentID = "studentId";
        string studentGroupID = "sGroupId";
        string judgeID = "JudgeId";
        string judgeGroupID = "JGroupId";

        string propertyName = "";
        string accessPath = "";

        public List<int> finalIdList { get; set; }

        ObservableCollection<Student> studentList = new ObservableCollection<Student>();
        public ObservableCollection<Student> StudentList
        {
            get { return studentList; }
            set { studentList = value; }
        }

        public void postObject(object obj)
        {
            try
            {
                using (var client = new WebClient())
                {
                    Uri uri = new Uri(studentGroupController);
                    var dataString = JsonConvert.SerializeObject(obj);
                   // Console.WriteLine(dataString);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                    Console.WriteLine("Send to DB" + dataString);

                    var returnval = client.UploadString(uri, "POST", dataString);
                    client.Dispose();

                    //var response = client.DownloadData(studentGroupController);
                }
            }catch(Exception ex)
            {

            }
        }


        public JArray getStudentGroups(string entityName)
        {
            switch (entityName)
            {
                case "student":
                    propertyName = studentID;
                    accessPath = studentController;
                    break;
                case "studentGroupID":
                    propertyName = studentGroupID;
                    accessPath = studentGroupController;
                    break;
                case "judge":
                    propertyName = judgeID;
                    accessPath = judgeController;
                    break;
                case "judgeGroup":
                    propertyName = judgeGroupID;
                    accessPath = judgeGroupController;
                    break;
            }

            WebClient client = new WebClient();
            var response = client.DownloadString(accessPath);
            string resp = JsonConvert.ToString(response);

            dynamic studentGroups = JsonConvert.DeserializeObject<dynamic>(resp);
            //Console.WriteLine("***" + studentGroups.ToString());

            JArray jArray = JArray.Parse(studentGroups);
            return jArray;
        }

        public List<int> getIDsList(string entityName)
        {
            JArray jArray = getStudentGroups(entityName);

            List<int> idList = new List<int>();
            foreach (JObject jObject in jArray)
            {
                foreach (var property in jObject)
                {
                    if (property.Key == propertyName)
                    {
                        idList.Add(int.Parse(property.Value.ToString()));
                    }
                }
            }
            return idList;
        }

        public int generateID(List<int> idList)
        {
            //List<int> idList = getIDsList(entityName);

            int id = 0;
            if (idList.Count != 0)
            {
                idList.Sort();
                id = idList[idList.Count - 1] + 1;
                return id;
            }
            else return 1;
        }
    }
}
