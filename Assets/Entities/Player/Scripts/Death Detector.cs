using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Entities.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class DeathDetector : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviourData playerBehaviourData;

        [Header("Player Scripts")]
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private EffectsController effectsController;
        private Collider2D col;

        public static event Action OnPlayerDeathDetected;
        public static event Action OnPlayerDeath;

        private void Awake()
        {
            col = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (playerBehaviourData.hostileTags.Contains(collision.tag))
            {
                col.enabled = false;

                OnPlayerDeathDetected?.Invoke();

                inputHandler.DisableInputs();

                Vector3 closestPoint = collision.ClosestPoint(transform.position);
                Vector3 colDirection = (closestPoint - transform.position).normalized;

                effectsController.PlayDeathEffects(colDirection);

                StartCoroutine(Routine());
            }
        }

        private IEnumerator Routine()
        {
            yield return new WaitUntil(() => effectsController.deathEffectsFinished);

            OnPlayerDeath?.Invoke();
        }
    }
}