using System;
using UnityEngine;

namespace Entities
{
    public class EntityPaintHandler : MonoBehaviour
    {
        [SerializeField] private Transform[] paintPoints;

        [Header("Ground Check")]
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float groundCheckRadius;

        public static event Action<Vector2> OnPaintSpawned;

        private void Update()
        {
            //Percorre cada ponto que pinta
            foreach (Transform point in paintPoints)
            {
                //Verifica se o ponto atual está em contato com o chão
                if (Physics2D.OverlapCircle(point.position, groundCheckRadius, groundLayer))
                    OnPaintSpawned?.Invoke(point.position);
            }
        }
    }
}