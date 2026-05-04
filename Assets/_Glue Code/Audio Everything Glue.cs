using AudioSystem;
using UnityEngine;

public class AudioEverythingGlue : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnEnable()
    {
        Entities.Player.AudioController.OnSoundPlayed += PlaySFX;
    }
    private void OnDisable()
    {
        Entities.Player.AudioController.OnSoundPlayed -= PlaySFX;
    }

    public void PlaySFX(AudioClip sfx)
    {
        audioManager.PlaySFX(sfx);
    }
}