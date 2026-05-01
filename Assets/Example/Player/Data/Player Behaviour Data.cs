using UnityEngine;

namespace Player
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

        [Header("Dash")]
        public float dashSpeed;
        public float dashDuration;
        public float dashCooldown;
    }
}