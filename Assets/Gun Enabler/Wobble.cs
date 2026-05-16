using UnityEngine;
using DG.Tweening;

namespace GunEnabler
{
    public class Wobble : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveAmount = 0.25f;
        [SerializeField] private float moveDuration = 1f;

        private Vector3 startPos;

        private void Start()
        {
            startPos = transform.position;

            // Movimento de sobe/desce
            transform.DOMoveY(startPos.y + moveAmount, moveDuration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}