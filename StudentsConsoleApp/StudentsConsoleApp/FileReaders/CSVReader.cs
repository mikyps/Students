
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Globalization;
using StudentsFactory;

namespace StudentsConsoleApp.FileReaders
{
    public class CSVReader
    {
        public static List<Student> ReadStudentFile(string fileName)
        {
            List<Student> stList = new List<Student>();
            var path = "..//..//Files//st.csv";
            if (File.Exists(path))
            {
                using (TextFieldParser parser = new TextFieldParser(path))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        string name = fields[1];
                        string gender = fields[2].ToLower().Equals("M") ? "Male" : "Female";
                        var regDate = DateTime.ParseExact(fields[3], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                        switch (fields[0].ToLower())
                        {
                            case "kinder":
                                var kstudent = new KinderStudent();
                                kstudent.CreateStudent(name, regDate, gender);
                                stList.Add(kstudent);
                                break;
                            case "high":
                                var hstudent = new HighStudent();
                                hstudent.CreateStudent(name, regDate, gender);
                                stList.Add(hstudent);
                                break;
                            case "university":
                                var ustudent = new UniversityStudent();
                                ustudent.CreateStudent(name, regDate, gender);
                                stList.Add(ustudent);
                                break;
                            case "elementary":
                                var estudent = new ElementaryStudent();
                                estudent.CreateStudent(name, regDate, gender);
                                stList.Add(estudent);
                                break;
                        }
                    }
                }
            }

            return stList;
        }
    }
}
