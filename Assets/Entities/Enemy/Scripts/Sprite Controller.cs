using UnityEngine;

namespace Entities.Enemy
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteController : MonoBehaviour
    {
        [SerializeField] private EnemyBehaviourData enemyBehaviourData;

        private Animator animator;
        private SpriteRenderer sr;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();

            animator.runtimeAnimatorController = enemyBehaviourData.GetRandomSpriteVariant();
        }

        public void Flip()
        {
            sr.flipX = !sr.flipX;
        }

        public void SetMovementValues(float xSpeed)
        {
            animator.SetFloat("xSpeed", xSpeed);
        }

        public void TriggerDeathAnimation()
        {
            animator.SetTrigger("hasDied");
        }
        public float GetDeathAnimationLength()
        {
            return enemyBehaviourData.baseDeathClip.length;
        }

        public void DisableSprite()
        {
            sr.enabled = false;
        }
    }
}