using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels.LevelTransitions
{
    public class LevelFail : MonoBehaviour
    {
        [SerializeField] private LevelTransitionData levelTransitionData;
        [SerializeField] private GameObject canvasObject;

        public void FailLevel()
        {
            canvasObject.SetActive(true);

            levelTransitionData.transitionShaderMaterial.SetTexture("_Transition_Texture", levelTransitionData.failTexture);

            levelTransitionData.transitionShaderMaterial.DOFloat(-1f, "_Progress", levelTransitionData.failDuration)
            .SetEase(levelTransitionData.failEase)
            .SetDelay(levelTransitionData.failStartDelay)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }

        private void OnDisable()
        {
            levelTransitionData.transitionShaderMaterial.DOKill();
        }
    }
}