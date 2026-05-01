using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerEffectsData", menuName = "Scriptable Objects/PlayerEffectsData")]
    public class PlayerEffectsData : ScriptableObject
    {
        [Header("Death")]
        [Header("Camera Shake")]
        public float cameraShakeStrength;

        [Header("Dash")]
        [Header("After Images")]
        public float imageDuration;
        public float startingAlpha;
        public float delayBetweenImages;
    }
}