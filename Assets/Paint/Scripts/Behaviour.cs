using Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Paint
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Behaviour : MonoBehaviour
    {
        [SerializeField] private PaintData paintData;
        private SpriteRenderer sr;

        private Transform paintHolder;
        private string originalSceneName;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();

            int numSprites = paintData.paintSprites.Length;
            sr.sprite = paintData.paintSprites[Random.Range(0, numSprites)];

            paintHolder = transform.parent;

            originalSceneName = SceneManager.GetActiveScene().name;
            DontDestroyOnLoad(paintHolder.gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != originalSceneName)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                Destroy(paintHolder.gameObject);
            }
        }
    }
}