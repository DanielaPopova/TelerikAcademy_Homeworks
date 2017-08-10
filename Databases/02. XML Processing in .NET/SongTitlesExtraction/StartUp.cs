using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace SongTitlesExtraction
{
    public class StartUp
    {
        public static void Main()
        {
            string path = @"../../../catalog.xml";

            var songTitlesXMLReader = ExtractSongsTitlesViaXMLReader(path);
            foreach (var title in songTitlesXMLReader)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine(new string('*', 50));

            var songTitlesLINQ = ExtractSongTitlesViaLINQ(path);
            foreach (var title in songTitlesLINQ)
            {
                Console.WriteLine(title);
            }
        }

        public static IEnumerable<string> ExtractSongsTitlesViaXMLReader(string catalogPath)
        {
            var songTitles = new List<string>();

            using (XmlReader reader = XmlReader.Create(catalogPath))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title") // && reader.NodeType == XmlNodeType.Element
                    {
                        songTitles.Add(reader.ReadInnerXml());                        
                    }
                }
            }

            return songTitles;
        }

        public static IEnumerable<string> ExtractSongTitlesViaLINQ(string catalogPath)
        {
            XDocument xmlDoc = XDocument.Load(catalogPath);

            var songsTitles =
                from title in xmlDoc.Descendants("title")
                select title.Value;

            return songsTitles;
        }
    }
}
