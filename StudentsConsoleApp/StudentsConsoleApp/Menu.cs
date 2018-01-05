using StudentsFactory;
using StudentsProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentsConsoleApp
{
    public class Menu
    {
        private StudentsManager StudentsMngr { get; set; }

        public Menu(StudentsManager mgrList)
        {
            StudentsMngr = mgrList;
        }

        private void DisplayMenu()
        {
            Console.WriteLine("--Students Manager--");
            Console.WriteLine();
            Console.WriteLine("1. Display all the students.");
            Console.WriteLine("2. Delete a student by name.");
            Console.WriteLine("3. Search by name.");
            Console.WriteLine("4. Search by student type (kinder, elementary, high, university).");
            Console.WriteLine("5. Search by student type and gender (Male/Female).");
            Console.WriteLine("6. Exit.");
            Console.WriteLine();
        }

        public void Begin()
        {
            string option = "";
            do
            {
                this.DisplayMenu();
                option = Regex.Match(Console.ReadLine(), @"\d+").Value;
                ProcessOption(option);
            } while (option != "6");

        }

        private void ProcessOption(string option)
        {
            switch (option)
            {
                case "1":
                    DisplayAllStudents(StudentsMngr.StudentsList);
                    break;
                case "2":
                    ProcessDelete();
                    break;
                case "3":
                    ProcessSearchByName();
                    break;
                case "4":
                    ProcessSearchByType();
                    break;
                case "5":
                    ProcessSearchByTypeAndGender();
                    break;
            }

        }

        private void ProcessSearchByTypeAndGender()
        {
            Console.WriteLine("Please insert the Type and Gender: (ex. kinder male)");
            string line = Console.ReadLine();
            string[] opts = line.Split(' ');

            StudentType enumType = StudentType.Elementary;

            if (opts[0].ToLower().Contains("kinder"))
            {
                enumType = StudentType.Kinder;
            }
            else if (opts[0].ToLower().Contains("elementary"))
            {
                enumType = StudentType.Elementary;
            }
            else if (opts[0].ToLower().Contains("high"))
            {
                enumType = StudentType.High;
            }
            else if (opts[0].ToLower().Contains("university"))
            {
                enumType = StudentType.University;
            }


            var sList = this.StudentsMngr.SearchByGenderAndType(opts[1], enumType);
            if (sList == null || sList.Count == 0)
                Console.WriteLine("The student type or gender does not exist.");
            else
                DisplayAllStudents(sList);
        }

        private void ProcessSearchByType()
        {
            Console.WriteLine("Please insert the Type:");
            string stype = Console.ReadLine();
            StudentType enumType = StudentType.Elementary;

            if (stype.ToLower().Contains("kinder"))
            {
                enumType = StudentType.Kinder;
            }
            else if (stype.ToLower().Contains("elementary"))
            {
                enumType = StudentType.Elementary;
            }
            else if (stype.ToLower().Contains("high"))
            {
                enumType = StudentType.High;
            }
            else if (stype.ToLower().Contains("university"))
            {
                enumType = StudentType.University;
            }


            var sList = this.StudentsMngr.SearchByType(enumType);
            if (sList == null || sList.Count == 0)
                Console.WriteLine("The student type does not exist.");
            else
                DisplayAllStudents(sList);
        }

        private void ProcessSearchByName()
        {
            Console.WriteLine("Please insert the Name:");
            string sname = Console.ReadLine();
            var sList = this.StudentsMngr.SearchByName(sname);
            if (sList == null || sList.Count == 0)
                Console.WriteLine("The student does not exist.");
            else
                DisplayAllStudents(sList);
        }

        private void ProcessDelete()
        {
            Console.WriteLine("Please insert the Name:");
            string dname = Console.ReadLine();
            if (!this.StudentsMngr.Delete(dname))
                Console.WriteLine("The student does not exist.");
            DisplayAllStudents(StudentsMngr.StudentsList);
        }

        private void DisplayAllStudents(List<Student> stdList)
        {
            Console.WriteLine("--Type-- --Name-- --Gender-- --Date--");
            foreach (var student in stdList)
            {
                DisplaySingleStudent(student);
            }
            Console.ReadLine();
            Console.Clear();
        }

        private void DisplaySingleStudent(Student student)
        {
            Console.WriteLine(String.Format(" {0} - {1} - {2} - {3} ", GetTypeString(student.SType), student.Name, student.Gender, student.RegistrationDate.ToString("MM/dd/yyyy HH:mm:ss")));
        }

        private string GetTypeString(StudentType stype)
        {
            string stType = String.Empty;
            switch (stype)
            {
                case StudentType.Elementary:
                    stType = "Elementary";
                    break;
                case StudentType.High:
                    stType = "High";
                    break;
                case StudentType.Kinder:
                    stType = "Kinder";
                    break;
                case StudentType.University:
                    stType = "University";
                    break;
            }
            return stType;
        }


    }
}
