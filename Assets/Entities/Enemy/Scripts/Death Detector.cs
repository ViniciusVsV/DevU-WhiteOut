using UnityEngine;

namespace Entities.Enemy
{
    public class DeathDetector : MonoBehaviour
    {
        [SerializeField] private BehaviourController behaviourController;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerWeapon"))
            {
                behaviourController.canMove = false;

                Destroy(gameObject);
            }
        }
    }
}