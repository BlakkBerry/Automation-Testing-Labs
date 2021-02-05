using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;


namespace Practice1NUnit
{
    public class Tests
    {
        // TASK 11
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Hello World");
        }

        // TASK 11
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Cruel World");
        }

        // TASK 6
        private static double CallMyFunction(double x)
        {
            var denominator = x * x - 5 * x;

            return 1 / denominator.CompareTo(0) == 0 ? 0 : denominator;
        }

        // TASK 7 - DATA DRIVEN
        [Test]
        public void CallMyFunction_GreaterThan5_PositiveValue()
        {
            Console.WriteLine("Test Started - " + GetEstTime());
            
            var res = CallMyFunction(6);

            Assert.That(res, Is.Positive);
            
            Console.WriteLine("Test Ended - " + GetEstTime());
        }

        // TASK 7 - DATA DRIVEN
        [Test]
        public void CallMyFunction_LowerThan5_NegativeValue()
        {
            var res = CallMyFunction(4);

            Assert.That(res, Is.Negative);
        }
        
        // TASK 7 - DATA DRIVEN WHICH READS FROM CSV
        [Test]
        public void MyFunction_FirstAgeFromCsv_ValidNumberOrDivideByZeroException()
        {
            Int32 expectedFirstAge = 20;
            
            var firstAgeFromCsv = GetFirstAgeFromCsv();

            Assert.AreEqual(expectedFirstAge, firstAgeFromCsv);
        }

        // TASK 7 and 8 - DATA DRIVEN, RANDOM 100 TIMES
        [Test, TestCaseSource(nameof(GetRandomNumber))]
        public void MyFunction_RandomValue_ValidDoubleOrDivideByZeroException(int value)
        {
            Console.WriteLine("Random value: " + value);

            if (value == 5)
            {
                Assert.Throws<DivideByZeroException>(() => CallMyFunction(value));
            }
            else
            {
                Assert.Pass();
            }
        }

        // TASK 9
        [Test, Retry(2), MaxTime(100)]
        public void MyFunction_FailIfTimeMoreThan100ms()
        {
            var random = new Random();
            for (var i = 0; i < random.Next((int) 10e5, (int) 10e7); i++) { }
            
            Assert.Pass();
        }
        
        // TASK 10
        [Test]
        public void MyFunction_ValueOf5_DivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => CallMyFunction(5));
        }
        
        private static IEnumerable<int> GetRandomNumber()
        {
            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                yield return random.Next(Int32.MinValue, Int32.MaxValue);
            }
        }

        private static DateTime GetEstTime()
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
        }

        public int GetFirstAgeFromCsv()
        {
            List<int> ages = new List<int>();
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
    }
}