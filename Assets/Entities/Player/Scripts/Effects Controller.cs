using System;
using System.Collections;
using Entities.Player.Effects;
using UnityEngine;

namespace Entities.Player
{
    public class EffectsController : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;
        [SerializeField] private Rigidbody2D playerRb;

        [Header("Gunshot Effects")]
        [SerializeField] private GunshotCameraRecoil gunshotCameraRecoil;
        [SerializeField] private GunshotKnockback gunshotKnockback;

        [Header("Death Effects")]
        [SerializeField] private DeathCameraShake deathCameraShake;
        [SerializeField] private DeathPartialTransition deathPartialTransition;
        [SerializeField] private DeathParticles deathParticles;
        [SerializeField] private DeathKnockback deathKnockback;

        public static event Action OnPlayerDeath;

        public void PlayGunshotEffects(int shotDirection)
        {
            gunshotCameraRecoil.ApplyEffect(-shotDirection);
            gunshotKnockback.ApplyEffect(-shotDirection);
        }

        public IEnumerator PlayDeathEffects(Vector3 collisionDirection)
        {
            playerRb.simulated = false;

            //Treme a câmera
            deathCameraShake.ApplyEffect();

            //Chama efeito sonoro


            //Chama a animação


            //Aplica knockback
            deathKnockback.ApplyEffect(-collisionDirection);

            //chama a transição parcial
            deathPartialTransition.ApplyEffect();

            //Espera a animação de morte acabar
            yield return new WaitUntil(() => deathPartialTransition.finished);

            //Invoca as partículas
            deathParticles.ApplyEffect();

            //Invoka o evento
            OnPlayerDeath?.Invoke();

            yield break;

        }
    }
}