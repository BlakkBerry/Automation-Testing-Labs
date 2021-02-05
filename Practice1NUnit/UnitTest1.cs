using System;
using System.Collections.Generic;
using NUnit.Framework;
using SourceCode;


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

        // TASK 7 - DATA DRIVEN
        [Test]
        public void CallMyFunction_GreaterThan5_PositiveValue()
        {
            Console.WriteLine("Test Started - " + Lab1Utils.GetEstTime());
            
            var res = Lab1Utils.CallMyFunction(6);

            Assert.That(res, Is.Positive);
            
            Console.WriteLine("Test Ended - " + Lab1Utils.GetEstTime());
        }

        // TASK 7 - DATA DRIVEN
        [Test]
        public void CallMyFunction_LowerThan5_NegativeValue()
        {
            var res = Lab1Utils.CallMyFunction(4);

            Assert.That(res, Is.Negative);
        }
        
        // TASK 7 - DATA DRIVEN WHICH READS FROM CSV
        [Test]
        public void MyFunction_FirstAgeFromCsv_ValidFirstAge()
        {
            Int32 expectedFirstAge = 20;
            
            var firstAgeFromCsv = Lab1Utils.GetFirstAgeFromCsv();

            Assert.AreEqual(expectedFirstAge, firstAgeFromCsv);
        }

        // TASK 7 and 8 - DATA DRIVEN, RANDOM 100 TIMES
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
    }
}