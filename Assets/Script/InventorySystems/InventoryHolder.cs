using UnityEngine;

namespace InventorySystems
{
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField] private int inventorySize;
        [SerializeField] protected InventorySystem inventorySystem;

        public InventorySystem InventorySystem => inventorySystem;

        void Start()
        {
            inventorySystem = new InventorySystem(inventorySize);
        }
    }
}