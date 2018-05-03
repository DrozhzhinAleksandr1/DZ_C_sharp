using DZ_educationalProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.ConsoleMenu
{
    class MyMenu
    {
        public delegate void MenuDelegate(int idTeacher, int idStudent, int assesment);        
        private List<MenuItem> items = new List<MenuItem>();
        public MyMenu()
        {
            foreach(var student in Students.allStudents)
            {
                AddMenuItem(student, Teachers.AddAssessmentToStudentsOfTeacher);
            }            
        }
        class MenuItem
        {
            public Student NewStudent;
            public event MenuDelegate Action;
            public void DoWork(int idTeacher, int idStudent, int assesment)
            {
                Action?.Invoke(idTeacher, idStudent, assesment);
            }
        }
        public void AddMenuItem(Student newStudent, MenuDelegate d)
        {
            // фирст ор дефаулт выбирает первый элемент устраивающий условия
            // если дефаулта нету то не чего не вернет
            MenuItem item = items.FirstOrDefault(x => x.NewStudent.Equals(newStudent) == true);
            if (item != null)
            {
                // существующему элементу добавляем метод
                item.Action += d;
            }
            else
            {
                // добавляем новый элемент
                MenuItem newItem = new MenuItem { NewStudent = newStudent };
                newItem.Action += d;
                items.Add(newItem);
            }
        }
        public void Run(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            int counter = 0;
            Console.Clear();
            for (; ;)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    if (counter == i)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("===> ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write("     ");
                    }
                    Console.Write(items[i].NewStudent.name +" "+ items[i].NewStudent.surname + " ");
                    foreach (var assesment in items[i].NewStudent.assessments)
                    {
                        Console.Write(assesment + " ");
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.UpArrow:
                        --counter;
                        break;
                    case ConsoleKey.DownArrow:
                        ++counter;
                        break;
                    case ConsoleKey.D1:
                        items[counter].DoWork(0, counter, 1);
                        break;
                    case ConsoleKey.D2:
                        items[counter].DoWork(0, counter, 2);
                        break;
                    case ConsoleKey.D3:
                        items[counter].DoWork(0, counter, 3);
                        break;
                    case ConsoleKey.D4:
                        items[counter].DoWork(0, counter, 4);
                        break;
                    case ConsoleKey.D5:
                        items[counter].DoWork(0, counter, 5);
                        break;
                }
                if (counter < 0)
                {
                    counter = items.Count - 1;
                }
                if (counter >= items.Count)
                {
                    counter = 0;
                }
                Console.Clear();
            }
        }
    }
}
