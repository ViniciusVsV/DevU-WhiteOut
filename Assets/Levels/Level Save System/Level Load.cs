using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels.LevelSaveSystem
{
    public class LevelLoad : MonoBehaviour
    {
        public void LoadLevel()
        {
            string levelName = PlayerPrefs.GetString("SavedLevel", "Level 1");

            SceneManager.LoadScene(levelName);
        }
    }
}