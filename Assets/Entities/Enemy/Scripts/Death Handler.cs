using System.Collections;
using UnityEngine;

namespace Entities.Enemy
{
    public class DeathHandler : MonoBehaviour, IKillable
    {
        [SerializeField] private BehaviourController behaviourController;
        [SerializeField] private EffectsController effectsController;
        [SerializeField] private GameObject enemyObject;

        public void Die(Vector3 deathOrigin)
        {
            behaviourController.canMove = false;

            Vector2 colDirection = deathOrigin.x < transform.position.x ? Vector2.right : Vector2.left;

            effectsController.PlayDeathEffects(colDirection);

            StartCoroutine(Routine());
        }
        
        private IEnumerator Routine()
        {
            yield return new WaitUntil(() => effectsController.deathEffectsFinished);

            Destroy(enemyObject);
        }
    }
}