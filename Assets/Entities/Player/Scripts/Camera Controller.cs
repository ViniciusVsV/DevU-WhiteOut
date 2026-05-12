using System;
using System.Collections;
using System.Linq;
using Unity.Cinemachine;
using UnityEngine;

namespace Entities.Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineConfiner2D playerCameraConfiner;
        private PolygonCollider2D cameraConfiner;

        private void Start()
        {
            cameraConfiner = GameObject.FindWithTag("CameraConfiner").GetComponent<PolygonCollider2D>();

            playerCameraConfiner.BoundingShape2D = cameraConfiner;

            playerCameraConfiner.InvalidateBoundingShapeCache();
        }
    }
}