using InventorySystems;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class StaticInventoryDisplay : UIInventoryDisplay
    {
        [SerializeField] private InventoryHolder inventoryHolder;
        [SerializeField] private InventorySlotUI[] inventorySlotUIs;

        protected override void Start()
        {
            base.Start();

            if(inventoryHolder != null)
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

        public override void AssignSlot(InventorySystem inventoryToDisplay)
        {
            slotDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

            Debug.Log(inventorySystem.SlotCount);

            if (inventorySlotUIs.Length != inventorySystem.SlotCount)
                Debug.Log($"Inventory slot out of sync on {this.gameObject}");

            for(int i = 0; i < inventorySystem.SlotCount; i++)
            {
                slotDictionary.Add(inventorySlotUIs[i], inventorySystem.InventorySlots[i]);
                inventorySlotUIs[i].Init(inventorySystem.InventorySlots[i]);
            }
        }
    }
}