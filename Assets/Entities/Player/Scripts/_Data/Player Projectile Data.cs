using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "PlayerProjectileData", menuName = "Scriptable Objects/PlayerProjectileData")]
    public class PlayerProjectileData : ScriptableObject
    {
        public float speed;
    }
}