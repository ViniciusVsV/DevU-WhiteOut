using UnityEngine;

namespace Entities.Enemy.Effects
{
    public class DeathParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem ps;
        [SerializeField] private Transform enemyTr;
        [SerializeField] private Transform deathParticlesPoint;

        public void ApplyEffect(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            ps.transform.SetPositionAndRotation(deathParticlesPoint.position, Quaternion.Euler(0, 0, angle));
            ps.transform.SetParent(null);

            ps.Play();
        }
    }
}