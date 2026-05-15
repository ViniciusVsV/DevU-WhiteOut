using UnityEngine;

namespace CameraSystem
{
    public class PersistenceHandler : MonoBehaviour
    {
        public static PersistenceHandler Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }
    }
}