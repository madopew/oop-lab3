using System;
using System.IO;
using System.Xml.Serialization;

namespace oop_lab3.Classes.SerializerAdapter
{
    public class XmlSerializerAdapter : XmlSerializer, ISerializer
    {
        public XmlSerializerAdapter(Type t)
            : base(t)
        {
        }
    }
}