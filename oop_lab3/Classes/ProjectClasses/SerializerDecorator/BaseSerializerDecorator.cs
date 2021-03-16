using System;
using System.IO;
using oop_lab3.Classes.ProjectClasses.SerializerAdapter;

namespace oop_lab3.Classes.ProjectClasses.SerializerDecorator
{
    public abstract class BaseSerializerDecorator : ISerializer
    {
        protected readonly ISerializer Serializer;

        protected BaseSerializerDecorator(ISerializer serializer)
        {
            this.Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public abstract void Serialize(Stream stream, object data);

        public abstract object Deserialize(Stream stream);
    }
}