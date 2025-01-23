using GameInput;
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
            Debug.Log(movementInput);
            rb.velocity = transform.forward * movementInput.y * moveSpeed * Time.deltaTime;
        }

        public void Turn(float rotationInput, float rotationSpeed)
        {
            float turn = rotationInput * rotationSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}