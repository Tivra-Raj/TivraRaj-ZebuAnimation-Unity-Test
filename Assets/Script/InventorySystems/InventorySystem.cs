using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystems
{
    [Serializable]
    public class InventorySystem
    {
        [SerializeField] private List<InventorySlot> inventorySlots;

        public List<InventorySlot> InventorySlots => inventorySlots;

        public int SlotCount => inventorySlots.Count;

        public UnityAction<InventorySlot> OnInventorySlotUpdate;

        public InventorySystem(int size)
        {
            inventorySlots = new List<InventorySlot>(size);

            for (int i = 0; i < size; i++)
            {
                inventorySlots.Add(new InventorySlot());
            }
        }
    }
}