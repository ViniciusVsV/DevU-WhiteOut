using System.Linq;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities.Player
{
    public class DeathDetector : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviourData playerBehaviourData;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (playerBehaviourData.hostileTags.Contains(collision.tag))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}