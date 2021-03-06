using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace oop_lab3.Classes.ProjectClasses.SerializerAdapter
{
    public class BinaryFormatterAdapter : ISerializer
    {
        private readonly BinaryFormatter binaryFormatter;

        public BinaryFormatterAdapter()
        {
            binaryFormatter = new BinaryFormatter();
        }

        public void Serialize(Stream stream, object data)
        {
            binaryFormatter.Serialize(stream, data);
        }

        public object Deserialize(Stream stream)
        {
            return binaryFormatter.Deserialize(stream);
        }
    }
}