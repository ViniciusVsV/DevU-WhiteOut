using System;
using DG.Tweening;
using UnityEngine;

namespace Levels.LevelTransitions
{
    public class LevelEnter : MonoBehaviour
    {
        [SerializeField] private LevelTransitionData levelTransitionData;
        [SerializeField] private GameObject canvasObject;

        public static event Action OnLevelEntered;

        private void Awake()
        {
            levelTransitionData.transitionShaderMaterial.SetFloat("_Progress", -1);
        }

        public void EnterLevel()
        {
            canvasObject.SetActive(true);

            levelTransitionData.transitionShaderMaterial.SetTexture("_Transition_Texture", levelTransitionData.enterTexture);

            levelTransitionData.transitionShaderMaterial.DOFloat(1f, "_Progress", levelTransitionData.enterDuration)
                .SetEase(levelTransitionData.enterEase)
                .OnComplete(() =>
                {
                    OnLevelEntered?.Invoke();
                    canvasObject.SetActive(false);
                });
        }

        private void OnDisable()
        {
            levelTransitionData.transitionShaderMaterial.DOKill();
        }
    }
}