using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_educationalProcess
{
    public class Teachers
    {
        public static List<Teacher> allTeacher = new List<Teacher>()
        {
            new Teacher("Umnii","Uchitel",1),
            new Teacher("Prosto","Prepod",2),
        };
        public static void AddTeacher(string name, string surname, int number)
        {
            allTeacher.Add(new Teacher(name, surname, number));
        }
        public static int SayTeacherIndex(string name, string surname)
        {
            for (var i = 0; i< allTeacher.Count; i++)
            {
                if(allTeacher[i].teacherName == name && allTeacher[i].teacherSurname == surname)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void SayAllStudentsOfTeacher(int index)
        {
            int group = allTeacher[index].teacherGroup;
            Console.WriteLine(" ");
            foreach (var student in Students.allStudents)
            {
                if (student.groupNumber == group)
                {
                    Console.WriteLine(student.name + " " + student.surname);
                }
            }
            Console.WriteLine(" ");
        }
        public static void AddAssessmentToStudentsOfTeacher(int indexTeacher, int indexStudent, int assessment)
        {
            if (allTeacher[indexTeacher].teacherGroup == Students.allStudents[indexStudent].groupNumber)
            {
                if(assessment < 0)
                {
                    assessment = 0;
                } else if (assessment > 5)
                {
                    assessment = 5;
                }
                Students.allStudents[indexStudent].assessments.Add(assessment);
            }
        }

    }
}
