namespace ProcessingJSONin.NET
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    class ProcessingJSONinDotNET
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Task 1 and 2
            WebClient client = new WebClient();
            client.DownloadFile(new Uri(@"http://forums.academy.telerik.com/feed/qa.rss"), @"../../TelerikAcademy.xml");

            //Task 3
            var telerikAcademyXml = XDocument.Load("../../TelerikAcademy.xml");

            string parsedXmlFileToJson = JsonConvert.SerializeXNode(telerikAcademyXml, Newtonsoft.Json.Formatting.Indented);

            //Task 4

            var jsonObj = JObject.Parse(parsedXmlFileToJson);

            int index = 0;
            var allTitles = jsonObj["rss"]["channel"]["item"]
                .Select(i => i["title"]);

            foreach (var title in allTitles)
            {
                index++;
                Console.WriteLine("{0} - {1}", index, title);
                Console.WriteLine(new string('-', 50));
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(new string('-', 50));

            //Task 5
            List<Post> posts = new List<Post>();

            var allItems = jsonObj["rss"]["channel"]["item"];

            foreach (var item in allItems)
            {
                posts.Add(new Post(item["title"].ToString(), item["link"].ToString(),
                    item["description"].ToString(), item["category"].ToString(), item["pubDate"].ToString()));
            }

            //Task 6
            StringBuilder generatedHtml = new StringBuilder();

            generatedHtml.AppendLine("<html>");
            generatedHtml.AppendLine("<head>");
            generatedHtml.AppendLine("<style>");
            generatedHtml.AppendLine("div#title{ font-weight: bold } div#description { padding-left: 20px; color: orange }");
            generatedHtml.AppendLine("</style>");
            generatedHtml.AppendLine("</head>");
            generatedHtml.AppendLine("<body>");
            generatedHtml.AppendLine("<ul>");

            for (int i = 0; i < posts.Count; i++)
            {
                generatedHtml.AppendLine("<li>");
                generatedHtml.AppendLine(string.Format("<div id=\"title\">{0}</div>", posts[i].Title));
                generatedHtml.AppendLine(string.Format("<div id=\"description\">{0}</div>", posts[i].Description));
                generatedHtml.AppendLine(string.Format("<div id=\"category\">{0}</div>", posts[i].Category));
                generatedHtml.AppendLine(string.Format("<div id=\"publicationDate\">{0}</div>", posts[i].PublicationDate));
                generatedHtml.AppendLine(string.Format("<div><a href=\"{0}\"> LINK</a></div>", posts[i].Link));
                generatedHtml.AppendLine("</li>");
            }

            generatedHtml.AppendLine("</ul>");
            generatedHtml.AppendLine("</body>");
            generatedHtml.AppendLine("<html>");

            Console.WriteLine("Open the html file (which is at the main project directory) through some browser");

            string path = "../../";
            File.WriteAllText(path + "htmlWithPosts.html", generatedHtml.ToString(), Encoding.UTF8);
        }
    }
}
