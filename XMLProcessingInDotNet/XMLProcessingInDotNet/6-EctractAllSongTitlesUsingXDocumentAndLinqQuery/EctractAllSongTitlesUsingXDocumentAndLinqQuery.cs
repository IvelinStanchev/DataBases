using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _6_EctractAllSongTitlesUsingXDocumentAndLinqQuery
{
    class EctractAllSongTitlesUsingXDocumentAndLinqQuery
    {
        static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../../Catalogue.xml");
            var songs =
                from song in xmlDoc.Descendants("song")
                select new
                {
                    Title = song.Element("title").Value
                };
            Console.WriteLine("Found {0} songs:", songs.Count());

            int index = 0;
            foreach (var song in songs)
            {
                index++;
                Console.WriteLine("{0} - {1}", index, song.Title);
            }
        }
    }
}
