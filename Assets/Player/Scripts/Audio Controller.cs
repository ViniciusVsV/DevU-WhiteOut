using System;
using UnityEngine;

namespace Player
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private PlayerAudioData playerAudioData;

        public static event Action<AudioClip> OnSoundPlayed;

        public void PlayWalkSFX()
        {
            AudioClip[] sfxs = playerAudioData.walkSFXs;

            OnSoundPlayed?.Invoke(sfxs[UnityEngine.Random.Range(0, sfxs.Length)]);
        }
        public void PlayJumpSFX()
        {
            OnSoundPlayed?.Invoke(playerAudioData.jumpSFX);
        }
        public void PlayAttackSFX()
        {
            OnSoundPlayed?.Invoke(playerAudioData.attackSFX);
        }
    }
}