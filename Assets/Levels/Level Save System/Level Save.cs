using UnityEngine;

namespace Levels.LevelSaveSystem
{
    public class LevelSave : MonoBehaviour
    {
        public void SaveLevel(string levelName)
        {
            PlayerPrefs.SetString("SavedLevel", levelName);
            PlayerPrefs.Save();
        }
    }
}