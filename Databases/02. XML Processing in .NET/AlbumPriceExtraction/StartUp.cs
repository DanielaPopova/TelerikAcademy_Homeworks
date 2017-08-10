using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace AlbumPriceExtraction
{
    public class StartUp
    {
        public static void Main()
        {
            string path = @"../../../catalog.xml";
            int currentYear = DateTime.Now.Year;

            Console.WriteLine("Via XPath");
            ExtractAlbumProcesVieXPath(path, currentYear);

            Console.WriteLine(new string('*', 30));

            Console.WriteLine("Via LINQ");
            ExtractAlbumPricesViaLINQ(path, currentYear);
        }

        public static void ExtractAlbumProcesVieXPath(string path, int currentYear)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList albums = xml.SelectNodes("/catalog/album");

            foreach (XmlElement album in albums)
            {
                int releasedYear = int.Parse(album.SelectSingleNode("releasedYear").InnerText);
                if (releasedYear <= currentYear - 5)
                {
                    decimal price = decimal.Parse(album.SelectSingleNode("price").InnerText);

                    Console.WriteLine("Album released year: {0}", releasedYear);
                    Console.WriteLine("Price: {0}", price);
                }
            }
        }

        public static void ExtractAlbumPricesViaLINQ(string path, int currentYear)
        {
            XDocument xmlDoc = XDocument.Load(path);
            var prices =
                        from album in xmlDoc.Descendants("album")
                        where (decimal)album.Element("releasedYear") <= (currentYear - 5)
                        select new
                        {
                            ReleasedYear = album.Element("releasedYear").Value,
                            Price = album.Element("price").Value
                        };
            foreach (var info in prices)
            {
                Console.WriteLine("Album released year: {0}", info.ReleasedYear);
                Console.WriteLine("Price: {0}", info.Price);
            }
        }
    }
}
