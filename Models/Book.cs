using System.Xml.Serialization;

public class Book
{
    [XmlElement("Id")]
    public int Id { get; set; }

    [XmlElement("Title")]
    public string Title { get; set; }

    [XmlElement("Author")]
    public string Author { get; set; }
}
