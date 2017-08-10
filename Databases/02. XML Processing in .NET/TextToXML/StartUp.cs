using System.IO;
using System.Xml.Linq;

namespace TextToXML
{
    public class StartUp
    {
        public static void Main()
        {
            string path = @"../../person.txt";
            string[] lines = File.ReadAllLines(path);

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("person",
                    new XElement("name", lines[0]),
                    new XElement("address", lines[1]),
                    new XElement("phone", lines[2])));        

            doc.Save(@"../../person.xml");

            CreateXMLDocument(path);
        }

        public static void CreateXMLDocument(string path)
        {
            string[] tags = { "name", "address", "phone" };

            XElement xml = new XElement("person");

            using (var reader = new StreamReader(path))
            {
                foreach (var tag in tags)
                {
                    string currLine = reader.ReadLine();
                    if (currLine == null)
                    {
                        break;
                    }

                    xml.Add(new XElement(tag, currLine));
                }
            }

            xml.Save(@"../../person2.xml");
        }
    }
}
