using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _5_ExtractsAllSongTitlesUsingXmlReader
{
    class ExtractsAllSongTitlesUsingXmlReader
    {
        static void Main()
        {
            Console.WriteLine("Song titles in the library:");
            using (XmlReader reader = XmlReader.Create("../../../Catalogue.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
