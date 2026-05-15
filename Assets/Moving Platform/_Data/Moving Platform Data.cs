using DG.Tweening;
using UnityEngine;

namespace MovingPlatform
{
    [CreateAssetMenu(fileName = "MovingPlatformData", menuName = "Scriptable Objects/MovingPlatformData")]
    public class MovingPlatformData : ScriptableObject
    {
        public float moveSpeed;
        public AnimationCurve moveCurve;
        public float waitDuration;
    }
}