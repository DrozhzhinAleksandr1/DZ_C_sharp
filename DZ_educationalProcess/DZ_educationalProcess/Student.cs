using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_educationalProcess
{
    public class Student
    {
        public string name = string.Empty;
        public string surname = string.Empty;
        public int groupNumber = 0;
        public List<int> assessments = new List<int>() {};
        public Student(string name, string surname, int groupNumber)
        {
            this.name = name;
            this.surname = surname;
            this.groupNumber = groupNumber;
        }
        public void SayGroup()
        {
            Console.WriteLine(this.groupNumber);
        }
        public void SayAllAssessments()
        {
            Console.WriteLine(string.Join(" ", this.assessments.ToArray()));
        }
    }
}
