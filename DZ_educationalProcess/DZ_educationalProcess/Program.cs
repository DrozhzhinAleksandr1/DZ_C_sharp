using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_educationalProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            Students.SayAllStudents();
            int studentId = Students.GetIndex("Nastia1", "Bulkin1");
            Students.SayWho(studentId);
            Students.SayAllAssessmentsOfStudents(studentId);
            Students.SayGroupOfStudents(studentId);

            Students.CreateStudent("Black","Man", 2);

            Students.SayAllStudents();

            int newStudentId = Students.GetIndex("Black", "Man");
            Students.SayAllAssessmentsOfStudents(newStudentId);

            int teacherIndex = Teachers.SayTeacherIndex("Prosto", "Prepod");
            Teachers.SayAllStudentsOfTeacher(teacherIndex);
            
            Teachers.AddAssessmentToStudentsOfTeacher(teacherIndex, newStudentId, 100);
            Teachers.AddAssessmentToStudentsOfTeacher(teacherIndex, newStudentId, 4);
            Teachers.AddAssessmentToStudentsOfTeacher(teacherIndex, newStudentId, 3);
            Teachers.AddAssessmentToStudentsOfTeacher(teacherIndex, newStudentId, -12);
            Students.SayAllAssessmentsOfStudents(newStudentId);

            Teachers.AddAssessmentToStudentsOfTeacher(1, 5, 4);
            Teachers.AddAssessmentToStudentsOfTeacher(0, 1, 4);
            Teachers.AddAssessmentToStudentsOfTeacher(0, 3, 3);
            Teachers.AddAssessmentToStudentsOfTeacher(1, 6, 3);

            Assessments.SayAllAssessments();
            Assessments.SayAverageRatingAllStudents();
            Console.WriteLine("---------");
            Assessments.SayAverageRatingAllStudentsOfGroup(1);
            Assessments.SayAverageRatingAllStudentsOfGroup(2);
        }
    }
}
