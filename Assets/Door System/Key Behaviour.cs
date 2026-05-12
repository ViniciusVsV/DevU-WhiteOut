using UnityEngine;

namespace DoorSystem
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class KeyBehaviour : MonoBehaviour
    {
        private CircleCollider2D col;
        private SpriteRenderer sr;

        public bool hasBeenCollected;

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