using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualBasic.FileIO; // Make sure to add a reference to Microsoft.VisualBasic assembly
using Figgle;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace Itec102.StudentManagementSystem
{
    public class CertifcateOfRegistration
    {
        public static void Display(string currentUserYear, string currentUserSection)
        {
            var mainBox = new Box(38,5,130,61);
            string[] certificate = File.ReadAllLines($"data/{currentUserYear}{currentUserSection}_COR.csv");

            mainBox.CreateBox();

            Console.SetCursorPosition(40,7);

            foreach(var rowOfSubjects in certificate)
            {
                string[] fields = rowOfSubjects.Split(',');

                string storedSection = fields[0].Trim();
                string storedSubjCode = fields[1].Trim();
                string storedSubjTitle = fields[2].Trim();
                string storedUnits = fields[3].Trim();
                string storedTimeDate = fields[4].Trim();

                Console.WriteLine( $"{storedSection, -10} \t {storedSubjCode, -10} \t {storedSubjTitle, -40} \t {storedUnits, -10} \t {storedTimeDate, -20}");
                Console.WriteLine();
                Console.SetCursorPosition(40, Console.CursorTop + 2); 
            } 
        }
    }
}