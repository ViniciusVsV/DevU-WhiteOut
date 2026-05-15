using System;
using UnityEngine;

namespace MovingPlatform
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class LeverBehaviour : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private Sprite activatedSprite;
        [SerializeField] private AudioClip activateSFX;

        private SpriteRenderer sr;
        private BoxCollider2D col;

        public static event Action<AudioClip> OnSoundPlayed;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            col = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                col.enabled = false;

                sr.sprite = activatedSprite;
                OnSoundPlayed?.Invoke(activateSFX);

                movementController.StartMovement();
            }
        }
    }
}