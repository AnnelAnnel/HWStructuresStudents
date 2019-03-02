using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public enum studyMode { очная, заочная };
    public enum familyStatus { полная, неполная };
    public enum gender { женский, мужской};

    public struct Student
    {
        public string fullname { get; set; }
        public gender gender { get; set; }
        public string group { get; set; }
        public double avgGrade { get; set; }
        public double incomeFamily { get; set; }
        public studyMode studyMode { get; set; }
        public familyStatus familyStatus { get; set; }
       

        public Student(string fullname, gender gender, string group, double avgGrade, double incomeFamily, studyMode studyMode,
            familyStatus familyStatus)
        {
            this.fullname = fullname;
            this.gender = gender;
            this.group = group;
            this.avgGrade = avgGrade;
            this.incomeFamily = incomeFamily;
            this.studyMode = studyMode;
            this.familyStatus = familyStatus;
        }

        public void printInfo()
        {            
            Console.WriteLine("Студент {0}", fullname);           
            Console.WriteLine("Пол: {0}", gender);
            Console.WriteLine("Группа: {0}", group);
            Console.WriteLine("Форма обучения: {0}", studyMode);
            Console.WriteLine("Средняя оценка: {0}", avgGrade);
            Console.WriteLine("Статус семьи: {0}", familyStatus);
            Console.WriteLine("Доход на члена семьи:{0}\n", incomeFamily);
        }               
    }
}