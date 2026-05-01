using System.Linq;
using UnityEngine;

namespace Player
{
    public class DeathHandler : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviourData playerBehaviourData;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (playerBehaviourData.hostileTags.Contains(collision.tag))
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}