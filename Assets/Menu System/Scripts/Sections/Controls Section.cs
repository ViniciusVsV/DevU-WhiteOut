using UnityEngine;

namespace MenuSystem.Sections
{
    public class ControlsSection : MonoBehaviour
    {
        [SerializeField] private GameObject sectionObject;

        public void Activate()
        {
            sectionObject.SetActive(true);
        }

        public void Deactivate()
        {
            sectionObject.SetActive(false);
        }
    }
}