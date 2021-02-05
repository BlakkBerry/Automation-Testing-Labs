using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using SourceCode;

namespace Practice1MsTest
{
    [TestClass]
    public class UnitTest1
    {
        // TASK 11
        [TestInitialize]
        public void Init()
        {
            Logger.LogMessage("Hello World");
        }
        
        // TASK 11
        [TestCleanup]
        public void CleanUp()
        {
            Logger.LogMessage("Cruel World");
        }

        // TASK 7 - DATA DRIVEN
        [TestMethod]
        public void CallMyFunction_GreaterThan5_PositiveValue()
        {
            Logger.LogMessage("Test Started - " + Lab1Utils.GetEstTime());
            
            var res = Lab1Utils.CallMyFunction(6);

            Assert.IsTrue(res > 0);
            
            Logger.LogMessage("Test Ended - " + Lab1Utils.GetEstTime());
        }
        
        // TASK 7 - DATA DRIVEN
        [TestMethod]
        public void CallMyFunction_LowerThan5_NegativeValue()
        {
            var res = Lab1Utils.CallMyFunction(4);

            Assert.IsTrue(res < 0);
        }
        
        
        // TASK 7 - DATA DRIVEN WHICH READS FROM CSV
        [TestMethod]
        public void MyFunction_FirstAgeFromCsv_ValidFirstAge()
        {
            Int32 expectedFirstAge = 20;
            
            var firstAgeFromCsv = Lab1Utils.GetFirstAgeFromCsv();

            Assert.AreEqual(expectedFirstAge, firstAgeFromCsv);
        }
        
        // TASK 7 - DATA DRIVEN WITH RANDOM VALUE
        [TestMethod]
        public void MyFunction_RandomInt_ValidNumberOrDivideByZeroException()
        {
            var randInt = Lab1Utils.getOneRandomInt();
            
            Logger.LogMessage("Random value was: " + randInt);

            if (randInt == 5)
            {
                Assert.ThrowsException<DivideByZeroException>(() => Lab1Utils.CallMyFunction(randInt));
            }
        }
        
        // TASK 8 - IMPOSSIBLE TO IMPLEMENT WITH MsTest
        
        // TASK 9 (Retry is impossible to implement with basic MsTest functionality)
        [TestMethod, Timeout(100)]
        public void MyFunction_FailIfTimeMoreThan100ms()
        {
            var random = new Random();
            for (var i = 0; i < random.Next((int) 10e5, (int) 10e7); i++) { }
        }
        
        // TASK 10
        [TestMethod, ExpectedException(typeof(DivideByZeroException))]
        public void MyFunction_ValueOf5_DivideByZeroException()
        {
            Lab1Utils.CallMyFunction(5);
        }
    }
}