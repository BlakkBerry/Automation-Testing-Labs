using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;
using SourceCode;


namespace Practice1NUnit
{
    public class Tests
    {
        
        // TASK 11
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("Hello World");
        }

        // TASK 11
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Cruel World");
        }
        
        // TASK 11
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Test Started - " + Lab1Utils.GetEstTime());
        }

        // TASK 11
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Test Ended - " + Lab1Utils.GetEstTime());
        }

        // TASK 7 - Data driven
        [Test, TestCase(6)]
        public void CallMyFunction_GreaterThan5_PositiveValue(double value)
        {
            var res = Lab1Utils.CallMyFunction(value);

            Assert.That(res, Is.Positive);
        }

        // TASK 7 - Data driven
        [Test, TestCase(4)]
        public void CallMyFunction_LowerThan5_NegativeValue(double value)
        {
            var res = Lab1Utils.CallMyFunction(value);

            Assert.That(res, Is.Negative);
        }
        
        // TASK 7 - Data driven, which reads from csv
        [Test, TestCaseSource(nameof(GetAgesFromCsv))]
        public void MyFunction_FirstAgeFromCsv_ValidFirstAge(int age)
        {
            Assert.Greater(Lab1Utils.CallMyFunction(age), 0);
        }

        // TASK 7 and 8 - Data driven, 100 tests with random values
        [Test, TestCaseSource(nameof(GetRandomNumber))]
        public void MyFunction_RandomValues_ValidDoubleOrDivideByZeroException(int value)
        {
            Console.WriteLine("Random value: " + value);

            if (value == 5)
            {
                Assert.Throws<DivideByZeroException>(() => Lab1Utils.CallMyFunction(value));
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
            Assert.Throws<DivideByZeroException>(() => Lab1Utils.CallMyFunction(5));
        }
        
        private static IEnumerable<int> GetRandomNumber()
        {
            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                yield return random.Next(Int32.MinValue, Int32.MaxValue);
            }
        }
        
        public static IEnumerable GetAgesFromCsv()
        {
            using (TextFieldParser parser =
                new TextFieldParser(@"C:\Users\blakk\OneDrive\Desktop\users.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    
                    yield return Int32.Parse(fields[2]);
                }
            }
        }
    }
}