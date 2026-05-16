using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

namespace Levels.Level0
{
    public class NewGameHandler : MonoBehaviour
    {
        [Header("Objects")]
        [SerializeField] private GameObject wallObject;
        [SerializeField] private CinemachineCamera uiCamera;
        [SerializeField] private CinemachineCamera playerFocusCamera;
        [SerializeField] private CinemachineBrain mainCameraBrain;
        [SerializeField] private ButtonAnimations buttonAnimations;
        [SerializeField] private PlayableDirector startCutscene;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private RuntimeAnimatorController mainPlayerController;

        private void Awake()
        {

        }

        public void StartNewGame()
        {
            PlayerPrefs.DeleteKey("GunCollected");
            PlayerPrefs.Save();

            //Desativa os botões de jogar
            buttonAnimations.FadeOutButtons(false);

            wallObject.SetActive(false);

            StartCoroutine(Routine());
        }

        private IEnumerator Routine()
        {
            //Ativa a câmera de foco no player
            uiCamera.Priority = -10;
            playerFocusCamera.Priority = 100;

            //Espera o tempo de transição da câmera
            yield return new WaitForSeconds(mainCameraBrain.DefaultBlend.Time);

            //Dá play na timeline
            startCutscene.Play();
        }

        private void OnEnable()
        {
            startCutscene.stopped += SwitchAnimator;
        }
        private void OnDisable()
        {
            startCutscene.stopped -= SwitchAnimator;
        }

        private void SwitchAnimator(PlayableDirector director)
        {
            playerAnimator.runtimeAnimatorController = mainPlayerController;
        }
    }
}