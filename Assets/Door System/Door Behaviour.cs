using UnityEngine;

namespace DoorSystem
{
    public class DoorBehaviour : MonoBehaviour
    {
        [SerializeField] private KeyBehaviour key;
        [SerializeField] private Collider2D doorCollider;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (key.hasBeenCollected)
                    doorCollider.enabled = false;
            }
        }
    }
}