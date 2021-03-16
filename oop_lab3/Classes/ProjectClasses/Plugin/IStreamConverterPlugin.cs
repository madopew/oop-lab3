using System.IO;

namespace oop_lab3.Classes.ProjectClasses.Plugin
{
    public interface IStreamConverterPlugin
    {
        Stream DecorateStream(Stream originalStream);
    }
}