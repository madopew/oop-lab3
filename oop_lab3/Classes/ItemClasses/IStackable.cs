namespace oop_lab3.Classes.ItemClasses
{
    internal interface IStackable
    {
        int Amount { get; set; }
        int StackMax { get; }
        void Add();
        void Add(int amount);
        void Remove();
        void Remove(int amount);
    }
}