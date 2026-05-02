using System;
using DG.Tweening;
using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerEffectsData", menuName = "Scriptable Objects/PlayerEffectsData")]
    public class PlayerEffectsData : ScriptableObject
    {
        [Header("Death")]
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

        [Header("Gunshot")]
        [Header("Camera Recoil")]
        public float cameraRecoilStrength;

        [Header("Knockback")]
        public float gunshotKnockbackForce;
    }
}