using UnityEngine;

namespace Entities.Player
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform spawnPoint;

        public (Transform, SpriteRenderer) SpawnProjectile(Vector2 direction)
        {
            float angle = direction.x == 1 ? -90 : 90;

            GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.Euler(0, 0, angle));

            SpriteRenderer projectileSr = newProjectile.GetComponentInChildren<SpriteRenderer>();

            return (newProjectile.transform, projectileSr);
        }
    }
}