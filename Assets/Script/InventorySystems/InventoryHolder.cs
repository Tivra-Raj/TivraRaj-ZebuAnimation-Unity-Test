using UnityEngine;

namespace InventorySystems
{
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField] private int inventorySize;
        [SerializeField] protected InventorySystem inventorySystem;

        public InventorySystem InventorySystem => inventorySystem;

        private void Awake()
        {
            inventorySystem = new InventorySystem(inventorySize);
        }
    }
}