using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventorySystems
{
    [Serializable]
    public class InventorySystem : IInventorySystem
    {
        [SerializeField] private List<InventorySlot> inventorySlots;

        public List<IInventorySlot> InventorySlots => inventorySlots.Cast<IInventorySlot>().ToList();
        public int SlotCount => InventorySlots.Count;

        public event Action<IInventorySlot> OnInventorySlotUpdate;

        public InventorySystem(int size)
        {
            CreatInventorySlot(size);
        }

        private void CreatInventorySlot(int slotSize)
        {
            inventorySlots = new List<InventorySlot>(slotSize);
            for (int i = 0; i < slotSize; i++)
            {
                inventorySlots.Add(new InventorySlot());
            }
        }

        public bool AddItemToInventory(Item itemToAdd, int amountToAdd)
        {
            if(IsContainItem(itemToAdd, out List<IInventorySlot> inventorySlot)) // check if slot conatain item or not
            {
                foreach(InventorySlot slot in inventorySlot)
                {
                    if(slot.RoomLeftInStack(amountToAdd))
                    {
                        slot.AddToStack(amountToAdd);
                        OnInventorySlotUpdate?.Invoke(slot);
                        return true;
                    }
                }
            }

            if(HasFreeSlot(out IInventorySlot freeSlot)) // to get the fist free available slot
            {
                freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
                OnInventorySlotUpdate?.Invoke(freeSlot);
                return true;
            }

            return false;
        }

        public bool IsContainItem(Item itemToAdd, out List<IInventorySlot> inventorySlot)
        {
            inventorySlot = InventorySlots.Where(slot => slot.Item == itemToAdd).ToList();
            Debug.Log(inventorySlot.Count);
            return inventorySlot == null ? false : true;
        }

        public bool HasFreeSlot(out IInventorySlot freeSlot)
        {
            freeSlot = InventorySlots.FirstOrDefault(slot => slot.Item == null);
            return freeSlot == null ? false : true;
        }
    }
}