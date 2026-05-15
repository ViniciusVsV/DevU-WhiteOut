using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Paint
{
    public class PaintHolder : MonoBehaviour
    {
        private string originalSceneName;

        private void Awake()
        {
            originalSceneName = SceneManager.GetActiveScene().name;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name != originalSceneName)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                Destroy(gameObject);
            }
        }
    }
}