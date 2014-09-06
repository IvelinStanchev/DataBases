using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _3_ExtractArtistsUsingXPath
{
    class ExtractArtistsUsingXPath
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../Catalogue.xml");
            XmlNode rootNode = xmlDoc.DocumentElement;

            string xPathQuery = "catalogue/album";
            XmlNodeList artistsList = xmlDoc.SelectNodes(xPathQuery);

            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();

            foreach (XmlNode artist in artistsList)
            {
                string currentArtistName = artist.SelectSingleNode("artist").InnerText;

                if (!artistsAndAlbums.ContainsKey(currentArtistName))
                {
                    artistsAndAlbums.Add(currentArtistName, 1);
                }
                else
                {
                    artistsAndAlbums[currentArtistName]++;
                }
            }

            foreach (var artistAndAlbums in artistsAndAlbums)
            {
                Console.WriteLine("{0} has {1} album/s", artistAndAlbums.Key, artistAndAlbums.Value);
            }
        }
    }
}
