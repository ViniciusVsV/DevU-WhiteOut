using System;
using UnityEngine;

namespace DoorSystem
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Animator))]
    public class DoorBehaviour : MonoBehaviour
    {
        [SerializeField] private KeyBehaviour key;
        [SerializeField] private AudioClip openSFX;
        private Animator animator;
        private Collider2D col;

        public static event Action OnDoorEntered;
        public static event Action<AudioClip> OnSoundPlayed;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            col = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (key.hasBeenCollected)
                {
                    col.enabled = false;

                    animator.SetTrigger("hasOpened");
                    OnSoundPlayed?.Invoke(openSFX);

                    OnDoorEntered?.Invoke();
                }
            }
        }
    }
}