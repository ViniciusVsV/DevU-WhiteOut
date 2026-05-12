using System;
using DG.Tweening;
using UnityEngine;

namespace Levels.LevelTransitions
{
    public class LevelReEnter : MonoBehaviour
    {
        [SerializeField] private LevelTransitionData levelTransitionData;
        [SerializeField] private GameObject canvasObject;

        public static event Action OnLevelReEntered;

        public void ReEnterLevel()
        {
            canvasObject.SetActive(true);

            levelTransitionData.transitionShaderMaterial.SetTexture("_Transition_Texture", levelTransitionData.reRenterTexture);
            levelTransitionData.transitionShaderMaterial.DOFloat(1f, "_Progress", levelTransitionData.reRenterDuration)
                .SetEase(levelTransitionData.reRenterEase)
                .OnComplete(() =>
                {
                    OnLevelReEntered?.Invoke();
                    canvasObject.SetActive(false);
                });
        }

        private void OnDisable()
        {
            levelTransitionData.transitionShaderMaterial.DOKill();
        }
    }
}