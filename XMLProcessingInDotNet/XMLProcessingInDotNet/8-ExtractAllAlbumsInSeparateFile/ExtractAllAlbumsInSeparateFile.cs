using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _8_ExtractAllAlbumsInSeparateFile
{
    class ExtractAllAlbumsInSeparateFile
    {
        static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../../Catalogue.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("../../album.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    string albumName = string.Empty;
                    string authorName = string.Empty;

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "name"))
                        {
                            albumName = reader.ReadElementString();
                        }
                        else if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "artist"))
                        {
                            authorName = reader.ReadElementString();
                            WriteAlbum(writer, albumName, authorName);
                        }
                    }

                    writer.WriteEndDocument();
                }
            }

            Console.WriteLine("Look at the main directory of the project!");
        }

        private static void WriteAlbum(XmlWriter writer, string albumName, string authorName)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", albumName);
            writer.WriteElementString("artist", authorName);
            writer.WriteEndElement();
        }
    }
}
