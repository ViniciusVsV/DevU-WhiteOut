using UnityEngine;

namespace MovingPlatform
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class LeverBehaviour : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;
        private BoxCollider2D col;

        private void Awake()
        {
            col = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                col.enabled = false;

                movementController.StartMovement();
            }
        }
    }
}