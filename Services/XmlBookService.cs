using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class XmlBookService
{
    private readonly string _xmlFilePath;

    public XmlBookService(string xmlFilePath)
    {
        _xmlFilePath = xmlFilePath;
    }

    public List<Book> GetAllBooks()
    {
        if (!File.Exists(_xmlFilePath)) return new List<Book>();

        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
        using (FileStream fs = new FileStream(_xmlFilePath, FileMode.Open))
        {
            return (List<Book>)serializer.Deserialize(fs);
        }
    }

    public void SaveBooks(List<Book> books)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
        using (FileStream fs = new FileStream(_xmlFilePath, FileMode.Create))
        {
            serializer.Serialize(fs, books);
        }
    }
}
