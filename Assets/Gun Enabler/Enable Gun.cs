using System;
using UnityEngine;

namespace GunEnabler
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class EnableGun : MonoBehaviour
    {
        private BoxCollider2D col;

        public static event Action OnGunEnabled;

        private void Awake()
        {
            col = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                col.enabled = false;

                PlayerPrefs.SetInt("GunCollected", 1);
                PlayerPrefs.Save();

                OnGunEnabled?.Invoke();

                Destroy(gameObject);
            }
        }
    }
}