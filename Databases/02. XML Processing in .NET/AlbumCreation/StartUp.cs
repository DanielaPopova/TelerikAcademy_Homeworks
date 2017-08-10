using System.Xml;

namespace AlbumCreation
{
    public class StartUp
    {
        public static void Main()
        {
            var writer = XmlWriter.Create(@"../../album.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("albums");

            using (XmlReader reader = XmlReader.Create(@"../../../catalog.xml"))
            {
                while (reader.Read())
                {                    
                    if (reader.Name == "name")
                    {
                        writer.WriteStartElement("album");

                        writer.WriteElementString(reader.Name, reader.ReadInnerXml());

                        if (reader.ReadToFollowing("artist"))
                        {
                            writer.WriteElementString(reader.Name, reader.ReadInnerXml());
                        }                       

                        writer.WriteEndElement();                                         
                    }                                    
                }
            }
            
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();            
        }
    }
}
