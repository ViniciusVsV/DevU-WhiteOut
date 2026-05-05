using UnityEngine;

namespace AudioSystem
{
    [CreateAssetMenu(fileName = "GameAudioData", menuName = "Scriptable Objects/GameAudioData")]
    public class GameAudioData : ScriptableObject
    {
        [Header("Music")]
        public AudioClip menuMusic;
        public AudioClip gameMusic;
        public AudioClip endingMusic;
    }
}