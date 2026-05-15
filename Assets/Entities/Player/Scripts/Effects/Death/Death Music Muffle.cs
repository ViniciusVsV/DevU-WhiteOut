using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities.Player.Effects
{
    public class DeathMusicMuffle : MonoBehaviour
    {
        [SerializeField] private PlayerEffectsData playerEffectsData;

        private AudioLowPassFilter audioLowPassFilter;

        private void Start()
        {
            audioLowPassFilter = GameObject.FindWithTag("MusicSource").GetComponent<AudioLowPassFilter>();
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += RemoveEffect;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= RemoveEffect;
        }

        public void ApplyEffect()
        {
            if (audioLowPassFilter == null)
                return;

            DOTween.To(
                () => audioLowPassFilter.cutoffFrequency,
                x => audioLowPassFilter.cutoffFrequency = x,
                playerEffectsData.muffledCutoff,
                playerEffectsData.muffleDuration
            ).SetEase(playerEffectsData.muffleEase)
            .SetUpdate(true);
        }

        private void RemoveEffect(Scene arg0, LoadSceneMode arg1)
        {
            StartCoroutine(Routine());
        }

        private IEnumerator Routine()
        {
            yield return new WaitUntil(() => audioLowPassFilter != null);

            DOTween.To(
                () => audioLowPassFilter.cutoffFrequency,
                x => audioLowPassFilter.cutoffFrequency = x,
                playerEffectsData.normalCutoff,
                playerEffectsData.demuffleDuration
            ).SetEase(playerEffectsData.muffleEase)
            .SetUpdate(true);
        }
    }
}