using System.Collections.Generic;
using StorageClasses;

namespace ISerializeInterface
{
    public interface ISerialize
    {
        public void Save(List<Storage> _list);
        public List<Storage> Load();
    }
}