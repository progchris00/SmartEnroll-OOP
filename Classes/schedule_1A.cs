using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualBasic.FileIO; // Make sure to add a reference to Microsoft.VisualBasic assembly
using Figgle;

namespace Itec102;
public class schedule_1A
{
    
    
    public static void ScheduleA()
    {
        
        // Specify the path to your CSV file
        string [] csvFilePath = File.ReadAllLines("data/schedule_1A.csv");
        var MainBox = new Box(38,5,130,61);
        MainBox.CreateBox();
        Console.SetCursorPosition(40,7);
        foreach(var SubjectCode in csvFilePath)
    {
        
        string [] fields = SubjectCode.Split(',');

        string storedSection = fields[0].Trim();
        string storedSubjCode = fields[1].Trim();
        string storedSubjTitle = fields[2].Trim();
        string storedUnits = fields[3].Trim();
        string storedTimeDate = fields[4].Trim();
       
       
        Console.WriteLine( $"{storedSection, -10} \t {storedSubjCode, -10} \t {storedSubjTitle, -40} \t {storedUnits, -10} \t {storedTimeDate, -20}"); // Keep the console window open
        Console.WriteLine();
        Console.SetCursorPosition(40, Console.CursorTop + 2); 
    } 
}
    }
    

