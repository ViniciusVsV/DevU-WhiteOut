using System.Collections;
using Entities.Enemy.Effects;
using UnityEngine;

namespace Entities.Enemy
{
    public class EffectsController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D enemyRb;
        [SerializeField] private Collider2D enemyWeaponCol;

        [Header("Enemy Scripts")]
        [SerializeField] private SpriteController spriteController;
        [SerializeField] private AudioController audioController;

        [Header("Death Effects")]
        [SerializeField] private DeathParticles deathParticles;

        public bool deathEffectsFinished;

        public void PlayDeathEffects(Vector2 colDirection)
        {
            spriteController.TriggerDeathAnimation();
            audioController.PlayDeathSFX();

            deathEffectsFinished = false;

            enemyRb.simulated = false;
            enemyWeaponCol.enabled = false;

            StartCoroutine(DeathEffectsRoutine(colDirection));
        }
        private IEnumerator DeathEffectsRoutine(Vector2 colDirection)
        {
            yield return new WaitForEndOfFrame();

            deathParticles.ApplyEffect(colDirection);

            yield return new WaitForSeconds(spriteController.GetDeathAnimationLength());

            spriteController.DisableSprite();

            deathEffectsFinished = true;
        }
    }
}