using UnityEngine;
using UnityEngine.UI;

namespace Levels.Level0
{
    public class ContinueGameHandler : MonoBehaviour
    {
        [SerializeField] private Transitions transitions;

        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueGameButton;
        [SerializeField] private Button configButton;

        public void ContinueGame()
        {
            //Desativa todos os botões
            newGameButton.gameObject.SetActive(false);
            continueGameButton.gameObject.SetActive(false);
            configButton.gameObject.SetActive(false);

            //Sai da cena
            transitions.FadeOut("load");
        }
    }
}