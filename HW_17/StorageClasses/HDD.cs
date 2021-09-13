using System;
using System.Runtime.Serialization;
using ILogInterface;

namespace StorageClasses
{
    [Serializable]
    [DataContract]
    public class HDD : Storage
    {
        [DataMember]
        public string RecordSpeed { get; set; }
        public HDD() { }
        public override void Print(ILog log)
        {
            log.Print(Manufacturer + '\t' + Model + '\t' + Name + '\t' + Capacity + '\t' + RecordSpeed);
        }
    }
}