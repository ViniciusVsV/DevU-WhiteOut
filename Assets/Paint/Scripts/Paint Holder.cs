using UnityEngine;
using UnityEngine.SceneManagement;

namespace Paint
{
    public class PaintHolder : MonoBehaviour
    {
        private static PaintHolder Instance;
        private string originalSceneName;

        private void Awake()
        {
            originalSceneName = gameObject.scene.name;

            if (Instance != null && Instance.originalSceneName == originalSceneName)
            {
                Destroy(gameObject);
                return;
            }

            if (Instance != null)
                Destroy(Instance.gameObject);

            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != originalSceneName)
                Destroy(gameObject);
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;

            if (Instance == this)
                Instance = null;
        }
    }
}