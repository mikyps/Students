﻿using StudentsConsoleApp.FileReaders;
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
            StudentsManager manager = new StudentsManager();
            try
            {                
                manager.StudentsList = CSVReader.ReadStudentFile("st.csv");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error trying to read the CSV file has occurred.");
            }

            Console.WriteLine("The CSV file has been read correctly... Press a key to continue");
            Console.ReadLine();
            Console.Clear();
            Menu mnu = new Menu(manager);
            mnu.Begin();

        }
    }
}
