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
                string currentSceneName = SceneManager.GetActiveScene().name;

                int currentIndex = System.Array.IndexOf(levelTransitionData.sceneNames, currentSceneName);

                if (currentIndex >= 0 && currentIndex < levelTransitionData.sceneNames.Length - 1)
                {
                    string nextSceneName = levelTransitionData.sceneNames[currentIndex + 1];

                    SceneManager.LoadScene(nextSceneName);
                }
                else
                    Debug.Log("Erro ao carregar a próxima cena");
            });
        }

        private void OnDisable()
        {
            levelTransitionData.transitionShaderMaterial.DOKill();
        }
    }
}