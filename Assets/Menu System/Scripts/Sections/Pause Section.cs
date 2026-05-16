using UnityEngine;
using UnityEngine.EventSystems;

namespace MenuSystem.Sections
{
    public class PauseSection : MonoBehaviour
    {
        [SerializeField] private GameObject sectionObject;
        [SerializeField] private GameObject startingObject;

        public void Activate()
        {
            sectionObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(startingObject);
        }

        public void Deactivate()
        {
            sectionObject.SetActive(false);
        }
    }
}