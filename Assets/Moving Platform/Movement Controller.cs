using DG.Tweening;
using UnityEditor.Rendering;
using UnityEngine;

namespace MovingPlatform
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private MovingPlatformData movingPlatformData;

        [SerializeField] private Transform platformRb;
        [SerializeField] private Transform point1;
        [SerializeField] private Transform point2;

        [Header("Movement Variables")]
        private Transform targetPoint;
        private Transform originPoint;

        private float moveDuration;
        private float elapsedTime;

        private float waitTimer;

        [Header("Booleans")]
        public bool startedMovement;
        public bool isWaiting;
        public bool showGizmos;

        private void Awake()
        {
            platformRb.position = point1.position;

            originPoint = point1;
            targetPoint = point2;

            float moveDistance = (point1.position - point2.position).magnitude;
            moveDuration = moveDistance / movingPlatformData.moveSpeed;
        }

        public void StartMovement()
        {
            startedMovement = true;
        }

        private void FixedUpdate()
        {
            if (!startedMovement)
                return;

            if (isWaiting)
            {
                waitTimer -= Time.fixedDeltaTime;

                if (waitTimer <= Mathf.Epsilon)
                {
                    targetPoint = targetPoint == point1 ? point2 : point1;
                    originPoint = originPoint == point1 ? point2 : point1;

                    elapsedTime = 0f;
                    waitTimer = movingPlatformData.waitDuration;

                    isWaiting = false;
                }

                return;
            }

            elapsedTime += Time.fixedDeltaTime;
            float progress = Mathf.Clamp01(elapsedTime / moveDuration);

            float curveProgress = movingPlatformData.moveCurve.Evaluate(progress);

            platformRb.position = Vector3.Lerp(
                originPoint.position,
                targetPoint.position,
                curveProgress
            );

            if (progress >= 1f)
            {
                waitTimer = movingPlatformData.waitDuration;

                isWaiting = true;
            }
        }

        private void OnDrawGizmos()
        {
            if (!showGizmos)
                return;

            SpriteRenderer sr = platformRb.GetComponent<SpriteRenderer>();

            Vector3 size = sr.bounds.size;

            Gizmos.color = Color.green;

            Gizmos.DrawWireCube(point1.position, size);
            Gizmos.DrawWireCube(point2.position, size);
            Gizmos.DrawLine(point1.position, point2.position);
        }
    }
}