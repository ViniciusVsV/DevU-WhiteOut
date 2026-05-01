using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerAudioData", menuName = "Scriptable Objects/PlayerAudioData")]
    public class PlayerAudioData : ScriptableObject
    {
        public AudioClip[] walkSFXs;
        public AudioClip jumpSFX;
        public AudioClip attackSFX;
    }
}