using DG.Tweening;
using UnityEngine;

namespace Entities.Player.Effects
{
    public class DeathPartialTransition : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;
        [SerializeField] private Material transitionShaderMaterial;

        public bool finished;

        public void ApplyEffect()
        {
            finished = false;

            transitionShaderMaterial.SetTexture("_Transition_Texture", playerEffectsData.partialTransitionTexture);

            transitionShaderMaterial.DOFloat(playerEffectsData.partialTransitionProgress, "_Progress", playerEffectsData.partialTransitionDuration)
            .SetEase(playerEffectsData.partialTransitionEase)
            .OnComplete(() =>
            {
                finished = true;
            });
        }
    }
}