using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.IO;
namespace p7
{
    class program
    {
        static TeacherRepositary repositary = new TeacherRepositary();
        static void choice1()
        {
            repositary.getAllteachers();
        }
        static void choice2()
        {
            Console.Write("Enter teacher Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            TeacherModel s = repositary.getTeacherbyid(id);
            if (s is null)
                Console.WriteLine("Row is not exist");
            else
                Console.WriteLine($"{s.Tid} {s.Tname} {s.Tclass} {s.Tsection}");
        }

            static void choice3()
            {
                Console.Write("Enter Teacher class:");
                string Tclass = Console.ReadLine();
                List<TeacherModel> students = repositary.getTeacherbyclass(Tclass);
                foreach (TeacherModel s in students)
                    Console.WriteLine($"{s.Tid} {s.Tname} {s.Tclass} {s.Tsection}");
            }
            static void choice4()
            {
                Console.Write("Enter Section:");
                string section = Console.ReadLine();
                List<TeacherModel> students = repositary.getTeacherbysection(section);
                foreach (TeacherModel s in students)
                    Console.WriteLine($"{s.Tid} {s.Tname} {s.Tclass} {s.Tsection}");
            }
            static void choice5()
            {
                Console.Write("Enter id:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter n1:");
                string n1 = Console.ReadLine();
                Console.Write("Enter n2:");
                string n2 = Console.ReadLine();
                repositary.editTeacherrecord(id, n1, n2);
            }
            static void choice6()
            {
                TeacherModel s = new TeacherModel();
                Console.Write("Enter Teacher id:");
                s.Tid = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Teacher name:");
                s.Tname = Console.ReadLine();
                Console.Write("Enter Teacher class:");
                s.Tclass = Console.ReadLine();
                Console.Write("Enter Teacher section:");
                s.Tsection = Console.ReadLine();
                repositary.AddTeacher(s);
            }
            static void Main()
            {
                Console.WriteLine("Welcome to Rainbow School");
                Console.WriteLine("=============================");
                repositary.StoreTeachersList();
                int ch;
                do
                {
                    Console.WriteLine("=============================");
                    Console.WriteLine("Menu");
                    Console.WriteLine("1.Display All Records\n2.Display row by id\n3.Display row by class\n4.Display row by section\n5.edit row\n6.Add row\n7.exit");
                    Console.WriteLine("=============================");
                    Console.Write("Enter choice:");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            choice1();
                            break;
                        case 2:
                            choice2();
                            break;
                        case 3:
                            choice3();
                            break;
                        case 4:
                            choice4();
                            break;
                        case 5:
                            choice5();
                            break;
                        case 6:
                            choice6();
                            break;
                        case 7:
                            break;
                        default:
                            Console.WriteLine("Invalid input choice");
                            break;
                    }
                }
                while (ch != 7);
            }
        }
    }
