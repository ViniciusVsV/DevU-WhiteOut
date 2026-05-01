using UnityEngine;

namespace Player
{
    public class EffectsHandler : MonoBehaviour
    {
        [SerializeField] private AfterImagesManager afterImagesManager;
        [SerializeField] private CameraShake cameraShake;

        public void ToggleDashEffects(bool activate, Transform playerTr, SpriteRenderer spriteRenderer)
        {
            if (activate)
                afterImagesManager.StartAfterImages(playerTr, spriteRenderer);
            else
                afterImagesManager.StopAfterImages(playerTr);
        }

        public void ApplyDeathEffects()
        {
            cameraShake.ApplyEffect();
        }
    }
}