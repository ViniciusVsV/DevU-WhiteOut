using DG.Tweening;
using UnityEngine;

namespace Entities.Player.Effects
{
    public class GunshotKnockback : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;
        [SerializeField] private Rigidbody2D playerRb;

        public void ApplyEffect(int knockbackDirection)
        {
            playerRb.linearVelocityX = 0;
            playerRb.AddForceX(playerEffectsData.gunshotKnockbackForce * knockbackDirection, ForceMode2D.Impulse);
        }
    }
}