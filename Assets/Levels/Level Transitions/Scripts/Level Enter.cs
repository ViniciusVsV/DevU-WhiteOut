using DG.Tweening;
using UnityEngine;

namespace Levels.LevelTransitions
{
    public class LevelEnter : MonoBehaviour
    {
        [SerializeField] private LevelTransitionData levelTransitionData;

        private void Awake()
        {
            levelTransitionData.transitionShaderMaterial.SetFloat("_Progress", -1);
        }

        public void EnterLevel()
        {
            levelTransitionData.transitionShaderMaterial.SetTexture("_Transition_Texture", levelTransitionData.enterTexture);
            levelTransitionData.transitionShaderMaterial.DOFloat(1f, "_Progress", levelTransitionData.enterDuration).SetEase(levelTransitionData.enterEase);
        }

        private void OnDisable()
        {
            levelTransitionData.transitionShaderMaterial.DOKill();
        }
    }
}