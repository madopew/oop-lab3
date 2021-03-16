using oop_lab3.Classes.ItemClasses;
using oop_lab3.Classes.SerializerAdapter;

namespace oop_lab3.Classes.Factory
{
    public static class ItemSerializerFactory
    {
        public static ISerializer CreateSerializer(bool isXml)
        {
            if (isXml)
            {
                return new XmlSerializerAdapter(typeof(Item));
            }

            return new BinaryFormatterAdapter();
        }
    }
}