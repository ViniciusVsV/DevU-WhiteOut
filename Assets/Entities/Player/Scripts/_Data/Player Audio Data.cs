using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerAudioData", menuName = "Scriptable Objects/PlayerAudioData")]
    public class PlayerAudioData : ScriptableObject
    {
        public AudioClip[] walkSFXs;
        public AudioClip jumpSFX;
        public AudioClip gunshotSFX;
        public AudioClip deathSFX;
        public AudioClip explosionSFX;
    }
}