using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MenuSystem.Sections
{
    public class PauseSection : MonoBehaviour
    {
        [SerializeField] private GameObject sectionObject;
        [SerializeField] private Button unpauseButton;

        public void Activate()
        {
            sectionObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(unpauseButton.gameObject);
        }

        public void Deactivate()
        {
            sectionObject.SetActive(false);
        }
    }
}