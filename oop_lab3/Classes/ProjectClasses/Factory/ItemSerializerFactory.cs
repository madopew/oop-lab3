using oop_lab3.Classes.GameClasses.ItemClasses;
using oop_lab3.Classes.ProjectClasses.SerializerAdapter;

namespace oop_lab3.Classes.ProjectClasses.Factory
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