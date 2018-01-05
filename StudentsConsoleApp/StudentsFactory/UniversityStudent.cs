using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsFactory
{
    public class UniversityStudent : Student
    {
        public override void CreateStudent(String name, DateTime regDate, String gender)
        {
            this.SType = StudentType.University;
            this.Name = name;
            this.RegistrationDate = regDate;
            this.Gender = gender;

        }
    }
}
