using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using ILogInterface;

namespace StorageClasses
{
    [Serializable]
    [KnownType(typeof(Flash))]
    [KnownType(typeof(DVD))]
    [KnownType(typeof(HDD))]
    [XmlInclude(typeof(Flash))]
    [XmlInclude(typeof(DVD))]
    [XmlInclude(typeof(HDD))]
    [DataContract]
    public abstract class Storage
    {
        [DataMember]
        public string Manufacturer { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Capacity { get; set; }
        public virtual void Print(ILog log) { }
    }
}