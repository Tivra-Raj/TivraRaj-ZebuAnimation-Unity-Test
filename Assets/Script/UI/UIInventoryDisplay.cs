using InventorySystems;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class UIInventoryDisplay : MonoBehaviour
    {
        protected InventorySystem inventorySystem;
        protected Dictionary<InventorySlotUI, InventorySlot> slotDictionary;

        public InventorySystem InventorySystem => inventorySystem;
        public Dictionary<InventorySlotUI, InventorySlot> SlotDictionary => slotDictionary;

        protected virtual void Start() { }

        public abstract void AssignSlot(InventorySystem inventoryToDisplay);

        public virtual void UpdateSlot(InventorySlot passedSlot)
        {
            foreach(var slot in SlotDictionary)
            {
                if(slot.Value == passedSlot) // item present in real slot
                {
                    slot.Key.UpdateSlotUI(passedSlot); // representation of that Item
                }

            }
        }
    }
}