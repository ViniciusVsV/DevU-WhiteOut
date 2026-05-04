using UnityEngine;

namespace Entities
{
    public interface IKillable
    {
        public void Die(Vector3 direction);
    }
}