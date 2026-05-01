using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviourData playerBehaviourData;
        [SerializeField] private MovementController movementController;

        private float dashCooldownTimer;

        private void Update()
        {
            if (dashCooldownTimer > Mathf.Epsilon)
                dashCooldownTimer -= Time.deltaTime;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Vector2 moveDirection = context.ReadValue<Vector2>();
                moveDirection = moveDirection.normalized;

                movementController.Move((int)moveDirection.x);
            }
            else
                movementController.Move(0);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                movementController.Jump();
            else
                movementController.JumpCut();
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (movementController.canDash & dashCooldownTimer <= Mathf.Epsilon & context.performed)
            {
                dashCooldownTimer = playerBehaviourData.dashCooldown;
                StartCoroutine(movementController.Dash());
            }
        }
    }
}