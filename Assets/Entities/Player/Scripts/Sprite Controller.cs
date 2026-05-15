using UnityEngine;

namespace Entities.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteController : MonoBehaviour
    {
        [SerializeField] private AudioController audioController;

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

        public void SetMovementValues(float xSpeed, float ySpeed)
        {
            animator.SetFloat("xSpeed", xSpeed);
            animator.SetFloat("ySpeed", ySpeed);
        }

        public void SetJumpBoolean(bool isJumping)
        {
            animator.SetBool("isJumping", isJumping);
        }

        public void TriggerGunshotAnimation()
        {
            animator.SetTrigger("hasShot");
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

        public void PlayWalkSFX()
        {
            audioController.PlayWalkSFX();
        }
    }
}