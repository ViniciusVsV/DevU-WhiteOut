using UnityEngine;

namespace MovingPlatform
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] private Transform platformTr;
        Transform playerParent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("PLAYER ENTROU NO TRIGGER!");

                playerParent = collision.transform.parent;
                collision.transform.SetParent(platformTr);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("PLAYER SAIU DO TRIGGER!");

                collision.transform.SetParent(playerParent);
            }
        }
    }
}