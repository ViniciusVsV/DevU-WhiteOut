using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviourData playerBehaviourData;
        [SerializeField] private EffectsHandler effectsHandler;

        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private Transform tr;

        private int moveDirection;
        private int lastMoveDirection = 1;
        private int remainingJumps;

        [Header("Ground Check")]
        [SerializeField] private Transform groundCheckPoint;
        [SerializeField] private Vector2 groundCheckBoxSize;
        [SerializeField] private LayerMask groundLayerMask;
        private bool isGrounded;

        [Header("Booleans")]
        public bool canMove;
        public bool canDash;
        public bool isDashing;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            tr = GetComponent<Transform>();

            canMove = true;
            canDash = true;
        }

        private void Update()
        {
            isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckBoxSize, 0f, groundLayerMask);

            remainingJumps = isGrounded ? playerBehaviourData.extraJumps : remainingJumps;

            if (isDashing)
                rb.gravityScale = 0;
            else
                rb.gravityScale = rb.linearVelocityY >= 0 ? playerBehaviourData.baseGravity : playerBehaviourData.fallGravity;
        }

        private void FixedUpdate()
        {
            if (canMove)
                rb.linearVelocityX = moveDirection * playerBehaviourData.moveSpeed;
        }

        public void Move(int moveDirection)
        {
            this.moveDirection = moveDirection;

            if (moveDirection != 0)
                lastMoveDirection = moveDirection;
        }

        public void Jump()
        {
            if (isGrounded || remainingJumps > 0)
            {
                if (!isGrounded)
                    remainingJumps--;

                rb.linearVelocityY = 0;
                rb.AddForce(playerBehaviourData.jumpForce * Vector2.up, ForceMode2D.Impulse);
            }
        }
        public void JumpCut()
        {
            if (rb.linearVelocityY > 0)
                rb.linearVelocityY *= playerBehaviourData.jumpCutMultiplier;
        }

        public IEnumerator Dash()
        {
            effectsHandler.ToggleDashEffects(true, tr, sr);

            canMove = false;
            isDashing = true;

            rb.linearVelocity = Vector2.zero;

            rb.linearVelocityX = playerBehaviourData.dashSpeed * lastMoveDirection;

            yield return new WaitForSeconds(playerBehaviourData.dashDuration);

            rb.linearVelocityX = 0;

            canMove = true;
            isDashing = false;

            effectsHandler.ToggleDashEffects(false, tr, sr);
        }
    }
}