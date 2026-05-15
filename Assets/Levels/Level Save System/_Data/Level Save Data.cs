using UnityEngine;

namespace Levels.LevelSaveSystem
{
    [CreateAssetMenu(fileName = "LevelSaveData", menuName = "Scriptable Objects/LevelSaveData")]
    public class LevelSaveData : ScriptableObject
    {
        public string[] ignoredScenes;
    }
}