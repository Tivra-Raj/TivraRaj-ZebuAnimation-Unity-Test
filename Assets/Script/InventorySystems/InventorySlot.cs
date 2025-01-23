using Items;
using System;
using UnityEngine;

namespace InventorySystems
{
    [Serializable]
    public class InventorySlot
    {
        [SerializeField] private Item item;
        [SerializeField] private int stackSize;

        public Item Item => item;
        public int StackSize => stackSize;

        public InventorySlot(Item newItem, int itemAmount)
        {
            item = newItem;
            stackSize = itemAmount;
        }

        public InventorySlot()
        {
            ClearSlot();
        }

        public void UpdateInventorySlot(Item newItem, int itemAmount)
        {
            item = newItem;
            stackSize = itemAmount;
        }

        public void ClearSlot()
        {
            item = null;
            stackSize = -1;
        }

        public bool RoomLeftInStack(int amountToAdd, out int remainingAmount)
        {
            remainingAmount = item.MaxStackSize - stackSize;
            return RoomLeftInStack(amountToAdd);
        }

        public bool RoomLeftInStack(int amountToAdd)
        {
            if(stackSize + amountToAdd <= item.MaxStackSize) return true;
            else return false;
        }

        public void AddToStack(int amount)
        {
            stackSize += amount;
        }

        public void RemoveFromStack(int amount)
        {
            stackSize -= amount;
        }
    }
}