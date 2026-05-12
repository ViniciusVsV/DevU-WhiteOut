using MenuSystem.Sections;
using UnityEngine;

namespace MenuSystem
{
    public class StartMenuController : MonoBehaviour
    {
        [SerializeField] private ConfigSection configSection;

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