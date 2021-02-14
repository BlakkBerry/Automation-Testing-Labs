using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using SourceCode;

namespace Practice1MsTest
{
    [TestClass]
    public class UnitTest1
    {
        // TASK 11
        [ClassInitialize]
        public static void OneTimeSetup(TestContext context)
        {
            Logger.LogMessage("Hello World");
        }

        // TASK 11
        [ClassCleanup]
        public static void OneTimeTearDown()
        {
            Logger.LogMessage("Cruel World");
        }

        // TASK 11
        [TestInitialize]
        public void Init()
        {
            Logger.LogMessage("Test Started - " + Lab1Utils.GetEstTime());
        }

        // TASK 11
        [TestCleanup]
        public void CleanUp()
        {
            Logger.LogMessage("Test Ended - " + Lab1Utils.GetEstTime());
        }

        // TASK 7 - Data driven
        [DataTestMethod, DataRow(6)]
        public void CallMyFunction_GreaterThan5_PositiveValue(double value)
        {
            var res = Lab1Utils.CallMyFunction(value);

            Assert.IsTrue(res > 0);
        }

        // TASK 7 - Data driven
        [DataTestMethod, DataRow(4)]
        public void CallMyFunction_LowerThan5_NegativeValue(double value)
        {
            var res = Lab1Utils.CallMyFunction(4);

            Assert.IsTrue(res < 0);
        }


        // TASK 7 - Data driven, which reads from csv
        [TestMethod]
        public void MyFunction_FirstAgeFromCsv_ValidFirstAge()
        {
            Int32 expectedFirstAge = 20;

            var firstAgeFromCsv = Lab1Utils.GetFirstAgeFromCsv();

            Assert.AreEqual(expectedFirstAge, firstAgeFromCsv);
        }

        private IEnumerable<int> Stuff
        {
            get
            {
                //This could do anything, get a dynamic list from anywhere....
                return new List<int> {1, 2, 3};
            }
        }

        [TestMethod]
        [DataSource(nameof(Stuff))]
        public void TestMethod1(int value)
        {
            Assert.IsTrue(value > 0);
        }

        // TASK 7 - Data driven, 100 tests with random values
        [DataTestMethod, DataRow(5)]
        public void MyFunction_RandomInt_ValidNumberOrDivideByZeroException(int criticalValue)
        {
            var randInt = Lab1Utils.getOneRandomInt();

            Logger.LogMessage("Random value was: " + randInt);

            if (randInt == criticalValue)
            {
                Assert.ThrowsException<DivideByZeroException>(() => Lab1Utils.CallMyFunction(randInt));
            }
        }

        // TASK 8 - Impossible to implement with MsTest

        // TASK 9 (Retry is impossible to implement with basic MsTest functionality)
        [TestMethod, Timeout(100)]
        public void MyFunction_FailIfTimeMoreThan100ms()
        {
            var random = new Random();
            for (var i = 0; i < random.Next((int) 10e5, (int) 10e7); i++)
            {
            }
        }

        // TASK 10
        [DataTestMethod, DataRow(5), ExpectedException(typeof(DivideByZeroException))]
        public void MyFunction_ValueOf5_DivideByZeroException(int criticalValue)
        {
            Lab1Utils.CallMyFunction(criticalValue);
        }
    }
}