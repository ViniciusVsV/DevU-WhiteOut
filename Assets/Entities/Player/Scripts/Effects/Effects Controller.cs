using System;
using System.Collections;
using Entities.Player.Effects;
using UnityEngine;

namespace Entities.Player
{
    public class EffectsController : MonoBehaviour
    {
        [Header("Player Objects")]
        [SerializeField] private Rigidbody2D playerRb;
        [SerializeField] private SpriteRenderer playerSr;

        [Header("Player Scripts")]
        [SerializeField] private SpriteController spriteController;
        [SerializeField] private AudioController audioController;
        [SerializeField] private InputHandler inputHandler;

        [Header("Generic Effects")]
        [SerializeField] private ControllerRumble controllerRumble;

        [Header("Gunshot Effects")]
        [SerializeField] private GunshotCameraRecoil gunshotCameraRecoil;
        [SerializeField] private GunshotKnockback gunshotKnockback;
        [SerializeField] private AfterImagesManager afterImagesManager;

        [Header("Death Effects")]
        [SerializeField] private DeathCameraShake deathCameraShake;
        [SerializeField] private DeathPartialTransition deathPartialTransition;
        [SerializeField] private DeathParticles deathParticles;
        [SerializeField] private DeathKnockback deathKnockback;
        [SerializeField] private DeathTimeSlow deathTimeSlow;

        public bool gunshotEffectsFinished;
        public bool deathEffectsFinished;

        public void PlayWalkEffects()
        {
            spriteController.SetMovementAnimations(Mathf.Abs(playerRb.linearVelocityX), playerRb.linearVelocityY);

        }

        public void PlayJumpEffects()
        {

        }

        public void PlayGunshotEffects(int shotDirection, Transform projectileTr, SpriteRenderer projectileSr)
        {
            spriteController.TriggerGunshotAnimation();
            audioController.PlayGunshotSFX();

            gunshotEffectsFinished = false;

            StartCoroutine(GunshotEffectsRoutine(shotDirection, projectileTr, projectileSr));
        }
        private IEnumerator GunshotEffectsRoutine(int shotDirection, Transform projectileTr, SpriteRenderer projectileSr)
        {
            //Ativa After Images
            afterImagesManager.StartAfterImages(playerRb.transform, playerSr);
            afterImagesManager.StartAfterImages(projectileTr, projectileSr);

            //Aplica recoil
            gunshotCameraRecoil.ApplyEffect(-shotDirection);

            //Aplica tremor do controle
            if (inputHandler.isOnController)
                controllerRumble.ApplyEffect(false);

            //Aplica knockback
            gunshotKnockback.ApplyEffect(-shotDirection);

            //Espera o tempinho do kockback
            yield return new WaitUntil(() => gunshotKnockback.finished);

            //Desativa after images
            afterImagesManager.StopAfterImages(playerRb.transform);

            gunshotEffectsFinished = true;
        }

        public void PlayDeathEffects(Vector3 collisionDirection)
        {
            spriteController.TriggerDeathAnimation();

            playerRb.simulated = false;

            deathEffectsFinished = false;

            StartCoroutine(DeathEffectsRoutine(collisionDirection));
        }
        private IEnumerator DeathEffectsRoutine(Vector3 collisionDirection)
        {
            //Treme a câmera
            deathCameraShake.ApplyEffect();

            //Aplica tremor do controle
            if (inputHandler.isOnController)
                controllerRumble.ApplyEffect(true);

            //Faz o animator ser unscaledTime
            spriteController.SetUnscaledTime();

            //Ativa time slow
            deathTimeSlow.ApplyEffect();

            //Aplica knockback
            deathKnockback.ApplyEffect(-collisionDirection);

            //chama a transição parcial
            deathPartialTransition.ApplyEffect();

            //Espera a animação de morte acabar
            yield return new WaitForSecondsRealtime(spriteController.GetDeathAnimationLength());

            //Desativa o sprite do player
            spriteController.DisableSprite();

            //Invoca as partículas
            deathParticles.ApplyEffect();

            deathEffectsFinished = true;
        }
    }
}