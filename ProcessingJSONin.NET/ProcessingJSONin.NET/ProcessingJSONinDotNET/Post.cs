namespace ProcessingJSONin.NET
{
    public class Post
    {
        public Post(string title, string link, string description, 
            string category, string publicationDate)
        {
            this.Title = title;
            this.Link = link;
            this.Description = description;
            this.Category = category;
            this.PublicationDate = publicationDate;
        }

        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string PublicationDate { get; set; }
    }
}
