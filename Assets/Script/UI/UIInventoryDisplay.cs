using InventorySystems;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIInventoryDisplay : MonoBehaviour
    {
        [SerializeField] private InventoryHolder inventoryHolder;
        [SerializeField] private InventorySlotUI[] inventorySlotUIs;

        protected IInventorySystem inventorySystem;
        protected Dictionary<InventorySlotUI, IInventorySlot> slotDictionary;

        private void Start()
        {
            if (inventoryHolder != null)
            {
                inventorySystem = inventoryHolder.InventorySystem;
                inventorySystem.OnInventorySlotUpdate += UpdateSlot;
            }
            else
            {
                Debug.LogWarning($"No Inventory Assigned to {this.gameObject}");
            }

            AssignSlot(inventorySystem);
        }

        public void AssignSlot(IInventorySystem inventoryToDisplay)
        {
            slotDictionary = new Dictionary<InventorySlotUI, IInventorySlot>();

            if (inventorySlotUIs.Length != inventorySystem.SlotCount)
                Debug.Log($"Inventory slot out of sync on {this.gameObject}");

            for (int i = 0; i < inventorySystem.SlotCount; i++)
            {
                slotDictionary.Add(inventorySlotUIs[i], inventorySystem.InventorySlots[i]);
                inventorySlotUIs[i].Init(inventorySystem.InventorySlots[i]);
            }
        }

        public virtual void UpdateSlot(IInventorySlot passedSlot)
        {
            foreach(var slot in slotDictionary)
            {
                if(slot.Value == passedSlot) // item present in real slot
                {
                    slot.Key.UpdateSlotUI(passedSlot); // representation of that Item
                }

            }
        }
    }
}