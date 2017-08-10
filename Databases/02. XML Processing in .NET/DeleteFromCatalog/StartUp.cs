using System;
using System.Xml;

namespace DeleteFromCatalog
{
    public class StartUp
    {
        public static void Main()
        {
            var document = new XmlDocument();
            document.Load(@"../../../catalog.xml");

            XmlNode catalog = document.DocumentElement;
            XmlNodeList albums = catalog.ChildNodes;
            
            Console.WriteLine("All albums before delete: {0}", catalog.ChildNodes.Count);

            for (int i = albums.Count - 1; i >= 0; i--)
            {
                var currAlbum = albums[i];
                double price = double.Parse(currAlbum["price"].InnerText);
                if ( price > 20)
                {
                    catalog.RemoveChild(currAlbum);
                }                
            }

            Console.WriteLine("All albums after delete {0}", catalog.ChildNodes.Count);
        }
    }
}
