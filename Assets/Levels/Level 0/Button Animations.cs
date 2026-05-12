using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.Level0
{
    public class ButtonAnimations : MonoBehaviour
    {
        [SerializeField] private Level0Data level0Data;

        [SerializeField] private RectTransform[] startTransforms;
        [SerializeField] private RectTransform[] configTransforms;
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueGameButton;

        private float startXPos;

        private void Awake()
        {
            startXPos = startTransforms[0].position.x;
        }

        public void FadeOutButtons()
        {
            newGameButton.enabled = false;
            continueGameButton.enabled = false;
        }

        public void OpenConfig()
        {
            Sequence sequenceOut = DOTween.Sequence();

            for (int i = 0; i < startTransforms.Length; i++)
            {
                RectTransform rt = startTransforms[i];

                sequenceOut.Insert(
                    i * level0Data.moveDelay,
                    rt.DOMoveX(startXPos + level0Data.moveDistance, level0Data.moveDuration).SetEase(level0Data.moveEase)
                );
            }

            sequenceOut.OnComplete(() =>
            {
                Sequence sequenceIn = DOTween.Sequence();

                for (int i = 0; i < configTransforms.Length; i++)
                {
                    RectTransform rt = configTransforms[i];

                    sequenceIn.Insert(
                        i * level0Data.moveDelay,
                        rt.DOMoveX(startXPos, level0Data.moveDuration).SetEase(level0Data.moveEase)
                    );
                }
            });
        }

        public void CloseConfig()
        {
            Sequence sequenceOut = DOTween.Sequence();

            for (int i = 0; i < configTransforms.Length; i++)
            {
                RectTransform rt = configTransforms[i];

                sequenceOut.Insert(
                    i * level0Data.moveDelay,
                    rt.DOMoveX(startXPos + level0Data.moveDistance, level0Data.moveDuration).SetEase(level0Data.moveEase)
                );
            }

            sequenceOut.OnComplete(() =>
            {
                Sequence sequenceIn = DOTween.Sequence();

                for (int i = 0; i < startTransforms.Length; i++)
                {
                    RectTransform rt = startTransforms[i];

                    sequenceIn.Insert(
                        i * level0Data.moveDelay,
                        rt.DOMoveX(startXPos, level0Data.moveDuration).SetEase(level0Data.moveEase)
                    );
                }
            });
        }
    }
}