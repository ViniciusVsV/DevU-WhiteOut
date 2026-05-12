using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels.LevelTransitions
{
    public class TransitionManager : MonoBehaviour
    {
        [SerializeField] private LevelEnter levelEnter;
        [SerializeField] private LevelReEnter levelReEnter;
        [SerializeField] private LevelFail levelFail;
        [SerializeField] private LevelExit levelExit;
        [SerializeField] private Canvas canvas;

        private void Awake()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            string lastSceneName = PlayerPrefs.GetString("LastSceneName", null);

            if (currentSceneName != lastSceneName)
            {
                PlayerPrefs.SetString("LastSceneName", currentSceneName);
                PlayerPrefs.Save();

                levelEnter.EnterLevel();
            }
            else
                levelReEnter.ReEnterLevel();
        }

        private void Start()
        {
            Camera mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            canvas.worldCamera = mainCamera;
        }

        public void FailLevel()
        {
            levelFail.FailLevel();
        }

        public void ExitLevel()
        {
            levelExit.ExitLevel();
        }
    }
}