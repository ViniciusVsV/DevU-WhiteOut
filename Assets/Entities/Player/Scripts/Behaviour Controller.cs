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
        [SerializeField] private EffectsController effectsController;
        [SerializeField] private SpriteController spriteController;
        [SerializeField] private ProjectileSpawner projectileSpawner;

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

            spriteController.SetMovementValues(Mathf.Abs(rb.linearVelocityX), rb.linearVelocityY);
            spriteController.SetJumpBoolean(!isGrounded);

            effectsController.PlayWalkEffects(isGrounded);
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

            bool hasCoyoteTime = coyoteTimer >= Mathf.Epsilon;
            bool hasRemainingJumps = remainingJumps > 0;

            if (jumpBufferTimer < Mathf.Epsilon || (!hasCoyoteTime && !hasRemainingJumps))
                return;

            if (!hasCoyoteTime)
                remainingJumps--;

            jumpBufferTimer = 0;

            rb.linearVelocityY = 0;
            rb.AddForce(playerBehaviourData.jumpForce * Vector2.up, ForceMode2D.Impulse);

            effectsController.PlayJumpEffects();
        }
        public void JumpCut()
        {
            if (rb.linearVelocityY > 0)
            {
                rb.linearVelocityY *= playerBehaviourData.jumpCutMultiplier;

                coyoteTimer = 0;
            }
        }

        public IEnumerator Attack()
        {
            if (!canAttack)
                yield break;

            canAttack = false;
            canMove = false;

            var (projectileTr, projectileSr) = projectileSpawner.SpawnProjectile(Vector2.one * lastMoveDirection);
            effectsController.PlayGunshotEffects(lastMoveDirection, projectileTr, projectileSr);

            yield return new WaitUntil(() => effectsController.gunshotEffectsFinished);

            canMove = true;
            canAttack = true;
        }
    }
}