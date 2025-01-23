using Items;

namespace InventorySystems
{
    public interface IInventorySlot
    {
        public Item Item { get; }
        public int StackSize { get; }
        public void UpdateInventorySlot(Item newItem, int itemAmount);
        public void ClearSlot();
    }
}