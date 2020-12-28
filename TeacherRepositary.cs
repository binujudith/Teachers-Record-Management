using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
namespace p7
{
    class TeacherRepositary
    {
        List<TeacherModel> teachers;
        public TeacherRepositary()
        {
            this.teachers = new List<TeacherModel>
                {
                new TeacherModel { Tid = 101, Tname = "Binu Judith", Tclass = "Maths", Tsection = "A" },
                new TeacherModel { Tid = 102, Tname = "Anit", Tclass = "CSE", Tsection = "B" },
                new TeacherModel { Tid = 103, Tname = "Hepsiba", Tclass = "Civil", Tsection = "A" },
                new TeacherModel { Tid = 104, Tname = "Sugan", Tclass = "EEE", Tsection = "A" },
                new TeacherModel { Tid = 105, Tname = "Jegan", Tclass = "ECE", Tsection = "B" }
            };
        }
        public void StoreTeachersList()
        {
            StreamWriter fname = new StreamWriter("d:/TrRec.txt");
            foreach (TeacherModel s in teachers)
                fname.WriteLine($"{s.Tid} {s.Tname} {s.Tclass} {s.Tsection}");
            Console.WriteLine("Teachers records stored Successfully");
            fname.Close();
        }
        public void getAllteachers()
        {
            StreamReader sr = new StreamReader(@"d:/TrRec.txt");
            string msg = sr.ReadToEnd();
            Console.Write(msg);
            sr.Close();
        }
        public TeacherModel getTeacherbyid(int id)
        {
            TeacherModel s = null;
            for (int i = 0; i < teachers.Count; i++)
                if (teachers[i].Tid == id)
                {
                    s = teachers[i];
                    break;
                }
            return s;
        }
        public List<TeacherModel> getTeacherbyclass(string department)
        {
            List<TeacherModel> teachers = new List<TeacherModel>();
            for (int i = 0; i < this.teachers.Count; i++)
                if (this.teachers[i].Tclass == department)
                    teachers.Add(this.teachers[i]);
            return teachers;
        }
        public List<TeacherModel> getTeacherbysection(string section)
        {
            List<TeacherModel> teachers = new List<TeacherModel>();
            for (int i = 0; i < this.teachers.Count; i++)
                if (this.teachers[i].Tsection == section)
                    teachers.Add(this.teachers[i]);
            return teachers;
        }
        public void editTeacherrecord(int id,string n1, string n2)
         {
             StreamReader sr = new StreamReader("d:TrRec.txt",true);
             string msg = sr.ReadToEnd();
             sr.Close();
             if (msg.Contains((char)id))
             {
                 msg = Regex.Replace(msg, n1, n2);
                 Console.WriteLine("The Row has been edited successfully");
             }
             StreamWriter fname = new StreamWriter("d:TrRec.txt");
             fname.Write(msg);
             fname.Close();
         }
        public void AddTeacher(TeacherModel s)
        {
            StreamWriter fname = new StreamWriter(@"d:/TrRec.txt", true);
            fname.WriteLine($"{s.Tid} {s.Tname} {s.Tclass} {s.Tsection}");
            fname.Close();
        }
    }
}