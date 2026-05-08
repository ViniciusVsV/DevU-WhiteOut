using UnityEngine;

namespace Entities.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
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

        public void TriggerGunshotAnimation()
        {

        }

        public void TriggerDeathAnimation()
        {
            animator.SetTrigger("hasDied");
        }
        public float GetDeathAnimationLength()
        {
            foreach (var clip in animator.runtimeAnimatorController.animationClips)
            {
                if (clip.name == "Die")
                    return clip.length;
            }

            return 0f;
        }

        public void DisableSprite()
        {
            sr.enabled = false;
        }

        public void SetUnscaledTime()
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

        public SpriteRenderer GetSpriteRenderer() { return sr; }
    }
}