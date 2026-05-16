using System.Collections;
using Entities.Player;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace Levels.LevelFinal
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FinalCutscene : MonoBehaviour
    {
        private BoxCollider2D col;

        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private CinemachineCamera cinemachineCamera;
        [SerializeField] private CinemachineBrain mainCamera;
        [SerializeField] private PlayableDirector timeline;
        [SerializeField] private AudioSource musicSource;

        private void Awake()
        {
            col = GetComponent<BoxCollider2D>();

            musicSource.volume = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                col.enabled = false;

                //Desativa os inputs do jogador
                inputHandler.DisableInputs();

                StartCoroutine(Routine());
            }
        }

        private IEnumerator Routine()
        {
            //Troca a câmera
            cinemachineCamera.Priority = 100;

            //Espera a transição da câmera finalizar
            yield return new WaitForSeconds(mainCamera.DefaultBlend.Time);

            //Dá play na timeline
            timeline.Play();
        }

        public void ReturnToMenu()
        {
            SceneManager.LoadScene("Level 0");
        }
    }
}