using GUI_BusinessOdyssey.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_BusinessOdyssey.Management
{
    public class Office
    {
        Cypher cypher = new Cypher();
        string studentController = "http://localhost:63600//api/Students";
        string studentGroupController = "http://localhost:63600//api/StudentGroups";
        string judgeController = "http://localhost:63600//api/Judges";
        string judgeGroupController = "http://localhost:63600//api/JudgesGroups";
        string scheduleControler = "http://localhost:63600//api/Schedules";
        string scoreSheetRegisterController = "http://localhost:63600//api/ScoreSheetRegs";
        string scheduleMasterController = "http://localhost:63600//api/ScheduleMasters";

        string studentID = "studentId";
        string studentGroupID = "sGroupName";
        string judgeID = "judgeId";
        string judgeGroupID = "jGroupName";
        string judgeGroupKey = "jGroupKey";
        string studentGroupName = "sGroupName";
        string scheduleObject = "schedule";
        string scheduleMaster = "scheduleMaster";
        string scoreSheetRg = "ScoreSheetReg";

        public string studentName { get; set; }
        public string studentSchool { get; set; }
        public string groupName { get; set; }
        public int track { get; set; }
        public string judgeName { get; set; }

        List<string> sGroupNameList;
        List<string> jGroupNameList;

        // List<Student> tempStudentList;

        ObservableCollection<Schedule> scheduleList;
        public ObservableCollection<Schedule> ScheduleList
        {
            get { return scheduleList; }
            set { scheduleList = value; }
        }

        ObservableCollection<StudentGroup> displayStudents;
        public ObservableCollection<StudentGroup> DisplayStudents
        {
            get { return displayStudents; }
            set { displayStudents = value; }
        }

        ObservableCollection<JudgesGroup> displayJudgdes;
        public ObservableCollection<JudgesGroup> DisplayJudges
        {
            get { return displayJudgdes; }
            set { displayJudgdes = value; }
        }

        string propertyName = "";
        string accessPath = "";

        ObservableCollection<Student> studentList = new ObservableCollection<Student>();
        public ObservableCollection<Student> StudentList
        {
            get { return studentList; }
            set { studentList = value; }
        }

        ObservableCollection<object> judgeList = new ObservableCollection<object>();
        public ObservableCollection<object> JudgeList
        {
            get { return judgeList; }
            set { judgeList = value; }
        }

        ObservableCollection<List<ScoreSheetReg>> trackWinners = new ObservableCollection<List<ScoreSheetReg>>();

        public ObservableCollection<List<ScoreSheetReg>> TrackWinners
        {
            get { return trackWinners; }
            set { trackWinners = value; }
        }

        ObservableCollection<ScoreSheetReg> finalWinners = new ObservableCollection<ScoreSheetReg>();

        public ObservableCollection<ScoreSheetReg> FinalWinners
        {
            get { return finalWinners; }
            set { finalWinners = value; }
        }

        ObservableCollection<Schedule> scheduleListCollection = new ObservableCollection<Schedule>();

        public ObservableCollection<Schedule> ScheduleListCollection
        {
            get { return scheduleListCollection; }
            set { scheduleListCollection = value; }
        }

        List<ScoreSheetReg> trackFirst = new List<ScoreSheetReg>();
        List<ScoreSheetReg> trackSecond = new List<ScoreSheetReg>();
        List<ScoreSheetReg> trackThird = new List<ScoreSheetReg>();
        List<ScoreSheetReg> trackFourth = new List<ScoreSheetReg>();

        public Student createStudent()
        {
            Student student = new Student
            {
                StudentName = studentName,
                StudentSchool = studentSchool,
            };
            StudentList.Add(student);
            return student;
        }

        public StudentGroup createSGroup()
        {
            sGroupNameList = getPrimaryKeyList(studentGroupID);

            StudentGroup sGroup = new StudentGroup();
            sGroup.SGroupName = verifyStudentGroupName(sGroupNameList, groupName);
            sGroup.TrackId = track + 1;

            Console.WriteLine(sGroup.TrackId);

            foreach (Student s in StudentList)
            {
                s.SGroupName = sGroup.SGroupName;
                sGroup.Student.Add(s);
            }
            return sGroup;
        }

        public Judge createJudge()
        {
            Judge judge = new Judge
            {
                JudgeName = judgeName
            };
            JudgeList.Add(judge);
            return judge;
        }

        public JudgesGroup createJudgesGroup()
        {
            Console.WriteLine(cypher.Encrypt("gzjo38b7wr"));
            jGroupNameList = getPrimaryKeyList(judgeGroupID);
            JudgesGroup jGroup = new JudgesGroup
            {
                JGroupName = generateJudgeTeamName(jGroupNameList),
                JGroupKey = generateKey(jGroupNameList)
            };
            foreach (Judge j in JudgeList)
            {
                j.JGroupName = jGroup.JGroupName;
                jGroup.Judge.Add(j);
            }
            Console.WriteLine(jGroup.JGroupKey);

            return jGroup;
        }

        public string generateJudgeTeamName(List<string> list)
        {
            char[] charList = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T' };
            return charList[list.Count].ToString();
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

        public void groupView(string groups, string members)
        {
            DisplayStudents = new ObservableCollection<StudentGroup>();
            JArray jArray = getEntity(groups);
            foreach (JObject sg in jArray)
            {
                DisplayStudents.Add(sg.ToObject<StudentGroup>());
            }

            List<Student> sList = new List<Student>();
            JArray jArrayS = getEntity("studentId");
            foreach (JObject sg in jArrayS)
            {
                sList.Add(sg.ToObject<Student>());
            }

            foreach (StudentGroup sg in DisplayStudents)
            {
                foreach (Student s in sList)
                {
                    if (sg.SGroupName == s.SGroupName)
                    {
                        sg.Student.Add(s);
                    }
                }
            }
        }

        public void judgeGroupView(string groups, string members)
        {
            DisplayJudges = new ObservableCollection<JudgesGroup>();
            JArray jArray = getEntity(groups);
            foreach (JObject sg in jArray)
            {
                DisplayJudges.Add(sg.ToObject<JudgesGroup>());
            }

            List<Judge> memberList = new List<Judge>();
            JArray jArrayS = getEntity(members);
            foreach (JObject sg in jArrayS)
            {
                memberList.Add(sg.ToObject<Judge>());
            }

            foreach (JudgesGroup jg in DisplayJudges)
            {
                foreach (Judge j in memberList)
                {
                    if (jg.JGroupName == j.JGroupName)
                    {
                        jg.Judge.Add(j);
                    }
                }
            }
        }

        public ObservableCollection<Schedule> createTimeSchedule()
        {
            if (fillOutObjects().Count == 0)
            {
                scheduleList = new ObservableCollection<Schedule>
            {
                new Schedule() { ScheduleHour = new TimeSpan(10, 00, 00), ScheduleId = 1 },
                new Schedule() { ScheduleHour = new TimeSpan(10, 10, 00), ScheduleId = 2 },
                new Schedule() { ScheduleHour = new TimeSpan(10, 20, 00), ScheduleId = 3 },
                new Schedule() { ScheduleHour = new TimeSpan(10, 30, 00), ScheduleId = 4 },
                new Schedule() { ScheduleHour = new TimeSpan(10, 40, 00), ScheduleId = 5 },
                new Schedule() { ScheduleHour = new TimeSpan(10, 50, 00), ScheduleId = 6 },
                new Schedule() { ScheduleHour = new TimeSpan(11, 00, 00), ScheduleId = 7 },
                new Schedule() { ScheduleHour = new TimeSpan(10, 00, 00), ScheduleId = 8 },
                new Schedule() { ScheduleHour = new TimeSpan(11, 10, 00), ScheduleId = 9 },
                new Schedule() { ScheduleHour = new TimeSpan(11, 20, 00), ScheduleId = 10 },
                new Schedule() { ScheduleHour = new TimeSpan(11, 30, 00), ScheduleId = 11 },
                new Schedule() { ScheduleHour = new TimeSpan(11, 40, 00), ScheduleId = 12 },
                new Schedule() { ScheduleHour = new TimeSpan(11, 50, 00), ScheduleId = 13 },
                new Schedule() { ScheduleHour = new TimeSpan(12, 00, 00), ScheduleId = 14 }
            };

                JArray jjArray = getEntity("jGroupName");
                List<JudgesGroup> jGroups = new List<JudgesGroup>();

                foreach (JObject judgeGroup in jjArray)
                {
                    jGroups.Add(judgeGroup.ToObject<JudgesGroup>());
                }

                JArray sjArray = getEntity("sGroupName");
                List<StudentGroup> sGroups = new List<StudentGroup>();

                foreach (JObject studentGroup in sjArray)
                {
                    sGroups.Add(studentGroup.ToObject<StudentGroup>());
                }

                int scheduleCounter = 0;
                int judgeCounter = 0;
                int groupsPerJudgeTeam = roundUp(jGroups.Count, sGroups.Count);

                for (int i = 0; i < sGroups.Count; i++)
                {
                    ScheduleList[scheduleCounter].ScheduleMaster.Add(new ScheduleMaster()
                    {
                        ScheduleId = scheduleList[scheduleCounter].ScheduleId,
                        SGroupName = sGroups[i].SGroupName,
                        JGroupName = jGroups[judgeCounter].JGroupName,
                    });
                    scheduleCounter++;

                    if (scheduleCounter == groupsPerJudgeTeam)
                    {
                        scheduleCounter = 0;
                        judgeCounter++;
                    }
                }

                foreach (Schedule sch in ScheduleList)
                {
                    postJ(sch);
                }

                foreach (Schedule sch in ScheduleList)
                {
                    var json = JsonConvert.SerializeObject(sch);
                    Console.WriteLine(json);
                }
                displaySchedule();
            }
            else displaySchedule();
            return ScheduleList;
        }

        public List<Schedule> fillOutObjects()
        {
            JArray scheduleArray = getEntity(scheduleObject);
            Console.WriteLine(scheduleArray);
            List<Schedule> fullScheduleList = new List<Schedule>();
            foreach (JObject schedule in scheduleArray)
            {
                fullScheduleList.Add(schedule.ToObject<Schedule>());
            }

            JArray scheduleMasterArray = getEntity(scheduleMaster);
            List<ScheduleMaster> scheduleMasterList = new List<ScheduleMaster>();
            foreach (JObject scheduleMaster in scheduleMasterArray)
            {
                scheduleMasterList.Add(scheduleMaster.ToObject<ScheduleMaster>());
            }

            foreach (Schedule schedule in fullScheduleList)
            {
                foreach (ScheduleMaster scheduleMaster in scheduleMasterList)
                {
                    if (schedule.ScheduleId == scheduleMaster.ScheduleId)
                    {
                        schedule.ScheduleMaster.Add(scheduleMaster);
                    }
                }
            }
            return fullScheduleList;
        }

        public void displaySchedule()
        {
            List<Schedule> sList = fillOutObjects();
            foreach (Schedule schedule in sList)
            {
                ScheduleListCollection.Add(schedule);
            }
        }

        public void deleteSchedule()
        {
            List<Schedule> dList = fillOutObjects();
            foreach (Schedule schedule in dList)
            {
                foreach (ScheduleMaster sm in schedule.ScheduleMaster)
                {
                    deleteEntity("scheduleMaster", sm.ScheduleMasterId);
                }
                deleteEntity("schedule", schedule.ScheduleId);
            }
            ScheduleListCollection.Clear();
        }

        public void deleteEntity(String objType, int id)
        {
            setAccessPathEntity(objType);
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(accessPath + "/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Error");
                };
            }
        }

        public bool postJ(Object obj)
        {
            setAccessPath(obj);
            try
            {
                string webAddr = accessPath;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(obj);
                    Console.WriteLine("sending to server " + json);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    Console.WriteLine("Server response: " + responseText);
                    Console.WriteLine("******************************");
                    MessageBox.Show("Success!!!");
                }
                return true;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
                return false;
            }
        }

        public void setAccessPath(object obj)
        {
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
                case "GUI_BusinessOdyssey.Entities.Schedule":
                    accessPath = scheduleControler;
                    break;
            }
        }

        public int roundUp(int a, int b)
        {
            int result = b / a;
            if (b % a != 0)
            {
                return result + 1;
            }
            else return result;
        }

        public void postObject(object obj)
        {
            setAccessPath(obj);
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
                    //client.Dispose();

                    //var response = client.DownloadData(studentGroupController);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        public void setAccessPathEntity(string entityName)
        {
            switch (entityName)
            {
                case "studentId":
                    propertyName = studentID;
                    accessPath = studentController;
                    break;
                case "sGroupId":
                    propertyName = studentGroupID;
                    accessPath = studentGroupController;
                    break;
                case "sGroupName":
                    propertyName = studentGroupName;
                    accessPath = studentGroupController;
                    break;
                case "judgeId":
                    propertyName = judgeID;
                    accessPath = judgeController;
                    break;
                case "jGroupName":
                    propertyName = judgeGroupID;
                    accessPath = judgeGroupController;
                    break;
                case "judgeKey":
                    propertyName = judgeGroupKey;
                    accessPath = judgeGroupController;
                    break;
                case "schedule":
                    propertyName = judgeGroupKey;
                    accessPath = scheduleControler;
                    break;
                case "scheduleMaster":
                    propertyName = scheduleMaster;
                    accessPath = scheduleMasterController;
                    break;
                case "ScoreSheetReg":
                    propertyName = scoreSheetRg;
                    accessPath = scoreSheetRegisterController;
                    break;
            }
        }

        public JArray getEntity(string entityName)
        {
            setAccessPathEntity(entityName);

            WebClient client = new WebClient();
            var response = client.DownloadString(accessPath);
            string resp = JsonConvert.ToString(response);

            dynamic studentGroups = JsonConvert.DeserializeObject<dynamic>(resp);

            JArray jArray = JArray.Parse(studentGroups);

            return jArray;
        }

        public JObject getScoresheet()
        {
            WebClient client = new WebClient();
            var response = client.DownloadString("http://localhost:63600//api/ScoreSheetRegs/1");
            Console.WriteLine(JsonConvert.ToString(response));
            string resp = JsonConvert.ToString(response);

            dynamic studentGroups = JsonConvert.DeserializeObject<dynamic>(resp);

            JObject jArray = JObject.Parse(studentGroups);

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

        public List<string> getPrimaryKeyList(string entityName)
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

        public string verifyStudentGroupName(List<string> groupNames, string groupName)
        {
            if (groupNames.Count == 0 || !groupNames.Contains(groupName))
            {
                return groupName;
            }
            else
            {
                MessageBox.Show("You must enter uniqe group name");
                return null;
            };
        }

        public char generateJudgeTeamName(int id)
        {
            char[] charList = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T' };
            return charList[id - 1];
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
            int id = 0;
            if (idList.Count != 0)
            {
                idList.Sort();
                id = idList[idList.Count - 1] + 1;
                return id;
            }
            else return 1;
        }

        public ScoreSheetReg findWinner()
        {
            List<ScoreSheetReg> grandeFinale = new List<ScoreSheetReg>();
            JArray array = getEntity("ScoreSheetReg");

            foreach (JObject obj in array)
            {
                ScoreSheetReg scoreSheetRegister = obj.ToObject<ScoreSheetReg>();

                if (scoreSheetRegister.TrackId == 1)
                {
                    trackFirst.Add(scoreSheetRegister);
                }
                else if (scoreSheetRegister.TrackId == 2)
                {
                    trackSecond.Add(scoreSheetRegister);
                }
                else if (scoreSheetRegister.TrackId == 3)
                {
                    trackThird.Add(scoreSheetRegister);
                }
                else
                {
                    trackFourth.Add(scoreSheetRegister);
                }
            }

            List<List<ScoreSheetReg>> clasifiedByTrackSGroups = new List<List<ScoreSheetReg>>();
            clasifiedByTrackSGroups.Add(trackFirst);
            clasifiedByTrackSGroups.Add(trackSecond);
            clasifiedByTrackSGroups.Add(trackThird);
            clasifiedByTrackSGroups.Add(trackFourth);

            foreach (var trackSGroups in clasifiedByTrackSGroups)
            {
                if (trackSGroups.Count != 0)
                {
                    addTrackWinners(trackSGroups, TrackWinners);
                }
            }

            foreach (var trackList in trackWinners)
            {
                foreach (var scoresheetRegister in trackList)
                {
                    Console.WriteLine("The winner in the track" + scoresheetRegister.TrackId + " is: " + scoresheetRegister.SGroupName + scoresheetRegister.Points);
                    grandeFinale.Add(scoresheetRegister);
                }
            }

            findFinalWinner(grandeFinale);
            return null;
        }

        public void findFinalWinner(List<ScoreSheetReg> list)
        {
            var maxPoints = list.Max(obj => obj.Points);
            var winnerTeam = list.Where(obj => obj.Points == maxPoints);
            foreach (var ScoreSheetReg in winnerTeam)
            {
                Console.WriteLine("The final winner is: " + ScoreSheetReg.SGroupName + " " + "Points " + ScoreSheetReg.Points);
                FinalWinners.Add(ScoreSheetReg);
            }
        }

        public void addTrackWinners(List<ScoreSheetReg> objectList, ObservableCollection<List<ScoreSheetReg>> winnersList)
        {
            List<ScoreSheetReg> templist = new List<ScoreSheetReg>();
            var maxPoints = objectList.Max(obj => obj.Points);
            var maxObj = objectList.Where(obj => obj.Points == maxPoints);
            foreach (var scR in maxObj)
            {
                templist.Add(scR);
            };

            winnersList.Add(templist);
        }
    }
}
