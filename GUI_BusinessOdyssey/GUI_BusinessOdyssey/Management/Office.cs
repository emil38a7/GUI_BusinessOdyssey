using GUI_BusinessOdyssey.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_BusinessOdyssey.Management
{
    class Office
    {
        string studentController = "http://localhost:49820/api/students";
        string studentGroupController = "http://localhost:49820//api/studentGroups";
        string judgeController = "http://localhost:49820/api/Judges";
        string judgeGroupController = "http://localhost:49820/api/JudgesGroups";
        string studentID = "studentId";
        string studentGroupID = "sGroupId";
        string judgeID = "judgeId";
        string judgeGroupID = "jGroupId";
        string judgeGroupKey = "jGroupKey";

        string propertyName = "";
        string accessPath = "";

        public List<int> finalIdList { get; set; }

        ObservableCollection<Student> studentList = new ObservableCollection<Student>();
        public ObservableCollection<Student> StudentList
        {
            get { return studentList; }
            set { studentList = value; }
        }

        ObservableCollection<object> displayList = new ObservableCollection<object>();
        public ObservableCollection<object> DisplayList
        {
            get { return displayList; }
            set { displayList = value; }
        }

        public string generateMagicKey()
        {
            string key = "abcdefghijklmnopqrstvuwxyz0123456789";
            char[] chars = new char[10];
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                chars[i] = key[random.Next(0, key.Length)];
            }
            Console.WriteLine("Key is: " + new string(chars));
            return new string(chars);
        }

        public void postJson(Object obj)
        {
            string message = "http://localhost:49820/api/JudgesGroups";
            var json = JsonConvert.SerializeObject(obj);
            HttpWebRequest request = HttpWebRequest.Create(message) as HttpWebRequest;
            if (!string.IsNullOrEmpty(json))
            {
                request.ContentType = "application/json";
                request.Method = "POST";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            Console.WriteLine("Jason is :" + json);

            using (HttpWebResponse webresponse = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(webresponse.GetResponseStream()))
                {
                    string response = reader.ReadToEnd();
                    Console.WriteLine(response);
                }
            }
            Console.ReadLine();
        }

        public void postObject(object obj)
        {
            Console.WriteLine(obj.GetType());

            switch (obj.GetType().ToString())
            {
                case "GUI_BusinessOdyssey.Entities.Student":
                    accessPath = studentController;
                    break;
                case "GUI_BusinessOdyssey.Entities.Judge":
                    accessPath = judgeController;
                    break;
                case "GUI_BusinessOdyssey.Entities.StudentGroup":
                    accessPath = studentGroupController;
                    break;
                case "GUI_BusinessOdyssey.Entities.JudgeTeam":
                    accessPath = judgeGroupController;
                    break;

            }
            try
            {
                using (var client = new WebClient())
                {
                    Uri uri = new Uri(accessPath);
                    var dataString = JsonConvert.SerializeObject(obj);
                    // Console.WriteLine(dataString);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                    Console.WriteLine("Send to DB" + dataString);

                    var returnval = client.UploadString(uri, "POST", dataString);
                    client.Dispose();

                    //var response = client.DownloadData(studentGroupController);
                }
            }
            catch (Exception ex)
            {

            }
        }


        public JArray getEntity(string entityName)
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
                case "judgeGroupID":
                    propertyName = judgeGroupID;
                    accessPath = judgeGroupController;
                    break;
                case "judgeKey":
                    propertyName = judgeGroupKey;
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
            JArray jArray = getEntity(entityName);

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

        public List<string> getKeyList(string entityName)
        {
            JArray jArray = getEntity(entityName);
            List<string> keyList = new List<string>();
            foreach (JObject jObject in jArray)
            {
                foreach (var property in jObject)
                {
                    if (property.Key == propertyName)
                    {
                        keyList.Add(property.Value.ToString());
                    }
                }
            }
            return keyList;
        }

        public string generateKey(List<string> keyList)
        {
            string uniqeKey = generateMagicKey();
            if (keyList.Count == 0 || !keyList.Contains(uniqeKey))
            {
                return uniqeKey;
            }
            else return generateKey(keyList);
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
