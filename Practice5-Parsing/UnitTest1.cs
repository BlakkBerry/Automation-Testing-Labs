using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using NUnit.Framework;

namespace Practice5_Parsing
{
    public class Tests
    {

        private HtmlWeb _htmlWeb;
        private const string MainUrl = "https://allitbooks.net";
        private const string DownloadUrl = "https://allitbooks.net/download-file-";
        private const string Categories = "//aside[@class='sidebar']//ul//a";
        private const string Books = "//div[@class='content']//*[@class='item-list']//*[@class='post-title']//a";

        [OneTimeSetUp]
        public void InitTests()
        {
            _htmlWeb = new HtmlWeb();
        }

        [Test]
        public void DownloadBooks()
        {
            var categories = GetCategories();
            Assert.That(categories.Length != 0, "Categories was not found!");

            categories
                .ToList()
                .AsParallel()
                .ForAll(category =>
                {
                    Regex regex = new Regex(@"\/category\/(.+)\.html");
                    var categoryName = regex.Match(category).Groups[1].Captures[0].Value;
                    
                    var books = GetBooks(category);
                    books.ToList().ForEach(book =>
                    {
                        var path = @"C:/Users/blakk/ParsedBooks/";
                        var bookUrl = DownloadUrl + book + ".html";
                        Directory.CreateDirectory(Path.Combine(path, categoryName));
                        new WebClient().DownloadFile(bookUrl, $"C:/Users/blakk/ParsedBooks/{categoryName}/{book}.pdf");
                    });
                });
            
        }

        private string[] GetCategories()
        {
            HtmlDocument document = _htmlWeb.Load(MainUrl);
            
            var categories = document.DocumentNode
                .SelectNodes(Categories)
                .Select(node => MainUrl + node.Attributes["href"].Value)
                .AsParallel()
                .ToArray();

            return categories;
        }
        private string[] GetBooks(string url)
        {
            var books = Array.Empty<string>();
            
            try
            {
                Regex regex = new Regex(@"\/(\d+)");

                books = _htmlWeb.Load(url)
                    .DocumentNode
                    .SelectNodes(Books)
                    .Select(node => regex.Match(node.Attributes["href"].Value)
                        .Groups[1]
                        .Captures[0]
                        .Value
                    )
                    .ToArray();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"No books were found at {url}");
            }
            
            return books;
        }
    }
}