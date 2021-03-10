using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using oop_lab3.Classes.ItemClasses;

namespace oop_lab3.Classes.InventoryClasses
{
    [Serializable]
    public sealed partial class Inventory
    {
        private static volatile Inventory instance;
        private static readonly object padlock = new object();
        public static Inventory GetInstance(InventoryType type) 
        {
            if (instance is null)
            {
                lock (padlock)
                {
                    if (instance is null)
                    {
                        if (!Enum.IsDefined(typeof(InventoryType), type))
                        {
                            throw new ArgumentException("Not a enum", nameof(type));
                        }

                        instance = new Inventory(type);
                    }
                }
            }

            return instance;
        }

        private readonly Slot[] slots;

        private Inventory(InventoryType type)
        {
            slots = new Slot[(int)type];
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = new Slot();
            }

            this.Type = type;
        }

        public InventoryType Type { get; } 

        public Item this[int index]
        {
            get => slots[index].Item;
            set => slots[index].Item = value;
        }

        public bool PickUp(Item item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            }

            foreach (var slot in slots)
            {
                if (slot.PickUp(item))
                {
                    return true;
                }
            }

            return false;
        }

        public Item Drop(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex > slots.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(slotIndex), "Index is out of range of inventory");
            }

            if (slots[slotIndex] is null)
            {
                throw new ArgumentException(nameof(slotIndex));
            }

            return slots[slotIndex].Drop();
        }

        public Item DropAll(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex > slots.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(slotIndex), "Index is out of range of inventory");
            }

            return slots[slotIndex].DropAll();
        }

        public void Clear()
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = null;
            }
        }
    }
}
