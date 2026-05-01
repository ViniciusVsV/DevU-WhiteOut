using UnityEngine;

namespace DoorSystem
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class KeyBehaviour : MonoBehaviour
    {
        public bool hasBeenCollected;

        private CircleCollider2D col;
        private SpriteRenderer sr;

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

                hasBeenCollected = true;
            }
        }
    }
}