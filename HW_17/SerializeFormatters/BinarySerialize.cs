using System.Collections.Generic;
using StorageClasses;
using ISerializeInterface;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeFormatters
{
    public class BinarySerialize : ISerialize
    {
        public void Save(List<Storage> _list)
        {
            FileStream stream = new FileStream("BinaryS.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, _list);
            stream.Close();
        }
        public List<Storage> Load()
        {
            FileStream stream = new FileStream("BinaryS.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Storage> list = (List<Storage>)formatter.Deserialize(stream);
            stream.Close();
            return list;
        }
    }
}
