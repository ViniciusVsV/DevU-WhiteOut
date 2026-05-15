using UnityEngine;

namespace AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private GameAudioData gameAudioData;

        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        public void PlayMenuMusic()
        {
            if (musicSource.clip != gameAudioData.menuMusic)
            {
                musicSource.clip = gameAudioData.menuMusic;
                musicSource.Play();
            }
        }
        public void PlayGameMusic()
        {
            if (musicSource.clip != gameAudioData.gameMusic)
            {
                musicSource.clip = gameAudioData.gameMusic;
                musicSource.Play();
            }
        }
        public void PlayEndingMusic()
        {
            if (musicSource.clip != gameAudioData.endingMusic)
            {
                musicSource.clip = gameAudioData.endingMusic;
                musicSource.Play();
            }
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