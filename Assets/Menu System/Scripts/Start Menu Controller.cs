using MenuSystem.Sections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuSystem
{
    public class StartMenuController : MonoBehaviour
    {
        [SerializeField] private ConfigSection configSection;
        [SerializeField] private ControlsSection controlsSection;

        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void OpenConfigSection()
        {
            configSection.Activate();
        }
        public void CloseConfigSection()
        {
            configSection.Deactivate();
        }

        public void OpenControlsSection()
        {
            controlsSection.Activate();
        }
        public void CloseControlsSection()
        {
            controlsSection.Deactivate();
        }
    }
}