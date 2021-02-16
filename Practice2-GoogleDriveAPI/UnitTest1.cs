using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;

namespace Practice2_GoogleDriveAPI
{
    [TestFixture]
    public class Tests
    {

        private Configuration _config;
        private string _accessToken;
        
        [SetUp]
        public void Setup()
        {
        }

        [OneTimeSetUp]
        public void TestsInit()
        {
            
#if API_V2
            _config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
#elif API_V3
            _config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(_config.AppSettings.Settings["lastName"].Value);
#endif
            
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = _config.AppSettings.Settings["client_id"].Value,
                    ClientSecret = _config.AppSettings.Settings["client_secret"].Value
                },
                new[] { _config.AppSettings.Settings["scope"].Value },
                "user",
                CancellationToken.None,
                null).Result;
            //new FileDataStore("E:/Trash/token", true)
            _accessToken = credential.Token.AccessToken;
        }

        [Test]
        [TestCase("file1.txt")]
        [TestCase("New Folder/file2.pdf")]
        [TestCase("failed.pdf")]
        public void Test1(params string[] paths)
        {
            
            Assert.Pass();
        }
    }
}