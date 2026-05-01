using DG.Tweening;
using UnityEngine;

namespace Coin
{
    [CreateAssetMenu(fileName = "CoinData", menuName = "Scriptable Objects/CoinData")]
    public class CoinData : ScriptableObject
    {
        public int scoreValue;

        [Header("Effects")]
        [Header("Collection Movement")]
        public float upwardDistance;
        public float upwardDuration;
        public Ease upwardEase;
        public float disappearDuration;
        public Ease disappearEase;
    }
}