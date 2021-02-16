using System;
using System.Configuration;
using System.Reflection;
using NUnit.Framework;

namespace Practice2_GoogleDriveAPI
{
    [TestFixture]
    public class Tests
    {

        private string _requestUrl = string.Empty;
        
        [SetUp]
        public void Setup()
        {
        }

        [OneTimeSetUp]
        public void TestsInit()
        {
            
#if API_V2
            _requestUrl = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                .AppSettings.Settings["GoogleDriveAPI-V2"].Value;
#elif API_V3
            _requestUrl = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location)
                .AppSettings.Settings["GoogleDriveAPI-V3"].Value;
#endif
            Console.WriteLine(_requestUrl);
            
        }

        [Test, TestCase("file1.txt", "New Folder/file2.pdf", "failed.pdf")]
        public void Test1(params string[] paths)
        {
            
            Assert.Pass();
        }
    }
}