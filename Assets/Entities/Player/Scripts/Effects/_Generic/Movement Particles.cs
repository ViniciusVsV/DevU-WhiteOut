using UnityEngine;

namespace Entities.Player.Effects
{
    public class MovementParticles : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;
        [SerializeField] private ParticleSystem runParticles;
        [SerializeField] private ParticleSystem jumpParticles;
        private float runParticlesTimer;

        private bool runParticlesActive;

        private void Update()
        {
            if (runParticlesTimer > Mathf.Epsilon)
                runParticlesTimer -= Time.deltaTime;
            else
            {
                if (runParticlesActive)
                {
                    runParticles.Play();
                    runParticlesTimer = playerEffectsData.runParticlesCooldown;
                }
            }
        }

        public void ToggleRunparticles(bool activate)
        {
            if (activate)
                runParticlesActive = true;
            else
                runParticlesActive = false;
        }

        public void PlayJumpParticles()
        {
            jumpParticles.Play();
        }
    }
}