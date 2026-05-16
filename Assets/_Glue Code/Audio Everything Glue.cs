using AudioSystem;
using UnityEngine;

public class AudioEverythingGlue : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = PersistenceHandler.Instance.audioManager;
    }

    private void OnEnable()
    {
        Entities.Player.AudioController.OnSoundPlayed += PlaySFX;
        Entities.Player.AudioController.OnSoundPlayed += PlaySFX;
        DoorSystem.DoorBehaviour.OnSoundPlayed += PlaySFX;
        DoorSystem.KeyBehaviour.OnSoundPlayed += PlaySFX;
        MovingPlatform.LeverBehaviour.OnSoundPlayed += PlaySFX;
        GunEnabler.EnableGun.OnSoundPlayed += PlaySFX;
    }
    private void OnDisable()
    {
        Entities.Player.AudioController.OnSoundPlayed -= PlaySFX;
        Entities.Player.AudioController.OnSoundPlayed -= PlaySFX;
        DoorSystem.DoorBehaviour.OnSoundPlayed -= PlaySFX;
        DoorSystem.KeyBehaviour.OnSoundPlayed -= PlaySFX;
        MovingPlatform.LeverBehaviour.OnSoundPlayed -= PlaySFX;
        GunEnabler.EnableGun.OnSoundPlayed -= PlaySFX;
    }

    public void PlaySFX(AudioClip sfx)
    {
        audioManager.PlaySFX(sfx);
    }
}