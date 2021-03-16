using oop_lab3.Classes.GameClasses.ItemClasses;

namespace oop_lab3.Classes.GameClasses.InventoryClasses
{
    public sealed partial class Inventory
    {
        private sealed class Slot
        {
            public Slot()
            {
                this.Item = null;
            }

            public Item Item { get; set; }

            public bool PickUp(Item item)
            {
                if (this.Item is null)
                {
                    this.Item = item;

                    return true;
                }

                IStackable currentItem = this.Item as IStackable;

                if (currentItem == null)
                {
                    return false;
                }

                if (item.Type != this.Item.Type)
                {
                    return false;
                }

                IStackable itemAdd = (IStackable) item;

                if (currentItem.Amount + itemAdd.Amount > currentItem.StackMax)
                {
                    return false;
                }

                currentItem.Add(itemAdd.Amount);
                return true;
            }

            public Item Drop()
            {
                if (this.Item is null)
                {
                    return null;
                }

                Item droppedItem = this.Item;

                IStackable item = this.Item as IStackable;
                if (item != null)
                {
                    if (item.Amount > 1)
                    {
                        item.Remove();
                    }
                    else
                    {
                        this.Item = null;
                    }
                }
                else
                {
                    this.Item = null;
                }

                return droppedItem;
            }

            public Item DropAll()
            {
                if (this.Item is null)
                {
                    return null;
                }

                Item droppedItem = this.Item;
                this.Item = null;

                return droppedItem;
            }
        }
    }
}
