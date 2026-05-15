using UnityEngine;

namespace CameraSystem
{
    [RequireComponent(typeof(Camera))]
    public class AspectRatioHandler : MonoBehaviour
    {
        [SerializeField] private Vector2 defaultAspectRatio = new Vector2(16f, 9f);
        [SerializeField] private Color barColor;

        private Camera mainCamera;
        [SerializeField] private Camera barCamera;

        private void Awake()
        {
            mainCamera = GetComponent<Camera>();

            barCamera.backgroundColor = barColor;
        }

        private void Update()
        {
            float targetAspect = defaultAspectRatio.x / defaultAspectRatio.y;

            float windowAspect = (float)Screen.width / Screen.height;
            float scaleHeight = windowAspect / targetAspect;

            Rect rect = new();

            if (scaleHeight < 1.0f)
            {
                rect.width = 1.0f;
                rect.height = scaleHeight;
                rect.x = 0;
                rect.y = (1.0f - scaleHeight) / 2.0f;
            }
            else
            {
                float scaleWidth = 1.0f / scaleHeight;

                rect.width = scaleWidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scaleWidth) / 2.0f;
                rect.y = 0;
            }

            mainCamera.rect = rect;
        }
    }
}