using System.Collections;
using UnityEngine;

namespace Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BehaviourController : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private PlayerBehaviourData playerBehaviourData;

        [Header("Player Scripts")]
        [SerializeField] private SpriteController spriteController;
        [SerializeField] private CapsuleCollider2D attackCollider;

        private Rigidbody2D rb;

        private int moveDirection;
        private int lastMoveDirection = 1;
        private int remainingJumps;
        private float jumpBufferTimer;
        private float coyoteTimer;

        [Header("Ground Check")]
        [SerializeField] private Transform groundCheckPoint;
        [SerializeField] private Vector2 groundCheckBoxSize;
        [SerializeField] private LayerMask groundLayerMask;
        private bool isGrounded;

        [Header("Booleans")]
        public bool canMove;
        public bool canJump;
        public bool canAttack;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();

            canMove = true;
            canJump = true;
            canAttack = true;
        }

        private void Update()
        {
            isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckBoxSize, 0f, groundLayerMask);
            coyoteTimer = isGrounded ? playerBehaviourData.coyoteTime : coyoteTimer - Time.deltaTime;

            remainingJumps = isGrounded ? playerBehaviourData.extraJumps : remainingJumps;
            jumpBufferTimer -= Time.deltaTime;
            Jump();

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
            {
                if (moveDirection != lastMoveDirection)
                    spriteController.Flip();

                lastMoveDirection = moveDirection;
            }
        }

        public void BufferJump()
        {
            jumpBufferTimer = playerBehaviourData.jumpBuffer;
        }
        public void Jump()
        {
            if (!canJump)
                return;

            if (jumpBufferTimer >= Mathf.Epsilon && (coyoteTimer >= Mathf.Epsilon || remainingJumps > 0))
            {
                jumpBufferTimer = 0;

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

        public IEnumerator Attack()
        {
            if (!canAttack)
                yield break;

            canAttack = false;
            canMove = false;

            rb.linearVelocityX = 0;
            rb.AddForceX(playerBehaviourData.knockbackForce * -lastMoveDirection, ForceMode2D.Impulse);

            attackCollider.enabled = true;

            yield return new WaitForSeconds(playerBehaviourData.attackDuration);

            attackCollider.enabled = false;

            canMove = true;
            canAttack = true;
        }
    }
}