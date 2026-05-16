using System.Collections;
using UnityEngine;

namespace Paint
{
    public class PaintSpawner : MonoBehaviour
    {
        [SerializeField] private PaintData paintData;
        private Transform paintHolder;

        private void Start()
        {
            StartCoroutine(SearchPaintHolder());
        }

        private IEnumerator SearchPaintHolder()
        {
            while (paintHolder == null)
            {
                paintHolder = GameObject.FindWithTag(paintData.paintHolderTag).transform;
                yield return null;
            }
        }

        public void SpawnPaint(Vector2 position)
        {
            //Verifica se já tem uma tinta na posição
            if (!Physics2D.OverlapCircle(position, paintData.paintCheckRadius, paintData.paintLayer))
            {
                Quaternion randomAngle = Quaternion.Euler(0f, 0f, Random.Range(0f, 180f));

                Instantiate(paintData.paintPrefab, position, randomAngle, paintHolder);
            }
        }
    }
}