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

        public JArray getStudentGroups()
        {
            WebClient client = new WebClient();
            var response = client.DownloadString("http://localhost:55290/api/studentGroups");
            string resp = JsonConvert.ToString(response);

            dynamic studentGroups = JsonConvert.DeserializeObject<dynamic>(resp);
            Console.WriteLine("***" + studentGroups.ToString());

            JArray jArray = JArray.Parse(studentGroups);
            return jArray;
        }

        public List<int> getIDsList(string entityName)
        {
            
            switch (entityName)
            {
                case "student":
                    entityName = "StudentId";
                    break;
                case "studentGroup":
                    entityName = "SGroupName";
                    break;
                case "judge":
                    entityName = "JudgeId";
                    break;
                case "judgeGroup":
                   entityName = "JGroupId";
                    break;
            }
            JArray jArray = getStudentGroups();
            List<int> idList = new List<int>();
            foreach(JObject jObject in jArray) 
            {
               foreach(var property in jObject)
                {
                   if( property.Key == entityName)
                    {
                        idList.Add(int.Parse(property.Value.ToString()));
                    }
                }
                
            }
            foreach(int i in idList)
            {
                Console.WriteLine(i);

            }
            return idList;
        }

        public int generateID(string entity)
        {
            List<int> idList = getIDsList(entity);
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
