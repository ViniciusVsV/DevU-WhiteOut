using System;
using UnityEngine;

namespace Entities.Enemy
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip deathSFX;

        public static event Action<AudioClip> OnSoundPlayed;

        public void PlayDeathSFX()
        {
            OnSoundPlayed?.Invoke(deathSFX);
        }
    }
}