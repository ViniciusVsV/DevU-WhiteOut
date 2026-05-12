using DG.Tweening;
using Levels.LevelSaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Levels.Level0
{
    public class Transitions : MonoBehaviour
    {
        [SerializeField] private Level0Data level0Data;
        [SerializeField] private Image blackScreen;
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private Material transitionMaterial;
        [SerializeField] private LevelManager levelManager;

        private void Awake()
        {
            blackScreen.gameObject.SetActive(true);
            blackScreen.DOFade(1, 0);

            musicSource.volume = 0;

            FadeIn();
        }

        public void FadeIn()
        {
            PlayerPrefs.SetString("LastSceneName", SceneManager.GetActiveScene().name);

            Sequence sequence = DOTween.Sequence();

            sequence.Append(blackScreen.DOFade(0, level0Data.fadeInDuration).SetEase(level0Data.fadeInEase)
                .OnComplete(() =>
                {
                    blackScreen.gameObject.SetActive(false);
                })
            );

            sequence.Join(musicSource.DOFade(1, level0Data.musicFadeInDuration));
        }

        public void FadeOut(string sceneName)
        {
            blackScreen.gameObject.SetActive(true);

            blackScreen.DOFade(1, level0Data.fadeOutDuration).SetEase(level0Data.fadeOutEase)
                .OnComplete(() =>
                {
                    transitionMaterial.SetFloat("_Progress", 1f);

                    if (sceneName == "load")
                        levelManager.LoadLevel();
                    else
                        SceneManager.LoadScene(sceneName);
                });
        }
    }
}