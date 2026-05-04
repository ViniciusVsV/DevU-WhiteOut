using UnityEngine;

namespace Entities.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField] PlayerProjectileData playerProjectileData;

        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private ParticleSystem trailParticles;
        [SerializeField] private ParticleSystem movementParticles;
        [SerializeField] private ParticleSystem hitParticles;
        [SerializeField] private LayerMask collisionLayers;
        private Rigidbody2D rb;

        private bool hasCollided;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (hasCollided)
                return;

            rb.linearVelocity = transform.right * playerProjectileData.speed;

            Vector2 direction = transform.right;
            float distance = playerProjectileData.speed * Time.fixedDeltaTime;

            RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, distance, collisionLayers);

            if (hit.collider != null)
            {
                hasCollided = true;

                transform.position = hit.point;

                sr.enabled = false;
                rb.simulated = false;

                trailParticles.Stop();
                movementParticles.Stop();

                hitParticles.transform.position = hit.point;
                hitParticles.Play();

                if (hit.collider.gameObject.TryGetComponent<IKillable>(out var killable))
                    killable.Die(transform.position);

                Destroy(gameObject, 3);
            }
        }
    }
}