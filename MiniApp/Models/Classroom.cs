using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApp.Models
{
    using MiniApp.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Classroom
    {
        private static int nextId = 1;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public ClassType Type { get; private set; }
        public List<Student> Students { get; private set; }

        public Classroom(string name, ClassType type)
        {
            Id = nextId++;
            Name = name;
            Type = type;
            Students = new List<Student>();
        }

        public void StudentAdd(Student student)
        {
            if ( Helper.IsValidName(student.Name) && Helper.IsValidSurname(student.Surname))
            {
                Students.Add(student);
            }
            else
            {
                throw new Exception("Yanlish ad ve soyad  olduguna gore telebe elave oluna bilmədi.");
            }
        }

       
    }

}
