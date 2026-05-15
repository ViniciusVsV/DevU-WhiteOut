using DG.Tweening;
using UnityEngine;

namespace TutorialText
{
    [CreateAssetMenu(fileName = "TutorialTextData", menuName = "Scriptable Objects/TutorialTextData")]
    public class TutorialTextData : ScriptableObject
    {
        [Header("Text Pop Up")]
        public float upwardTextDistance;
        public float upwardIconDistance;
        public float upwardDuration;
        public Ease upwardEase;
        public float fadeInDuration;
        public Ease fadeInEase;
    }
}