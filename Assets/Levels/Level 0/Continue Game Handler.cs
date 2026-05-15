using UnityEngine;
using UnityEngine.UI;

namespace Levels.Level0
{
    public class ContinueGameHandler : MonoBehaviour
    {
        [SerializeField] private Transitions transitions;
        [SerializeField] private ButtonAnimations buttonAnimations;

        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueGameButton;
        [SerializeField] private Button openConfigButton;

        private void Awake()
        {
            PlayerPrefs.DeleteAll();

            if (!PlayerPrefs.HasKey("SavedLevel"))
            {
                continueGameButton.interactable = false;

                Navigation newGameNav = newGameButton.navigation;
                newGameNav.selectOnDown = openConfigButton;
                newGameButton.navigation = newGameNav;

                Navigation configNav = openConfigButton.navigation;
                configNav.selectOnUp = newGameButton;
                openConfigButton.navigation = configNav;
            }
        }

        public void ContinueGame()
        {
            //Desativa todos os botões
            buttonAnimations.FadeOutButtons(true);

            //Sai da cena
            transitions.FadeOut("load");
        }
    }
}