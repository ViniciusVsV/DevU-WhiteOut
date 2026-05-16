using System;
using System.Collections;
using MenuSystem.Sections;
using UnityEngine;

namespace MenuSystem
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private MenuData menuData;
        [SerializeField] private PauseSection pauseSection;
        private Canvas pauseCanvas;

        private AudioLowPassFilter audioLowPassFilter;
        private Camera mainCamera;

        private bool isPaused;

        public static event Action OnMenuReturned;

        private void Start()
        {
            audioLowPassFilter = GameObject.FindWithTag("MusicSource").GetComponent<AudioLowPassFilter>();

            pauseCanvas = GetComponent<Canvas>();
            StartCoroutine(SearchMainCam());
        }

        private IEnumerator SearchMainCam()
        {
            while (mainCamera == null)
            {
                mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
                yield return null;
            }

            pauseCanvas.worldCamera = mainCamera;
        }

        public void PauseGame()
        {
            if (isPaused)
            {
                pauseSection.Deactivate();
                audioLowPassFilter.cutoffFrequency = menuData.normalMuffle;

                Time.timeScale = 1f;

                isPaused = false;

                return;
            }

            isPaused = true;

            Time.timeScale = 0;
            pauseSection.Activate();
            audioLowPassFilter.cutoffFrequency = menuData.pausedMuffle;
        }

        public void ReturnToMenu()
        {
            OnMenuReturned?.Invoke();
        }
    }
}