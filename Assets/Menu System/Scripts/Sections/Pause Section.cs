using UnityEngine;
using UnityEngine.Playables;

namespace MenuSystem.Sections
{
    public class PauseSection : MonoBehaviour
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