namespace Practice5_Parsing
{
    public class Category
    {
        public string Id { get; }
        public string Name { get; }
        public string Url { get; }

        public Category(string id, string url, string name)
        {
            Id = id;
            Url = url;
            Name = name;
        }
    }
}