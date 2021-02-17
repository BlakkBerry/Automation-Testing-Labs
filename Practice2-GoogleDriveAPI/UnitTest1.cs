using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using GoogleDriveSerializerV2;
using GoogleDriveSerializerV3;
using RestSharp;

namespace Practice2_GoogleDriveAPI
{
    [TestFixture]
    public class Tests
    {
        private Configuration _config;
        private string _accessToken;
#if API_V3
        private File[] _files;
#elif API_V2
        private Item[] _files;
#endif


        [SetUp]
        public void Setup()
        {
        }

        [OneTimeSetUp]
        public void TestsInit()
        {
            _config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = _config.AppSettings.Settings["client_id"].Value,
                    ClientSecret = _config.AppSettings.Settings["client_secret"].Value
                },
                new[] {_config.AppSettings.Settings["scope"].Value},
                "user",
                CancellationToken.None,
                new FileDataStore(_config.AppSettings.Settings["tokenPath"].Value, true)).Result;
            
            _accessToken = credential.Token.AccessToken;

#if API_V3
            var client =
                new RestClient(
                    $"{_config.AppSettings.Settings["url-v3"].Value}key={_config.AppSettings.Settings["api_key"].Value}&fields=*");

#elif API_V2
            var client =
                new RestClient(
                    $"{_config.AppSettings.Settings["url-v2"].Value}key={_config.AppSettings.Settings["api_key"].Value}");

#endif

            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_accessToken}");
            IRestResponse response = client.Execute(request);

#if API_V3
            _files = GoogleDriveSerializerV3.Deserialize.FromJson(response.Content).Files;
#elif API_V2
            _files = GoogleDriveSerializerV2.Deserialize.FromJson(response.Content).Items;
#endif
        }

        [Test]
        [TestCase("file1.txt")]
        [TestCase("New Folder/file2.pdf")]
        [TestCase("failed.pdf")]
        public void Test1(string path)
        {
            Assert.IsTrue(IsExistingPath(path));
        }


        private bool IsExistingPath(string filePath)
        {
            string[] pathsToFind = filePath.Split('/');

            if (pathsToFind.Length == 1)
            {
#if API_V3
                return _files.Any(file => file.Name == pathsToFind[0]);
#elif API_V2
                return _files.Any(file => file.Title == pathsToFind[0]);
#endif
            }
            else
            {
#if API_V3
                return _files.Where(file => file.Parents != null)
                    .Join(_files,
                        file1 => file1.Parents[0],
                        file2 => file2.Id,
                        (file1, file2) => file2.Name + "/" + file1.Name)
                    .ToArray()
                    .Contains(filePath);
#elif API_V2
                return _files.Where(file => file.Parents.Length != 0)
                    .Join(_files,
                        file1 => file1.Parents[0].Id,
                        file2 => file2.Id,
                        (file1, file2) => file2.Title + "/" + file1.Title)
                    .ToArray()
                    .Contains(filePath);
#endif
            }
        }
    }
}