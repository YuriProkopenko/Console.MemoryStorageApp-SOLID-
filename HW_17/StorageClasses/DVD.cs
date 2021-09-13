using System;
using System.Runtime.Serialization;
using ILogInterface;

namespace StorageClasses
{
    [Serializable]
    [DataContract]
    public class DVD : Storage
    {
        [DataMember]
        public string SpindleSpeed { get; set; }
        public DVD() { }
        public override void Print(ILog log)
        {
            log.Print(Manufacturer + '\t' + Model + '\t' + Name + '\t' + Capacity + '\t' + SpindleSpeed);
        }
    }
}