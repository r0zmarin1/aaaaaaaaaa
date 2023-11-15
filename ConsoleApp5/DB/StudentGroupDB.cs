using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp5.DB
{
    class StudentGroupDB
    {
        private readonly StudentDB studentDB;
        private readonly GroupDB groupDB;
        Dictionary<string, string> studentgroups;
        Dictionary<string, List<string>> studentgroups_list;

        public StudentGroupDB(StudentDB studentDB, GroupDB groupDB)
        {
            if (!File.Exists("students.json"))
                studentgroups = new Dictionary<string, string>();
            else
                using (FileStream fs = new FileStream("students.json", FileMode.OpenOrCreate))
                {
                    studentgroups = JsonSerializer.Deserialize<Dictionary<string, string>>(fs);
                }

            if (!File.Exists("groups.json"))
                studentgroups_list = new Dictionary<string, List<string>>();
            else
                using (FileStream fs = new FileStream("groups.json", FileMode.OpenOrCreate))
                {
                    studentgroups_list = JsonSerializer.Deserialize<Dictionary <string, List<string>>> (fs);
                }

            this.studentDB = studentDB;
            this.groupDB = groupDB;
        }

        public bool Add(string studentUID, string groupUID)
        {
            if (studentDB.GetStudentByUID(studentUID) == null)
            { 
                Console.WriteLine("error");
                return false;
            }
            if (groupDB.GetGroupByUID(groupUID) == null)
            {
                Console.WriteLine("error");
                return false;
            }

            studentgroups.Add(studentUID, groupUID);
            if (studentgroups.ContainsKey(groupUID)) 
                studentgroups_list[groupUID].Add(studentUID);
            else 
                studentgroups_list.Add(groupUID, new List<string>(new string[] {studentUID}));
            return true;
        }

        public Group GetGroupByStudent(string studentUID)
        {
            string uidG = studentgroups[studentUID];
            return groupDB.GetGroupByUID(uidG);
        }

        public List<Student> GetStudentByGroup(string groupUID)
        {
            List<Student> results = new List<Student>();
            List <string> uidS = studentgroups_list[groupUID];
            for (int i = 0; i < uidS.Count; i++)
            {
                string uid = uidS[i];
                results.Add(studentDB.GetStudentByUID(uid));
            }
            return results;

        }
    }
}
