using UnityEngine;

namespace AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        public void PlayMusic()
        {
            musicSource.Play();
        }
        public void StopMusic()
        {
            musicSource.Stop();
        }

        public void PlaySFX(AudioClip sfx)
        {
            sfxSource.PlayOneShot(sfx);
        }
    }
}