using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Entities.Player.Effects
{
    public class GunshotKnockback : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;
        [SerializeField] private Rigidbody2D playerRb;

        public bool finished;

        public void ApplyEffect(int knockbackDirection)
        {
            finished = false;

            StartCoroutine(Routine(knockbackDirection));
        }

        private IEnumerator Routine(int knockbackDirection)
        {
            playerRb.linearVelocityX = 0;
            playerRb.AddForceX(playerEffectsData.gunshotKnockbackForce * knockbackDirection, ForceMode2D.Impulse);

            yield return new WaitForSeconds(playerEffectsData.knockbackDuration);

            finished = true;
        }
    }
}