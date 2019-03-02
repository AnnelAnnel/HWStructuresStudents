using RandomUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Students
{
    public class ServiceStudent
    {
        public List<Student> students = new List<Student>();
                
        private static Random rnd = new Random();
       
        public void addStudents()  //сразу 30 делаем
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Студенты поступают");
            Console.ForegroundColor = ConsoleColor.White;
            int k = 0;
            int g = 0;
            int e = 0;
            for (int i = 0; i < 30; i++)
            {
                var user = GenerateUser.GetUser();
                string fullname = user.name.title + " " + user.name.first;
                k = rnd.Next(0, 2);
                gender gender = (gender)k;
                string group = null;
                if (i<10)
                    group = "181.A";
                if (i >= 10 && i < 20)
                    group = "181.B";
                if (i >= 20)
                    group = "181.C";
                double avgGrade = rnd.Next(2, 13);
                double incomeFamily = rnd.Next(20000, 100000);
                g = rnd.Next(0, 2);
                studyMode studyMode = (studyMode)g;
                e = rnd.Next(0, 2);
                familyStatus familyStatus = (familyStatus)e;
                Student s = new Student(fullname, gender, group, avgGrade, incomeFamily, studyMode, familyStatus);
                students.Add(s);                
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Поступили");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
        }

        public void dormitoryShare()
        {            
            double avgAvg = students.Average(o => o.avgGrade);           
            double minSalary = 15000;            
            var tmp = students.OrderByDescending(i => i.avgGrade).ToList();
            int count1 = 1;
            int count2 = 0;
            Console.WriteLine("Первая очередь:\n" );
            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].incomeFamily < (2 * minSalary))
                {
                    count2++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}. ",count1++);
                    tmp[i].printInfo();
                    tmp.Remove(tmp[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }            
     
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--Всего {0} человек--", count2);
            Console.ForegroundColor = ConsoleColor.White;
        
            Console.WriteLine("\nВторая очередь:\n");            
            count1 = 1;
            var tmp2 = tmp.Where(x => x.avgGrade >= 8).ToList();
            for (int j = 0; j < tmp2.Count; j++)
            {              
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0}. ", count1++);
                tmp2[j].printInfo();

                Console.ForegroundColor = ConsoleColor.White;                
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--Всего {0} человек--", tmp2.Count);
            Console.ForegroundColor = ConsoleColor.White;
      
            Console.WriteLine("\nНе получили:\n");
            count1 = 1;
            var tmp3 = tmp.Where(x => x.avgGrade < 8).ToList();
            for (int j = 0; j < tmp3.Count; j++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0}. ", count1++);
                tmp3[j].printInfo();                
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--Всего {0} человек--", tmp3.Count);
            Console.ForegroundColor = ConsoleColor.White;
        }
     

        public void incompleteFamily()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Студенты из неполных семей");
            Console.ForegroundColor = ConsoleColor.White;
            int count1 = 1;
            List<Student> incomplete = new List<Student>();
            incomplete = students.Where(f => f.familyStatus == familyStatus.неполная).ToList();
            foreach (var item in incomplete)
            {
                Console.Write("{0}. ", count1++);
                item.printInfo();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--Всего {0} человек--", incomplete.Count);
            Console.ForegroundColor = ConsoleColor.White;
        }
    

        public void printByGrades()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Отличники:");
            Console.ForegroundColor = ConsoleColor.White;
            int count1 = 1;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].avgGrade > 9)
                {
                    Console.Write("{0}. ", count1++);
                    students[i].printInfo();
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--Всего {0} человек--", count1-1);
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Отстающие:");
            Console.ForegroundColor = ConsoleColor.White;
            
            count1 = 1;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].avgGrade <5)
                {
                    Console.Write("{0}. ", count1++);
                    students[i].printInfo();
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--Всего {0} человек--", count1-1);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void studentsInNeed()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Студенты из неполной семьи с самым низким доходом на члена семьи:");
            Console.ForegroundColor = ConsoleColor.White;            
        
            List<Student> incomplete = new List<Student>();
            incomplete = students.Where(f => f.familyStatus == familyStatus.неполная).ToList();
            var tmp = incomplete.OrderBy
                (i => i.incomeFamily).ToList();
            for (int i = 0; i < 3; i++)
            {                
               tmp[i].printInfo();
            }           
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Распределеить места в общежитии");
            Console.WriteLine("2. Список студентов из неполных семей");
            Console.WriteLine("3. Список отличников и отстающих");
            Console.WriteLine("4. Список студентов из неполных семей с самыми низкими доходами");
            Console.WriteLine("5. Выход");

            int choice = 0;
            bool isChoice = Int32.TryParse(Console.ReadLine(), out choice);
            if (isChoice)
            {
                if (choice == 1)
                {
                    Console.Clear();
                    dormitoryShare();                                    
                    Console.ReadKey();
                    MainMenu();
                }

                else if (choice == 2)
                {
                    Console.Clear();
                    incompleteFamily();
                    Console.ReadKey();
                    MainMenu();
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    printByGrades();
                    Console.ReadKey();
                    MainMenu();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    studentsInNeed();
                    Console.ReadKey();
                    MainMenu();
                }
                else if (choice == 5)
                    return;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введены некорректные данные");
                    Console.ForegroundColor = ConsoleColor.White;
                    MainMenu();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введены некорректные данные");
                Console.ForegroundColor = ConsoleColor.White;
                MainMenu();
            }
        }
    }
}