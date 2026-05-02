using Unity.Cinemachine;
using UnityEngine;

namespace Entities.Player.Effects
{
    [RequireComponent(typeof(CinemachineImpulseSource))]
    public class GunshotCameraRecoil : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;

        private CinemachineImpulseSource cinemachineImpulseSource;

        private void Awake()
        {
            cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        }

        public void ApplyEffect(int recoilDirection)
        {
            cinemachineImpulseSource.GenerateImpulse(new Vector3(recoilDirection, 0, 0) * playerEffectsData.cameraRecoilStrength);
        }
    }
}