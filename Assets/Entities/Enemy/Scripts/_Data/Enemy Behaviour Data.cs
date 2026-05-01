using UnityEngine;

namespace Entities.Enemy
{
    [CreateAssetMenu(fileName = "EnemyBehaviourData", menuName = "Scriptable Objects/EnemyBehaviourData")]
    public class EnemyBehaviourData : ScriptableObject
    {
        [Header("Movement")]
        public float moveSpeed;

        [Header("Flip")]
        public string borderTag;
        public float minWaitDuration;
        public float maxWaitDuration;
    }
}