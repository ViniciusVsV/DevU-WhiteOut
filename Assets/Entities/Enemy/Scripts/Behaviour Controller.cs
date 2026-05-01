using System.Collections;
using UnityEngine;

namespace Entities.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BehaviourController : MonoBehaviour
    {
        [SerializeField] private EnemyBehaviourData enemyBehaviourData;

        private Rigidbody2D rb;
        private int moveDirection = 1;

        [Header("Booleans")]
        public bool canMove;
        public bool canFlip;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();

            canMove = true;
            canFlip = true;
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
            if (canFlip && collision.CompareTag("Border"))
            {
                canFlip = false;

                StartCoroutine(FlipRoutine());
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Border"))
                canFlip = true;
        }

        private IEnumerator FlipRoutine()
        {
            canMove = false;

            rb.linearVelocityX = 0;

            yield return new WaitForSeconds(Random.Range(enemyBehaviourData.minWaitDuration, enemyBehaviourData.maxWaitDuration));

            transform.localScale *= new Vector2(-1, 1);
            moveDirection *= -1;

            canMove = true;
        }
    }
}