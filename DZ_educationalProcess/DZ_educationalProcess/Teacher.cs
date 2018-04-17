using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_educationalProcess
{
    public class Teacher
    {
        public string teacherName = string.Empty;
        public string teacherSurname = string.Empty;
        public int teacherGroup = 0;
        public Teacher(string name, string surname, int group)
        {
            this.teacherName = name;
            this.teacherSurname = surname;
            this.teacherGroup = group;
        }
    }
}
