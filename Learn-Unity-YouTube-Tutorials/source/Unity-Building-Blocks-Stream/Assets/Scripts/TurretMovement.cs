using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace DapperDino.BuildingBlocks
{
    public class TurretMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private Vector2 limits = new Vector2(-4f, 4f);

        private float previousInput;

        private void Update() => Move();

        public void MoveInput(CallbackContext ctx)
        {
            if (ctx.performed)
            {
                previousInput = ctx.ReadValue<float>();
                return;
            }

            if (ctx.canceled)
            {
                previousInput = 0f;
            }
        }

        private void Move()
        {
            float movement = previousInput * movementSpeed * Time.deltaTime;
            float newXValue = Mathf.Clamp(transform.position.x + movement, limits.x, limits.y);

            transform.position = new Vector3(newXValue, transform.position.y, transform.position.z);
        }
    }
}
