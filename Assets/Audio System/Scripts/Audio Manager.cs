using UnityEngine;

namespace AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private GameAudioData gameAudioData;

        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        public void PlaySFX(AudioClip sfx)
        {
            sfxSource.PlayOneShot(sfx);
        }
    }
}