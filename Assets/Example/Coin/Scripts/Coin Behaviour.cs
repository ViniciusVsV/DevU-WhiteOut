using System;
using UnityEngine;

namespace Coin
{
    [RequireComponent(typeof(Collider2D))]
    public class CoinBehaviour : MonoBehaviour
    {
        [SerializeField] private CoinData coinData;
        [SerializeField] private CollectionMovement collectionMovement;

        public static event Action<int> CoinCollectedEvent;

        private Collider2D col;

        private void Awake()
        {
            col = GetComponent<Collider2D>();

            //Limpa a lista de eventos inscritos para evitar problemas ao recarregar a cena
            CoinCollectedEvent = null;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                col.enabled = false;

                CoinCollectedEvent?.Invoke(coinData.scoreValue);

                collectionMovement.ApplyEffect(transform);
            }
        }
    }
}