using UnityEngine;

namespace MenuSystem.Sections
{
    public class ConfigSection : MonoBehaviour
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