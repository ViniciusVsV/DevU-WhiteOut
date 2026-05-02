using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels.LevelTransitions
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LevelExit : MonoBehaviour
    {
        [SerializeField] private LevelTransitionData levelTransitionData;
        private BoxCollider2D boxCollider2D;

        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                boxCollider2D.enabled = false;

                ExitLevel();
            }
        }

        private void ExitLevel()
        {
            levelTransitionData.transitionShaderMaterial.SetTexture("_Transition_Texture", levelTransitionData.exitTexture);

            levelTransitionData.transitionShaderMaterial.DOFloat(-1f, "_Progress", levelTransitionData.exitDuration).SetEase(levelTransitionData.exitEase).OnComplete(() =>
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