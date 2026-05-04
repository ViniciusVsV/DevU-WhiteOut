using System.Collections;
using Entities.Enemy.Effects;
using UnityEngine;

namespace Entities.Enemy
{
    public class EffectsController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D enemyRb;
        [SerializeField] private SpriteRenderer enemySr;
        [SerializeField] private Collider2D enemyWeaponCol;

        [Header("Death Effects")]
        [SerializeField] private DeathParticles deathParticles;

        public bool deathEffectsFinished;

        public void PlayDeathEffects(Vector2 colDirection)
        {
            enemyRb.simulated = false;
            enemySr.enabled = false;
            enemyWeaponCol.enabled = false;

            deathEffectsFinished = false;

            deathParticles.ApplyEffect(colDirection);

            StartCoroutine(DeathEffectsRoutine());
        }
        private IEnumerator DeathEffectsRoutine()
        {
            yield return new WaitForSeconds(0.1f);

            deathEffectsFinished = true;
        }
    }
}