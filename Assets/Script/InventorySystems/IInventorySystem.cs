using System.Collections.Generic;
using System;

namespace InventorySystems
{
    public interface IInventorySystem
    {
        public List<IInventorySlot> InventorySlots { get; }
        public int SlotCount { get; }
        public event Action<IInventorySlot> OnInventorySlotUpdate;
    }
}