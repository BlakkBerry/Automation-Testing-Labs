using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

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
        
        // TASK 6
        private static double CallMyFunction(double x)
        {
            var denominator = x * x - 5 * x;

            return 1 / denominator.CompareTo(0) == 0 ? 0 : denominator;
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}