using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsFactory
{
    public enum StudentType
    {
        Kinder, Elementary, High, University
    }

    public abstract class Student
    {
        public StudentType SType { get; set; }
        public String Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public String Gender { get; set; }

        public abstract void CreateStudent(String name, DateTime regDate, String gender);
    }
}
