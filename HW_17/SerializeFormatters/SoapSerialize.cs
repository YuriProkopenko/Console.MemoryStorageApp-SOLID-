using System.Collections.Generic;
using StorageClasses;
using ISerializeInterface;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace SerializeFormatters
{
    public class SoapSerialize : ISerialize
    {
        public void Save(List<Storage> _list)
        {
            FileStream stream = new FileStream("SoapS.soap", FileMode.Create, FileAccess.Write);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(stream, _list);
            stream.Close();
        }
        public List<Storage> Load()
        {
            FileStream stream = new FileStream("SoapS.soap", FileMode.Open, FileAccess.Read);
            SoapFormatter formatter = new SoapFormatter();
            List<Storage> list = (List<Storage>)formatter.Deserialize(stream);
            stream.Close();
            return list;
        }
    }
}