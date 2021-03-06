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
                    var books = GetBooks(category);
                    books.ToList().ForEach(book =>
                    {
                        const string path = @"C:/Users/blakk/ParsedBooks/";
                        Directory.CreateDirectory(Path.Combine(path, category.Name));
                        new WebClient().DownloadFile(
                            book.DownloadUrl,
                            Path.Combine(path, category.Name, $"{book.Name}.pdf")
                        );
                    });
                });
        }

        private Category[] GetCategories()
        {
            const string mainUrl = "https://allitbooks.net";
            const string categoriesXPath = "//aside[@class='sidebar']//ul//a";
            
            HtmlDocument document = _htmlWeb.Load(mainUrl);

            Category[] categories = document.DocumentNode
                .SelectNodes(categoriesXPath)
                .Select(node =>
                {
                    var categoryUrl = node.Attributes["href"].Value;

                    Regex idRegex = new Regex(@"\/category\/(.+)\.html");
                    var categoryId = idRegex.Match(categoryUrl).Groups[1].Captures[0].Value;

                    var categoryName = node.InnerText.Trim('»', ' ');

                    return new Category(categoryId, mainUrl + categoryUrl, categoryName);
                })
                .AsParallel()
                .ToArray();

            return categories;
        }

        private Book[] GetBooks(Category category)
        {
            const string booksXPath = "//div[@class='content']//*[@class='item-list']//*[@class='post-title']//a";
            var books = Array.Empty<Book>();

            try
            {
                Regex regex = new Regex(@"\/(\d+)");

                books = _htmlWeb.Load(category.Url)
                    .DocumentNode
                    .SelectNodes(booksXPath)
                    .Select(node =>
                    {
                        var bookUrl = node.Attributes["href"].Value;
                        var bookId = regex.Match(bookUrl)
                            .Groups[1]
                            .Captures[0]
                            .Value;
                        var downloadUrl = $"https://allitbooks.net/download-file-{bookId}.html";

                        return new Book(bookId, category, node.InnerText, bookUrl, downloadUrl);
                    })
                    .ToArray();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"No books were found at category: {category.Name} with url: {category.Url}");
                Console.WriteLine("Error message" + e.Message);
            }

            return books;
        }
    }
}