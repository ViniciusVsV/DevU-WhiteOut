using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels.LevelSaveSystem
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        [SerializeField] private LevelSaveData levelSaveData;

        [SerializeField] private LevelSave levelSave;
        [SerializeField] private LevelLoad levelLoad;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += SaveLevel;
        }
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= SaveLevel;
        }

        public void SaveLevel(Scene scene, LoadSceneMode mode)
        {
            if (levelSaveData.ignoredScenes.Contains(scene.name))
                return;

            Debug.Log("Salvou a cena: " + scene.name);

            levelSave.SaveLevel(scene.name);
        }

        public void LoadLevel()
        {
            levelLoad.LoadLevel();
        }
    }
}