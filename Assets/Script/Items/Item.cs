using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "CreateItem / Item ")]
    public class Item : ScriptableObject
    {
        [SerializeField] private string itemName;
        [SerializeField] private Sprite itemIcon;

        [TextArea(4, 4)]
        [SerializeField] private string itemDescription;

        [Range(1, 5)]
        [SerializeField] private int maxStackSize;

        public Sprite ItemIcon => itemIcon;
        public int MaxStackSize => maxStackSize;
    }
}