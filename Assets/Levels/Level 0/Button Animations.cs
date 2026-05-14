using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
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
        [SerializeField] private Button openConfigButton;
        [SerializeField] private Button closeConfigButton;

        private float startXPos;

        private void Awake()
        {
            startXPos = startTransforms[0].position.x;

            EventSystem.current.SetSelectedGameObject(newGameButton.gameObject);
        }

        public void FadeOutButtons(bool allButtons)
        {
            newGameButton.interactable = false;
            continueGameButton.interactable = false;

            Navigation nav;
            nav = openConfigButton.navigation;
            nav.mode = Navigation.Mode.None;
            openConfigButton.navigation = nav;

            if (allButtons)
            {
                openConfigButton.interactable = false;
                openConfigButton.image.DOFade(0, level0Data.buttonFadeOutDuration).SetEase(level0Data.buttonFadeOutEase);
            }

            newGameButton.image.DOFade(0, level0Data.buttonFadeOutDuration).SetEase(level0Data.buttonFadeOutEase);
            continueGameButton.image.DOFade(0, level0Data.buttonFadeOutDuration).SetEase(level0Data.buttonFadeOutEase);

            EventSystem.current.SetSelectedGameObject(openConfigButton.gameObject);
        }

        public void OpenConfig()
        {
            EventSystem.current.SetSelectedGameObject(null);

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

                sequenceIn.OnComplete(() =>
                {
                    EventSystem.current.SetSelectedGameObject(closeConfigButton.gameObject);
                });
            });
        }

        public void CloseConfig()
        {
            EventSystem.current.SetSelectedGameObject(null);

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

                sequenceIn.OnComplete(() =>
                {
                    if (newGameButton.interactable)
                        EventSystem.current.SetSelectedGameObject(newGameButton.gameObject);
                    else
                        EventSystem.current.SetSelectedGameObject(openConfigButton.gameObject);
                });
            });
        }
    }
}