using System;
using oop_lab3.Classes.GameClasses.ItemClasses;

namespace oop_lab3.Classes.GameClasses.StackableItemClasses
{
    [Serializable]
    public abstract class StackableItem : Item, IStackable
    {
        private int amount;
        public int Amount
        {
            get => amount;
            set
            {
                if (value < 0 || value > this.StackMax)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.amount = value;
            }
        }
        public abstract int StackMax { get; }

        protected StackableItem()
        {
            this.Amount = 1;
        }

        public void Add()
        {
            this.Add(1);
        }

        public void Add(int addAmount)
        {
            if (this.Amount + addAmount > this.StackMax)
            {
                throw new InvalidOperationException("Amount exceeds stack max");
            }

            this.Amount += addAmount;
        }

        public void Remove()
        {
            this.Remove(1);
        }

        public void Remove(int removeAmount)
        {
            if (this.Amount - removeAmount < 1)
            {
                throw new InvalidOperationException("Amount less or equal to zero");
            }

            this.Amount -= removeAmount;
        }
    }
}
