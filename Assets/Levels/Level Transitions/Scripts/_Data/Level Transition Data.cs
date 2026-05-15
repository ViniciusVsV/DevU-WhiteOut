using DG.Tweening;
using UnityEngine;

namespace Levels.LevelTransitions
{
    [CreateAssetMenu(fileName = "LevelTransitionData", menuName = "Scriptable Objects/LevelTransitionData")]
    public class LevelTransitionData : ScriptableObject
    {
        public Material transitionShaderMaterial;

        [Header("Scene Order")]
        public string[] sceneNames;

        [Header("Level Enter")]
        public float enterDuration;
        public Ease enterEase;
        public Texture2D enterTexture;

        [Header("Level ReEnter")]
        public float reRenterDuration;
        public Ease reRenterEase;
        public Texture2D reRenterTexture;

        [Header("Level Fail")]
        public float failStartDelay;
        public float failDuration;
        public Ease failEase;
        public Texture2D failTexture;

        [Header("Level Exit")]
        public float exitDuration;
        public Ease exitEase;
        public Texture2D exitTexture;
    }
}