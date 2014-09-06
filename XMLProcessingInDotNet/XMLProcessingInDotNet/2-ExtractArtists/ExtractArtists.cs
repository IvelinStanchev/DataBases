﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _2_ExtractArtists
{
    class ExtractArtists
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;
            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var currentArtistName = node["artist"].InnerText;

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
