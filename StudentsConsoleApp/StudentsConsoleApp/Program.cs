using StudentsConsoleApp.FileReaders;
using StudentsFactory;
using StudentsProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StudentsManager manager = new StudentsManager();
                manager.StudentsList = CSVReader.ReadStudentFile("st.csv");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error trying to read the csv file occured.");
            }

            Console.WriteLine("The CSV file has been read correctly...");

        }
    }
}
