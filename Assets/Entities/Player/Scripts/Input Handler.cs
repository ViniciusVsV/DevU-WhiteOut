using System;
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
        public bool pauseDisabled;
        public bool isPaused;
        public bool isOnController;

        public static event Action OnPausePressed;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (inputsDisabled || movementDisabled)
            {
                behaviourController.Move(0);
                return;
            }


            Vector2 moveDirection = context.ReadValue<Vector2>();
            moveDirection = moveDirection.normalized;

            if (Mathf.Abs(moveDirection.x) < 0.2f)
            {
                behaviourController.Move(0);
                return;
            }

            behaviourController.Move((int)Mathf.Sign(moveDirection.x));
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

        public void OnPause(InputAction.CallbackContext context)
        {
            if (pauseDisabled)
                return;

            if (context.performed)
            {
                if (isPaused)
                {
                    inputsDisabled = false;
                    isPaused = false;
                }
                else
                {
                    inputsDisabled = true;
                    isPaused = true;
                }

                OnPausePressed?.Invoke();
            }
        }

        public void CheckForController(InputAction.CallbackContext context)
        {
            if (context.control.device is Gamepad)
                isOnController = true;
            else
                isOnController = false;
        }
    }
}