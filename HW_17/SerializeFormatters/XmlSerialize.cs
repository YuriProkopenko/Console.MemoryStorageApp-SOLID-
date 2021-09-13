using System.Collections.Generic;
using StorageClasses;
using ISerializeInterface;
using System.IO;
using System.Xml.Serialization;

namespace SerializeFormatters
{
    public class XmlSerialize : ISerialize
    {
        public void Save(List<Storage> _list)
        {
            FileStream stream = new FileStream("XmlS.Xml", FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Storage>));
            serializer.Serialize(stream, _list);
            stream.Close();
        }
        public List<Storage> Load()
        {
            FileStream stream = new FileStream("XmlS.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Storage>));
            List<Storage> list = (List<Storage>)serializer.Deserialize(stream);
            stream.Close();
            return list;
        }
    }
}