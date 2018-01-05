using StudentsFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProcessor
{
    public class StudentsManager
    {
        public List<Student> StudentsList { get; set; }

        public bool Delete(string name)
        {
            bool done = false;
            var std = StudentsList.Where(i => i.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
            done = StudentsList.Remove(std);
            return done;
        }

        public List<Student> SearchByName(string name)
        {
            List<Student> result = new List<Student>();
            result = StudentsList.Where(i => i.Name.ToLower().Contains(name.ToLower())).OrderBy(o => o.Name).ToList();
            return result;
        }

        public List<Student> SearchByType(StudentType stype)
        {
            List<Student> result = new List<Student>();
            
            Type otype = null;
            switch (stype)
            {
                case StudentType.Elementary:
                    otype = new ElementaryStudent().GetType();
                    break;
                case StudentType.High:
                    otype = new HighStudent().GetType();
                    break;
                case StudentType.Kinder:
                    otype = new KinderStudent().GetType();
                    break;
                case StudentType.University:
                    otype = new UniversityStudent().GetType();
                    break;
            }

            result = StudentsList.Where(i => i.GetType().Equals(otype)).OrderByDescending(o => o.RegistrationDate).ToList();
            return result;
        }

        public List<Student> SearchByGenderAndType(string gender,StudentType stype)
        {
            List<Student> result = new List<Student>();

            Type otype = null;
            switch (stype)
            {
                case StudentType.Elementary:
                    otype = new ElementaryStudent().GetType();
                    break;
                case StudentType.High:
                    otype = new HighStudent().GetType();
                    break;
                case StudentType.Kinder:
                    otype = new KinderStudent().GetType();
                    break;
                case StudentType.University:
                    otype = new UniversityStudent().GetType();
                    break;
            }

            result = StudentsList.Where(i => i.GetType().Equals(otype) && i.Gender.ToLower().Equals(gender.ToLower())).OrderByDescending(o => o.RegistrationDate).ToList();
            return result;
        }
    }
}
