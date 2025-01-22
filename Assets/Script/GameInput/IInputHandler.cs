using UnityEngine;

namespace GameInput
{
    public interface IInputHandler
    {
        public Vector2 GetMovementInput();
        public bool GetInteractionInput();
    }
}