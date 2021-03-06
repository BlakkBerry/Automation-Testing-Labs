using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Practice5_Parsing;

namespace Practice5_BookStoreParsing
{
    public class Parser
    {
        private readonly HtmlWeb _htmlWeb;

        public Parser(HtmlWeb htmlWeb)
        {
            _htmlWeb = htmlWeb;
        }
        
        public void DownloadBooks()
        {
            var categories = GetCategories();

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
                        
                        if (!File.Exists($"C:/Users/blakk/ParsedBooks/{category.Name}/{book.Name}.pdf"))
                        {
                            Colorize($"The download of \"{book.Name}\" from category \"{category.Name}\" has started...", ConsoleColor.DarkCyan);
                            
                            new WebClient().DownloadFile(
                                book.DownloadUrl,
                                Path.Combine(path, category.Name, $"{book.Name}.pdf")
                            );
                        }
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
            }

            return books;
        }

        private void Colorize(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}