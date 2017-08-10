using System;
using System.Collections.Generic;
using System.Xml;

namespace ArtistExtraction
{
    public class StartUp
    {
        public static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"../../../catalog.xml");

            var artistsViaDOM = ExtractArtistsViaDOMParser(document);            

            foreach (var artist in artistsViaDOM)
            {
                Console.WriteLine("Artist: {0}", artist.Key);
                Console.WriteLine("Number of albums: {0}", artist.Value);
            }

            var artistsViaXPath = ExtractArtistsViaXPath(document);

            foreach (var artist in artistsViaXPath)
            {
                Console.WriteLine("Artist: {0}", artist.Key);
                Console.WriteLine("Number of albums: {0}", artist.Value);
            }
        }       

        public static Dictionary<string, int> ExtractArtistsViaDOMParser(XmlDocument document)
        {
            var artistsWithNumberOfAlbums = new Dictionary<string, int>();
            XmlNode catalog = document.DocumentElement;

            foreach (XmlNode album in catalog)
            {
                string artistName = album["artist"].InnerText;                

                if (!artistsWithNumberOfAlbums.ContainsKey(artistName))
                {
                    int albumCount = 1;
                    artistsWithNumberOfAlbums.Add(artistName, albumCount);                    
                }
                else
                {
                    artistsWithNumberOfAlbums[artistName]++;
                }                
            }

            return artistsWithNumberOfAlbums;
        }

        public static Dictionary<string, int> ExtractArtistsViaXPath(XmlDocument document)
        {
            var artistsWithNumberOfAlbums = new Dictionary<string, int>();
            XmlNodeList albums = document.SelectNodes("/catalog/album");

            foreach (XmlNode album in albums)
            {
                string artistName = album.SelectSingleNode("artist").InnerText;

                if (!artistsWithNumberOfAlbums.ContainsKey(artistName))
                {
                    int albumCount = 1;
                    artistsWithNumberOfAlbums.Add(artistName, albumCount);
                }
                else
                {
                    artistsWithNumberOfAlbums[artistName]++;
                }
            }

            return artistsWithNumberOfAlbums;
        }
    }    
}
