using System;
using UnityEngine;

namespace DoorSystem
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class KeyBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioClip collectSFX;
        private CircleCollider2D col;
        private SpriteRenderer sr;

        public bool hasBeenCollected;

        public static event Action<AudioClip> OnSoundPlayed;

        private void Awake()
        {
            col = GetComponent<CircleCollider2D>();
            sr = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                col.enabled = false;
                sr.enabled = false;

                OnSoundPlayed?.Invoke(collectSFX);

                hasBeenCollected = true;
            }
        }
    }
}