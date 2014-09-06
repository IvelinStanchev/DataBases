using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _11_ExtractsThePricesFromAlbumsUsingXPathQuery
{
    class ExtractsThePricesFromAlbumsUsingXPathQuery
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../Catalogue.xml");
            string xPathQuery = "catalogue/album[year <= 2009]";

            XmlNodeList pricesList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode priceNode in pricesList)
            {
                string albumName = priceNode.SelectSingleNode("name").InnerText;
                string price = priceNode.SelectSingleNode("price").InnerText;
                Console.WriteLine("Album {0} has price of {1}", albumName, price);
            }
        }
    }
}
