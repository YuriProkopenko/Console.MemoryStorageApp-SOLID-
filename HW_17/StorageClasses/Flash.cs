using System;
using System.Runtime.Serialization;
using ILogInterface;

namespace StorageClasses
{
    [Serializable]
    [DataContract]
    public class Flash : Storage
    {
        [DataMember]
        public string FlashSpeed { get; set; }
        public Flash() { }
        public override void Print(ILog log)
        {
            log.Print(Manufacturer + '\t' + Model + '\t' + Name + '\t' + Capacity + '\t' + FlashSpeed);
        }
    }
}