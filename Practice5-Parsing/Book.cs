namespace Practice5_Parsing
{
    public class Book
    {
        public string Id { get; }
        public Category Category { get; }
        public string Name { get; }
        public string Url { get; }
        public string DownloadUrl { get; }

        public Book(string id, Category category,  string name, string url, string downloadUrl)
        {
            Id = id;
            Category = category;
            Url = url;
            Name = name;
            DownloadUrl = downloadUrl;
        }
    }
}