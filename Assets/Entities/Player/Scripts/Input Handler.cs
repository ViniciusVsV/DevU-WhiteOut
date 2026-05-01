using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviourData playerBehaviourData;
        [SerializeField] private BehaviourController behaviourController;

        [Header("Booleans")]
        public bool inputsDisabled;
        public bool movementDisabled;
        public bool jumpDisabled;
        public bool attackDisabled;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (inputsDisabled || movementDisabled)
            {
                behaviourController.Move(0);
                return;
            }

            if (context.performed)
            {
                Vector2 moveDirection = context.ReadValue<Vector2>();
                moveDirection = moveDirection.normalized;

                behaviourController.Move((int)moveDirection.x);
            }
            else
                behaviourController.Move(0);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (inputsDisabled || jumpDisabled)
                return;

            if (context.performed)
                behaviourController.BufferJump();
            else
                behaviourController.JumpCut();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (inputsDisabled || attackDisabled)
                return;

            if (context.performed)
                StartCoroutine(behaviourController.Attack());
        }
    }
}