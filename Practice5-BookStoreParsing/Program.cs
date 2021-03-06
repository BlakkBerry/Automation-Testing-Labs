using HtmlAgilityPack;

namespace Practice5_BookStoreParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            var htmlWeb = new HtmlWeb();
            var parser = new Parser(htmlWeb);
            
            parser.DownloadBooks();
        }
    }
}