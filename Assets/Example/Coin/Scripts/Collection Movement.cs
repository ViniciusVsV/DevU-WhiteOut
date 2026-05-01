using DG.Tweening;
using UnityEngine;

namespace Coin
{
    public class CollectionMovement : MonoBehaviour
    {
        [SerializeField] private CoinData coinData;

        public void ApplyEffect(Transform transform)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.SetLink(transform.gameObject);

            sequence.Append(transform.DOMoveY(transform.position.y + coinData.upwardDistance, coinData.upwardDuration)).SetEase(coinData.upwardEase);
            sequence.Append(transform.DOScale(Vector3.zero, coinData.disappearDuration)).SetEase(coinData.disappearEase);
            sequence.OnComplete(() =>
            {
                Destroy(transform.gameObject);
            });
        }
    }
}