using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities.Player.Effects
{
    public class ControllerRumble : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;

        private Gamepad gamepad;
        private Coroutine coroutine;


        public void ApplyEffect(bool isDeathEffect)
        {
            gamepad = Gamepad.current;

            if (gamepad != null)
            {
                if (coroutine != null)
                    StopCoroutine(coroutine);

                if (isDeathEffect)
                    coroutine = StartCoroutine(Routine(playerEffectsData.deathLowFrequency, playerEffectsData.deathHighFrequency, playerEffectsData.deathRumbleDuration));
                else
                    coroutine = StartCoroutine(Routine(playerEffectsData.gunshotLowFrequency, playerEffectsData.gunshotHighFrequency, playerEffectsData.gunshotRumbleDuration));
            }
        }

        private IEnumerator Routine(float lowFrequency, float highFrequency, float duration)
        {
            gamepad.SetMotorSpeeds(lowFrequency, highFrequency);

            yield return new WaitForSeconds(duration);

            gamepad.SetMotorSpeeds(0f, 0f);
        }
    }
}