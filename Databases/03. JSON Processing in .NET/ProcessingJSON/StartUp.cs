using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProcessingJSON.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace ProcessingJSON
{
    public class StartUp
    {
        private static readonly string Url = @"https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

        private static readonly string FilePath = @"../../rssFeed.xml";

        public static void Main()
        {
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.OutputEncoding = Encoding.UTF8;

            DownloadRSS(Url, FilePath);

            var xmlDoc = XDocument.Load(FilePath);
            string jsonDoc = JsonConvert.SerializeXNode(xmlDoc, Formatting.Indented);
            //Console.WriteLine(jsonDoc);

            var videos = SelectVideosFromJson(jsonDoc);
            foreach (var video in videos)
            {
                Console.WriteLine("Video title: {0}", video.Title);
            }

            var html = CreateHtml(videos);
            string path = string.Format(@"../../TAvideos.html");
            SaveContentToHtml(path, html);
        }

        public static void DownloadRSS(string url, string file)
        {
            var downloader = new WebClient();
            //downloader.Encoding = Encoding.UTF8;
            downloader.DownloadFile(url, file);
        }

        public static IEnumerable<Video> SelectVideosFromJson(string json)
        {
            var jsonObj = JObject.Parse(json);
            //var videoTitles = from entry in jsonObj["feed"]["entry"]
            //                  select (string)entry["title"];

            var videos = jsonObj["feed"]["entry"]
                    .Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString()));                    

            return videos;
        }

        public static string CreateHtml(IEnumerable<Video> videos)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html><html><head><title>TelericAcademy Videos</title></head><body>");

            foreach (var video in videos)
            {
                html.Append(string.Format("<iframe width=\"420\" height=\"315\" src=\"http://www.youtube.com/embed/{0}\"></iframe>", video.Id));
            }

            html.Append("</body></html>");

            return html.ToString();
        }

        public static void SaveContentToHtml(string path, string content)
        {
            File.WriteAllText(path, content, Encoding.UTF8);
        }
    }
}
