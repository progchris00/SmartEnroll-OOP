using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualBasic.FileIO; // Make sure to add a reference to Microsoft.VisualBasic assembly
namespace Itec102;
public class schedule_1B
{
    public static void ScheduleB()
    {
        // Specify the path to your CSV file
        string [] csvFilePath = File.ReadAllLines("schedule_1B.csv");

        foreach(var SubjectCode in csvFilePath)
        
    {
        string [] fields = SubjectCode.Split(',');
        
        Console.SetCursorPosition(40,2);

        string storedSection = fields[0];
        string storedSubjCode = fields[1].Trim();
        string storedSubjTitle = fields[2].Trim();
        string storedUnits = fields[3].Trim();
        string storedTimeDate = fields[4].Trim();

        

        Console.WriteLine($"{storedSection, -20} \t {storedSubjCode, -15} \t {storedSubjTitle, -50} \t {storedUnits, -10} \t {storedTimeDate, -20}"); // Keep the console window open
        Console.WriteLine();
        
    }
    Console.ReadKey();
}
}
