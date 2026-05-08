using System;
using DG.Tweening;
using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerEffectsData", menuName = "Scriptable Objects/PlayerEffectsData")]
    public class PlayerEffectsData : ScriptableObject
    {
        [Header("DEATH")]
        [Header("Camera Shake")]
        public float cameraShakeStrength;

        [Header("Knockback")]
        public float deathKnockbackDistance;
        public float deathKnockbackDuration;
        public Ease deathKnockbackEase;
        public float wallDetectedOffset;

        [Header("Partial Transition")]
        public Texture2D partialTransitionTexture;
        public float partialTransitionDuration;
        public Ease partialTransitionEase;
        [Range(-1, 1)] public float partialTransitionProgress;

        [Header("Time Slow")]
        public float slowDuration;

        [Header("Controller Rumble")]
        public float deathLowFrequency;
        public float deathHighFrequency;
        public float deathRumbleDuration;

        [Header("GUNSHOT")]
        [Header("Camera Recoil")]
        public float cameraRecoilStrength;

        [Header("Knockback")]
        public float gunshotKnockbackForce;
        public float knockbackDuration;

        [Header("After Images")]
        public float imageDuration;
        public float startingAlpha;
        public float delayBetweenImages;

        [Header("Controller Rumble")]
        public float gunshotLowFrequency;
        public float gunshotHighFrequency;
        public float gunshotRumbleDuration;
    }
}