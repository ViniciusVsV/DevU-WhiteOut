using UnityEngine;

namespace Paint
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PaintBehaviour : MonoBehaviour
    {
        [SerializeField] private PaintData paintData;
        private SpriteRenderer sr;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();

            int numSprites = paintData.paintSprites.Length;
            sr.sprite = paintData.paintSprites[Random.Range(0, numSprites)];
        }
    }
}