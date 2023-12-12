﻿using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualBasic.FileIO; // Make sure to add a reference to Microsoft.VisualBasic assembly
using Figgle;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace Itec102;
public class Schedule
{
    public static void Show(string section)
    {
        // Specify the path to your CSV file
        string[] csvFilePath = {};
        if (section == "1A")
        {
            csvFilePath = File.ReadAllLines("data/1A_Schedule.csv");
        }
        else if (section == "1B")
        {
            csvFilePath = File.ReadAllLines("data/1B_Schedule.csv");
        }

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

    public static void Today(string DayToday, string DateToday)
    {
        Console.SetCursorPosition(82, 7); 
        Console.WriteLine($"{DayToday}, {DateToday}");

        if (DayToday == "Sunday")
        {
            Console.SetCursorPosition(54, 14); 
            Console.WriteLine("There are no classes scheduled for today.");
        }
        else
        {
            string[] csvFilePath = {};
            csvFilePath = File.ReadAllLines("data/Schedule.csv");
            
            int top = 13;
            foreach(var SubjectCode in csvFilePath)
            {
                string[] fields = SubjectCode.Split(',');

                string SubjectToday = fields[0].Trim();
                string UserSection = fields[4].Trim();
                
                Console.SetCursorPosition(58, 10); 
                Console.WriteLine("SUBJECT\t\tTIME");
                if (SubjectToday == DayToday && UserSection == Session.GetCurrentUserSection(Session.GetCurrentUser())) 
                {
                    string storedSubjectCode = fields[1].Trim();
                    string storedSubjectTitle = fields[2].Trim();
                    string storedTimeDate = fields[3].Trim();
                    Console.SetCursorPosition(58, top); 
                    Console.WriteLine($"{storedSubjectCode,-15}{storedTimeDate}");
                    top += 2;
                }
            }
        }
    }
}
