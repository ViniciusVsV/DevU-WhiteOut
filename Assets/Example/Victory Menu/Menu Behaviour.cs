using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace VictoryMenu
{
    public class MenuBehaviour : MonoBehaviour
    {
        public void OnAction(InputAction.CallbackContext context)
        {
            SceneManager.LoadScene("Game");
        }
    }
}