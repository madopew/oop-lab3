using System;
using System.Xml.Serialization;

namespace oop_lab3.Classes.ProjectClasses.SerializerAdapter
{
    public class XmlSerializerAdapter : XmlSerializer, ISerializer
    {
        public XmlSerializerAdapter(Type t)
            : base(t)
        {
        }
    }
}