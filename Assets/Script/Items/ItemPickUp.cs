using UnityEngine;

namespace Items
{
    public class ItemPickUp : MonoBehaviour, ICollectible
    {
        [SerializeField] private Item itemData;

        public Item Collect()
        {
            return itemData;
        }
    }
}