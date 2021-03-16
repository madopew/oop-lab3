using System;

namespace oop_lab3.Classes.GameClasses.Other
{
    [Serializable]
    public class Color
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        private Color()
            : this(255, 255, 255)
        {
        }

        public Color(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public override string ToString()
        {
            return $"rgb({R}, {G}, {B})";
        }
    }
}
