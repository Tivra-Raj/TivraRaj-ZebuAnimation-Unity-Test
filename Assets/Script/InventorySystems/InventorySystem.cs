using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystems
{
    [Serializable]
    public class InventorySystem
    {
        [SerializeField] private List<InventorySlot> inventorySlots;

        public List<InventorySlot> InventorySlots => inventorySlots;

        public int SlotCount => InventorySlots.Count;

        public UnityAction<InventorySlot> OnInventorySlotUpdate;

        public InventorySystem(int size)
        {
            inventorySlots = new List<InventorySlot>(size);

            for (int i = 0; i < size; i++)
            {
                inventorySlots.Add(new InventorySlot());
            }
        }

        public bool AddToInventory(Item itemToAdd, int amountToAdd)
        {
            if(IsContainItem(itemToAdd, out List<InventorySlot> inventorySlot)) // check if slot conatain item or not
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

            if(HasFreeSlot(out InventorySlot freeSlot)) // to get the fist free available slot
            {
                freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
                OnInventorySlotUpdate?.Invoke(freeSlot);
                return true;
            }

            return false;
        }

        public bool IsContainItem(Item itemToAdd, out List<InventorySlot> inventorySlot)
        {
            inventorySlot = InventorySlots.Where(slot => slot.Item == itemToAdd).ToList();
            Debug.Log(inventorySlot.Count);
            return inventorySlot == null ? false : true;
        }

        public bool HasFreeSlot(out InventorySlot freeSlot)
        {
            freeSlot = InventorySlots.FirstOrDefault(slot => slot.Item == null);
            return freeSlot == null ? false : true;
        }
    }
}