using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels.LevelSaveSystem
{
    public class LevelLoad : MonoBehaviour
    {
        public void LoadLevel()
        {
            string levelName = PlayerPrefs.GetString("SavedLevel");

            SceneManager.LoadScene(levelName);
        }
    }
}