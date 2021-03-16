using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using oop_lab3.Classes.ProjectClasses.Plugin;
using oop_lab3.Classes.ProjectClasses.SerializerAdapter;

namespace oop_lab3.Classes.ProjectClasses.SerializerDecorator
{
    public class PluginSerializerDecorator : BaseSerializerDecorator
    {
        private readonly ICollection<IStreamConverterPlugin> plugins;
        
        public PluginSerializerDecorator(ISerializer serializer, ICollection<IStreamConverterPlugin> plugins) 
            : base(serializer)
        {
            if (plugins is null)
            {
                throw new ArgumentNullException(nameof(plugins));
            }

            if (plugins.Any(p => p is null))
            {
                throw new ArgumentNullException(nameof(plugins), "One of the plugins is null");
            }

            this.plugins = plugins;
        }

        public override void Serialize(Stream stream, object data)
        {
            foreach (var plugin in plugins)
            {
                stream = plugin.DecorateStream(stream);
            }
            
            Serializer.Serialize(stream, data);
        }

        public override object Deserialize(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}