using DG.Tweening;
using UnityEngine;

namespace Levels.Level0
{
    [CreateAssetMenu(fileName = "Level0Data", menuName = "Scriptable Objects/Level0Data")]
    public class Level0Data : ScriptableObject
    {
        [Header("Transitions")]
        public float fadeInDuration;
        public Ease fadeInEase;
        public float fadeOutDuration;
        public Ease fadeOutEase;
        public float musicFadeInDuration;

        [Header("Button Animations")]
        [Header("Fade Out")]
        public float buttonFadeOutDuration;
        public Ease buttonFadeOutEase;

        [Header("Movement")]
        public float moveDelay;
        public float moveDistance;
        public float moveDuration;
        public Ease moveEase;
    }
}