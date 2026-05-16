using UnityEngine;

namespace GunEnabler
{
    public class PersistenceHandler : MonoBehaviour
    {
        private void Awake()
        {
            if (PlayerPrefs.HasKey("GunCollected"))
                Destroy(gameObject);
        }
    }
}