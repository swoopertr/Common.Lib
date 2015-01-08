using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Common.Lib.Utils.Xml
{
  public static class XmlHelper
  {

    public static string ToXmlSerialize(this object v, Encoding encoding ,bool removeNamespace)
    {
      return SerializeToXMLString(v, encoding, removeNamespace);
    }

    public static string SerializeToXMLString<T>(T XMLObj, Encoding encoding, bool removeNamespace)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
      MemoryStream memStrm = new MemoryStream();
      XmlTextWriter xmlSink = new XmlTextWriter(memStrm, encoding);
      xmlSink.Formatting = Formatting.Indented;

      if (removeNamespace)
      {
        XmlSerializerNamespaces xs = new XmlSerializerNamespaces();
        xs.Add("", "");

        xmlSerializer.Serialize(xmlSink, XMLObj, xs);
      }
      else
        xmlSerializer.Serialize(xmlSink, XMLObj);

      return encoding.GetString(memStrm.ToArray());
    }

    public static void SerializeToXMLFile<T>(T XMLObj, string Filename, Encoding encoding, bool removeNamespace)
    {
      File.WriteAllText(Filename, SerializeToXMLString<T>(XMLObj, encoding, removeNamespace));
    }

    public static T DeserializeFromXMLString<T>(string XML) where T : new()
    {
      T XMLObj = new T();
      XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
      StringReader sr = new StringReader(XML);
      XMLObj = (T)xmlSerializer.Deserialize(sr);
      return XMLObj;
    }

    public static T DeserializeFromXMLFile<T>(string Filename) where T : new()
    {
      if (!File.Exists(Filename))
        throw new FileNotFoundException();

      return DeserializeFromXMLString<T>(File.ReadAllText(Filename));
    }


  }
}
