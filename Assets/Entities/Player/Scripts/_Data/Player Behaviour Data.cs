using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerBehaviourData", menuName = "Scriptable Objects/PlayerBehaviourData")]
    public class PlayerBehaviourData : ScriptableObject
    {
        [Header("Movement")]
        public float moveSpeed;

        [Header("Gravity")]
        public float baseGravity;
        public float fallGravity;

        [Header("Jump")]
        public float jumpForce;
        [Range(0, 1)] public float jumpCutMultiplier;
        public int extraJumps;
        public float coyoteTime;
        public float jumpBuffer;

        [Header("Attack")]
        public float attackDelay;

        [Header("Death")]
        public string[] hostileTags;
    }
}