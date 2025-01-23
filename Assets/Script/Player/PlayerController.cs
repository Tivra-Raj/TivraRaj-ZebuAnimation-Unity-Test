using GameInput;
using InventorySystems;
using Items;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IInputHandler inputHandler;
        [SerializeField] private Rigidbody rb;

        public float moveSpeed = 5f;
        public float rotationSpeed = 10f;

        private Vector2 movementInput;

        public InventoryHolder inventoryHolder;

        void Start()
        {
            inputHandler = new KeyboardInput();
        }

        void Update()
        {
            movementInput = inputHandler.GetMovementInput();
        }

        private void FixedUpdate()
        {
            if (movementInput.y != 0)
            {
                Move();
            }
            else
            {
                rb.velocity = Vector3.zero;
            }

            if (movementInput.x != 0)
            {
                Turn(movementInput.x, rotationSpeed);
            }
        }

        public void Move()
        {
            rb.velocity = transform.forward * movementInput.y * moveSpeed * Time.deltaTime;
        }

        public void Turn(float rotationInput, float rotationSpeed)
        {
            float turn = rotationInput * rotationSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        private void OnTriggerEnter(Collider other)
        {
            ICollectible collectible = other.GetComponent<ICollectible>();
            if (collectible != null)
            {
                Item itemData = collectible.Collect();
                if (inventoryHolder != null && inventoryHolder.InventorySystem.AddItemToInventory(itemData, 1))
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}