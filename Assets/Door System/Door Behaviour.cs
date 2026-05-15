using System;
using UnityEngine;

namespace DoorSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class DoorBehaviour : MonoBehaviour
    {
        [SerializeField] private KeyBehaviour key;
        private Collider2D col;

        public static event Action OnDoorEntered;

        private void Awake()
        {
            col = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (key.hasBeenCollected)
                {
                    col.enabled = false;

                    OnDoorEntered?.Invoke();
                }
            }
        }
    }
}