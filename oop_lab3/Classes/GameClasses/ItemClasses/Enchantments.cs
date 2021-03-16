using System;

namespace oop_lab3.Classes.GameClasses.ItemClasses
{
    [Flags]
    public enum Enchantments
    {
        None = 0,
        Sharpness = 1,
        Flame = 2,
        Knockoff = 4,
    }
}