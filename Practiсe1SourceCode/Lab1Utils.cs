using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace SourceCode
{
    public class Lab1Utils
    {
        
        // TASK 6
        public static double CallMyFunction(double x)
        {
            var denominator = x * x - 5 * x;

            return 1 / denominator.CompareTo(0) == 0 ? 0 : denominator;
        }
        
        public static DateTime GetEstTime()
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
        }
        
        public static int GetFirstAgeFromCsv()
        {
            using (TextFieldParser parser =
                new TextFieldParser(@"C:\Users\blakk\OneDrive\Desktop\users.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    foreach (var field in fields)
                    {
                        try
                        {
                            return Int32.Parse(field);
                        }
                        catch (Exception e) { }
                    }
                }
            }

            return 0;
        }

        public static int getOneRandomInt()
        {
            var random = new Random();

            return random.Next(Int32.MinValue, Int32.MaxValue);
        }
    }
}