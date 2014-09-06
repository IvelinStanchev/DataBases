using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _12_ExtractsThePricesFromAlbumsUsingLINQQuery
{
    class ExtractsThePricesFromAlbumsUsingLINQQuery
    {
        static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../../Catalogue.xml");
            var albums =
                from album in xmlDoc.Descendants("album")
                where int.Parse(album.Element("year").Value) <= 2009
                select new
                {
                    Title = album.Element("name").Value,
                    Price = album.Element("price").Value
                };

            Console.WriteLine("Found {0} albums:", albums.Count());
            foreach (var album in albums)
            {
                Console.WriteLine("Album {0} has price of {1}", album.Title, album.Price);
            }
        }
    }
}
