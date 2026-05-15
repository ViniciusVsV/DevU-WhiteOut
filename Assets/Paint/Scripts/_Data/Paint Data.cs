using UnityEngine;

namespace Paint
{
    [CreateAssetMenu(fileName = "PaintData", menuName = "Scriptable Objects/PaintData")]
    public class PaintData : ScriptableObject
    {
        [Header("Technical")]
        public GameObject paintPrefab;
        public string paintHolderTag;

        [Header("Sprites")]
        public Sprite[] paintSprites;

        [Header("Paint Check")]
        public LayerMask paintLayer;
        public float paintCheckRadius;
    }
}