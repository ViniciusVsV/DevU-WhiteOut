using MenuSystem.Sections;
using UnityEngine;

namespace MenuSystem
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private PauseSection pauseSection;
        [SerializeField] private ConfigSection configSection;

        private bool isPaused;

        public void PauseGame()
        {
            if (isPaused)
            {
                pauseSection.Deactivate();
                configSection.Deactivate();

                Time.timeScale = 1f;

                isPaused = false;

                return;
            }

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
    }
}