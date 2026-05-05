using MenuSystem.Sections;
using UnityEngine;

namespace MenuSystem
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private PauseSection pauseSection;
        [SerializeField] private ConfigSection configSection;
        [SerializeField] private ControlsSection controlsSection;

        private bool isPaused;
        public bool canPause = true;

        public void PauseGame()
        {
            if (isPaused)
            {
                pauseSection.Deactivate();
                configSection.Deactivate();
                controlsSection.Deactivate();

                Time.timeScale = 1f;

                isPaused = false;

                return;
            }

            if (!canPause)
                return;

            isPaused = true;

            Time.timeScale = 0;
            pauseSection.Activate();
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