using Unity.Cinemachine;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CinemachineImpulseSource))]
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;

        private CinemachineImpulseSource cinemachineImpulseSource;

        private void Awake()
        {
            cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        }

        public void ApplyEffect()
        {
            cinemachineImpulseSource.GenerateImpulse(playerEffectsData.cameraShakeStrength);
        }
    }
}