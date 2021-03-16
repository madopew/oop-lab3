namespace oop_lab3.Classes.GameClasses.ItemClasses
{
    internal interface IStackable
    {
        int Amount { get; set; }
        int StackMax { get; }
        void Add();
        void Add(int addAmount);
        void Remove();
        void Remove(int removeAmount);
    }
}