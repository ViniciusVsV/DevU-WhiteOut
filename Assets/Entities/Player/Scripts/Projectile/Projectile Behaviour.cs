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

            Destroy(gameObject, 10);
        }

        private void FixedUpdate()
        {
            if (hasCollided)
                return;



            rb.linearVelocity = transform.up * playerProjectileData.speed;

            Vector2 direction = transform.up;
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

                trailParticles.transform.SetParent(null);
                trailParticles.transform.localScale = Vector3.one;

                movementParticles.transform.SetParent(null);
                movementParticles.transform.localScale = Vector3.one;

                hitParticles.transform.SetParent(null);
                hitParticles.transform.localScale = Vector3.one;

                if (hit.collider.gameObject.TryGetComponent<IKillable>(out var killable))
                    killable.Die(transform.position);

                Destroy(gameObject);
            }
        }
    }
}