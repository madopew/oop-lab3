﻿using System.IO;

namespace oop_lab3.Classes.SerializerAdapter
{
    public interface ISerializer
    {
        void Serialize(Stream stream, object data);
        object Deserialize(Stream stream);
    }
}