using System.Collections.Generic;
using StorageClasses;
using ISerializeInterface;
using System.IO;
using System.Runtime.Serialization.Json;

namespace SerializeFormatters
{
    public class JSONSerialize : ISerialize
    {
        public void Save(List<Storage> _list)
        {
            FileStream stream = new FileStream("JSONS.json", FileMode.Create, FileAccess.Write);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
            jsonFormatter.WriteObject(stream, _list);
            stream.Close();
        }
        public List<Storage> Load()
        {
            FileStream stream = new FileStream("JSONS.json", FileMode.Open, FileAccess.Read);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
            List<Storage> list = (List<Storage>)jsonFormatter.ReadObject(stream);
            stream.Close();
            return list;
        }
    }
}