using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GUI_BusinessOdyssey.Management
{
    class Office
    {
        string getStudentGroup = "http://localhost:55290/api/studentGroups";
        string studentGroupID = "sGroupId";
        string propertyName = "";
        string accessPath = "";

        public JArray getStudentGroups(string entityName)
        {

            switch (entityName)
            {
                case "student":                   
                    propertyName = "StudentId";
                    break;
                case "studentGroup":
                    propertyName = studentGroupID;
                    accessPath = getStudentGroup;
                    break;
                case "judge":
                    entityName = "JudgeId";
                    break;
                case "judgeGroup":
                    entityName = "JGroupId";
                    break;
            }


            WebClient client = new WebClient();
            var response = client.DownloadString(getStudentGroup);
            string resp = JsonConvert.ToString(response);

            dynamic studentGroups = JsonConvert.DeserializeObject<dynamic>(resp);
            Console.WriteLine("***" + studentGroups.ToString());

            JArray jArray = JArray.Parse(studentGroups);
            return jArray;
        }

        public List<int> getIDsList(string entityName)
        {
            
            JArray jArray = getStudentGroups(entityName);

            List<int> idList = new List<int>();
            foreach(JObject jObject in jArray) 
            {
               foreach(var property in jObject)
                {
                   if( property.Key == propertyName)
                    {
                        idList.Add(int.Parse(property.Value.ToString()));
                    }
                }
                
            }
            /*
            foreach(int i in idList)
            {
                Console.WriteLine(i);

            }*/
            return idList;
        }

        public int generateID(string entityName)
        {
            List<int> idList = getIDsList(entityName);
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
