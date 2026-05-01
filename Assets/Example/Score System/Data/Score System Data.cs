using DG.Tweening;
using UnityEngine;

namespace ScoreSystem
{
    [CreateAssetMenu(fileName = "ScoreSystemData", menuName = "Scriptable Objects/ScoreSystemData")]
    public class ScoreSystemData : ScriptableObject
    {
        public int scoreToWin;

        [Header("Effects")]
        [Header("Text Pulse")]
        public float pulseSize;
        public float pulseDuration;
        public Ease pulseEase;
    }
}