using System;
using UnityEngine;

namespace GunEnabler
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnableGun : MonoBehaviour
    {
        [SerializeField] private AudioClip collectedSFX;
        private BoxCollider2D col;


        public static event Action<AudioClip> OnSoundPlayed;
        public static event Action OnGunEnabled;

        private void Awake()
        {
            col = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                col.enabled = false;

                OnSoundPlayed?.Invoke(collectedSFX);

                PlayerPrefs.SetInt("GunCollected", 1);
                PlayerPrefs.Save();

                OnGunEnabled?.Invoke();

                Destroy(gameObject);
            }
        }
    }
}