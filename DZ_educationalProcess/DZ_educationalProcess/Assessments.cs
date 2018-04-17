using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_educationalProcess
{
    public class Assessments
    {
        public static void SayAllAssessments()
        {
            Console.WriteLine(" ");
            foreach (var student in Students.allStudents)
            {
                Console.WriteLine($"{student.name} {student.surname}");
                Console.WriteLine(string.Join(" ", student.assessments.ToArray()));
            }
            Console.WriteLine(" ");
        }
        public static void SayAverageRatingAllStudents()
        {
            List<int> allAssessments = new List<int>();
            foreach (var student in Students.allStudents)
            {
                foreach (var assessment in student.assessments)
                {
                    allAssessments.Add(assessment);
                }                
            }
            int allAssessmentsInt = 0;
            foreach (var assessment in allAssessments)
            {
                allAssessmentsInt += assessment;
            }
            Console.WriteLine(allAssessmentsInt / allAssessments.Count);
        }
        public static void SayAverageRatingAllStudentsOfGroup(int number)
        {
            List<int> allAssessments = new List<int>();
            foreach (var student in Students.allStudents)
            {
                if (number == student.groupNumber)
                {
                    foreach (var assessment in student.assessments)
                    {

                        allAssessments.Add(assessment);
                    }

                }
                
            }
            int allAssessmentsInt = 0;
            foreach (var assessment in allAssessments)
            {
                allAssessmentsInt += assessment;
            }
            Console.WriteLine(allAssessmentsInt / allAssessments.Count);
        }
    }
}
