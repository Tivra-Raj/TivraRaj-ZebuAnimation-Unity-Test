using UnityEngine;

namespace GameInput
{
    public class KeyboardInput : IInputHandler
    {
        public Vector2 GetMovementInput()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            return new Vector2(horizontal, vertical);
        }

        public bool GetInteractionInput()
        {
            throw new System.NotImplementedException();
        }
    }
}