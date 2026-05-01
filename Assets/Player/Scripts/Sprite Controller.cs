using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class SpriteController : MonoBehaviour
    {
        private Animator animator;
        private SpriteRenderer sr;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();
        }

        public void Flip()
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        public void SetMovementAnimations(float xSpeed, float ySpeed)
        {
            animator.SetFloat("xSpeed", xSpeed);
            animator.SetFloat("ySpeed", ySpeed);
        }

        public void TriggerAttackAnimation(bool isActivating)
        {

        }
    }
}