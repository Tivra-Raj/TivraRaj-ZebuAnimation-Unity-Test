using InventorySystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] private Image itemSprite;
        [SerializeField] private TextMeshProUGUI itemCount;
        [SerializeField] private IInventorySlot assignedSlot;

        private void Awake()
        {
            ClearSlotUI();
        }

        public void Init(IInventorySlot slot)
        {
            assignedSlot = slot;
            UpdateSlotUI(slot);
        }

        private void ClearSlotUI()
        {
            assignedSlot?.ClearSlot();
            itemSprite.sprite = null;
            itemSprite.color = Color.clear;
            itemCount.text = "";
        }

        public void UpdateSlotUI(IInventorySlot slot)
        {
            if (slot.Item != null)
            {
                UpdateItemImage(slot);
                UpdateItemCount(slot);
            }
            else
            {
                ClearSlotUI();
            }
        }

        public void UpdateSlotUI()
        {
            if(assignedSlot != null)
                UpdateSlotUI(assignedSlot);
        }

        private void UpdateItemImage(IInventorySlot slot)
        {
            itemSprite.sprite = slot.Item.ItemIcon;
            itemSprite.color = Color.white;
        }

        private void UpdateItemCount(IInventorySlot slot)
        {
            if (slot.StackSize > 1)
                itemCount.text = slot.StackSize.ToString();
            else
                itemCount.text = "";
        }
    }
}