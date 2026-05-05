using UnityEngine;

namespace AudioSystem
{
    public class PersistenceHandler : MonoBehaviour
    {
        public static PersistenceHandler Instance;

        public AudioManager audioManager;
        public MixerController mixerController;

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