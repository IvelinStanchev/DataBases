using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _4_DeletingAlbumsWithPriceBiggerThan20
{
    class DeletingAlbumsWithPriceBiggerThan20
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var currentAlbumPrice = decimal.Parse(node["price"].InnerText);

                if (currentAlbumPrice > 20)
                {
                    XmlNode parent = node.ParentNode;
                    parent.RemoveChild(node);
                }
            }

            Console.WriteLine("The new xml document:");
            Console.WriteLine(doc.OuterXml);

            doc.Save("../../../ModifiedCatalogue.xml");
        }
    }
}
