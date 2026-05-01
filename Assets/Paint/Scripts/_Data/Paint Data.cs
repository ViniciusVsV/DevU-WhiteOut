using UnityEngine;

namespace Paint
{
    [CreateAssetMenu(fileName = "PaintData", menuName = "Scriptable Objects/PaintData")]
    public class PaintData : ScriptableObject
    {
        [Header("Technical")]
        public GameObject paintPrefab;
        public LayerMask paintLayer;
        public string paintHolderTag;

        [Header("Sprites")]
        public Sprite[] paintSprites;

        [Header("Checks")]
        public float paintCheckRadius;
    }
}