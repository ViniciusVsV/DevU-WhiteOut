using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticlePaintHandler : MonoBehaviour
    {
        private ParticleSystem ps;
        private List<ParticleCollisionEvent> collisionEvents = new();
        
        public static event Action<Vector2> OnPaintSpawned;

        private void Awake()
        {
            ps = GetComponent<ParticleSystem>();
        }

        private void OnParticleCollision(GameObject other)
        {
            int numColiisionEvents = ps.GetCollisionEvents(other, collisionEvents);

            for (int i = 0; i < numColiisionEvents; i++)
            {
                Vector2 collisionPoint = collisionEvents[i].intersection;

                OnPaintSpawned?.Invoke(collisionPoint);
            }
        }
    }
}