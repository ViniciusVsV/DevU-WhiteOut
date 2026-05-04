using UnityEngine;

namespace Entities.Player
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform spawnPoint;

        public void SpawnProjectile(Vector2 direction)
        {
            float angle = direction.x == 1 ? 0 : 180;

            Instantiate(projectilePrefab, spawnPoint.position, Quaternion.Euler(0, 0, angle));
        }
    }
}