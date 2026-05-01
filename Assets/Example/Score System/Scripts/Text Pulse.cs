using DG.Tweening;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class TextPulse : MonoBehaviour
    {
        [SerializeField] private ScoreSystemData scoreSystemData;
        private RectTransform textTransform;

        public void ApplyEffect(TextMeshProUGUI text)
        {
            textTransform = text.rectTransform;

            text.rectTransform.DOKill();

            Vector3 originalScale = text.rectTransform.localScale;

            text.rectTransform.DOScale(originalScale * scoreSystemData.pulseSize, 0)
                .OnComplete(() =>
                {
                    text.rectTransform.DOScale(originalScale, scoreSystemData.pulseDuration)
                        .SetEase(scoreSystemData.pulseEase);
                });
        }

        private void OnDisable()
        {
            textTransform.DOKill();
        }
    }
}