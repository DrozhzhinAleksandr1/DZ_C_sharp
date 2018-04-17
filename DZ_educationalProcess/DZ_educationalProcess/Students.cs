using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_educationalProcess
{
    public class Students
    {
        public static List<Student> allStudents = new List<Student>()
        {
            new Student("Vasia","Pupkin", 1),
            new Student("Nastia","Bulkin", 1),
            new Student("Katia","Pushkin", 1),
            new Student("Masha","Dudkin", 1),
            new Student("Vasia1","Pupkin1", 2),
            new Student("Nastia1","Bulkin1", 2),
            new Student("Katia1","Pushkin1", 2),
            new Student("Masha1","Dudkin1", 2),
        };
        public static void CreateStudent(string name, string surname, int number)
        {
            allStudents.Add(new Student(name, surname, number));
        }
        public static void SayWho(int index)
        {
            Console.WriteLine(allStudents[index].name + " " + allStudents[index].surname);
        }
        public static int GetIndex(string name, string surname)
        {
            for (var i = 0;i <= allStudents.Count;i++)
            {
                if(allStudents[i].name == name && allStudents[i].surname == surname)
                {
                    return i;
                } 
            }
            return -1;
        }
        public static void SayAllAssessmentsOfStudents(int index)
        {
            allStudents[index].SayAllAssessments();
        }
        public static void SayGroupOfStudents(int index)
        {
            allStudents[index].SayGroup();
        }
        public static void SayAllStudents()
        {
            Console.WriteLine(" ");
            foreach (var student in allStudents)
            {
                Console.WriteLine($"{student.name} {student.surname}");
            }
            Console.WriteLine(" ");
        }

    }
}
