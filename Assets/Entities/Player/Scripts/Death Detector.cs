using System;
using System.Linq;
using UnityEngine;

namespace Entities.Player
{
    public class DeathDetector : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviourData playerBehaviourData;
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private EffectsController effectsController;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (playerBehaviourData.hostileTags.Contains(collision.tag))
            {
                inputHandler.inputsDisabled = true;

                Vector3 closestPoint = collision.ClosestPoint(transform.position);
                Vector3 colDirection = (closestPoint - transform.position).normalized;

                StartCoroutine(effectsController.PlayDeathEffects(colDirection));
            }
        }
    }
}