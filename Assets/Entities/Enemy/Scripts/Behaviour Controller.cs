using System.Collections;
using UnityEngine;

namespace Entities.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BehaviourController : MonoBehaviour
    {
        [SerializeField] private EnemyBehaviourData enemyBehaviourData;
        [SerializeField] private SpriteController spriteController;

        private Rigidbody2D rb;
        private int moveDirection = 1;
        public bool canMove;

        private Coroutine coroutine;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();

            canMove = true;
        }

        private void Update()
        {
            spriteController.SetMovementValues(Mathf.Abs(rb.linearVelocityX));
        }

        private void FixedUpdate()
        {
            if (canMove)
                rb.linearVelocityX = moveDirection * enemyBehaviourData.moveSpeed;
            else
                rb.linearVelocityX = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Border"))
            {
                if (coroutine != null)
                    return;

                coroutine = StartCoroutine(FlipRoutine());
            }
        }

        private IEnumerator FlipRoutine()
        {
            canMove = false;

            rb.linearVelocityX = 0;

            yield return new WaitForSeconds(Random.Range(enemyBehaviourData.minWaitDuration, enemyBehaviourData.maxWaitDuration));

            spriteController.Flip();
            moveDirection *= -1;

            canMove = true;

            yield return new WaitForSeconds(0.1f);

            coroutine = null;
        }
    }
}