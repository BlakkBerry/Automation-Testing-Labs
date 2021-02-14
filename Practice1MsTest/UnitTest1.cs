using System;
using System.Collections.Generic;
using System.Threading;
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

        // TASK 7 - Data driven, which uses IEnumerable is impossible to implement in msTest without packages

        // TASK 8 - Impossible to implement with MsTest

        // TASK 9 (Retry is impossible to implement with basic MsTest functionality)
        [TestMethod, Timeout(100)]
        public void MyFunction_FailIfTimeMoreThan100ms()
        {
            Thread.Sleep(90);
        }

        // TASK 10
        [DataTestMethod, DataRow(5), ExpectedException(typeof(DivideByZeroException))]
        public void MyFunction_ValueOf5_DivideByZeroException(int criticalValue)
        {
            Lab1Utils.CallMyFunction(criticalValue);
        }
    }
}