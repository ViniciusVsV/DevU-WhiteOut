using System.Collections;
using Entities.Player;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

namespace Levels.Level0
{
    public class NewGameHandler : MonoBehaviour
    {
        [SerializeField] private Level0Data level0Data;

        [Header("Objects")]
        [SerializeField] private GameObject wallObject;
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private CinemachineCamera uiCamera;
        [SerializeField] private CinemachineBrain mainCameraBrain;
        [SerializeField] private GameObject tutorialTextObject;
        [SerializeField] private ButtonAnimations buttonAnimations;

        private void Awake()
        {
            tutorialTextObject.SetActive(false);
        }

        public void StartNewGame()
        {
            //Desativa os botões de jogar
            buttonAnimations.FadeOutButtons(false);

            wallObject.SetActive(false);

            uiCamera.Priority = -10;

            inputHandler.inputsDisabled = false;

            //Espera o tempo de transição da câmera para aparecer o tutorial de andar
            StartCoroutine(Routine());
        }

        private IEnumerator Routine()
        {
            yield return new WaitForSeconds(mainCameraBrain.DefaultBlend.Time);

            tutorialTextObject.SetActive(true);
        }
    }
}