using DG.Tweening;
using UnityEngine;

namespace Levels.LevelTransitions
{
    public class LevelReEnter : MonoBehaviour
    {
        [SerializeField] private LevelTransitionData levelTransitionData;

        public void ReEnterLevel()
        {
            levelTransitionData.transitionShaderMaterial.SetTexture("_Transition_Texture", levelTransitionData.reRenterTexture);
            levelTransitionData.transitionShaderMaterial.DOFloat(1f, "_Progress", levelTransitionData.reRenterDuration).SetEase(levelTransitionData.reRenterEase);
        }

        private void OnDisable()
        {
            levelTransitionData.transitionShaderMaterial.DOKill();
        }
    }
}