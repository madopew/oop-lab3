using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_lab3.Classes.ItemClasses;

namespace oop_lab3.Classes.StackableItemClasses
{
    public abstract class StackableItem : Item, IStackable
    {
        public int Amount { get; private set; }
        public abstract int StackMax { get; }

        protected StackableItem()
        {
            this.Amount = 1;
        }

        public void Add()
        {
            this.Add(1);
        }

        public void Add(int amount)
        {
            if (this.Amount + amount > this.StackMax)
            {
                throw new InvalidOperationException("Amount exceeds stack max");
            }

            this.Amount += amount;
        }

        public void Remove()
        {
            this.Remove(1);
        }

        public void Remove(int amount)
        {
            if (this.Amount - amount < 1)
            {
                throw new InvalidOperationException("Amount less or equal to zero");
            }

            this.Amount -= amount;
        }
    }
}
