using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuSystem.Sections
{
    public class StartSection : MonoBehaviour
    {
        [SerializeField] private string firstLevelName;

        public static event Action OnGameContinued;

        public void StartNewGame()
        {
            SceneManager.LoadScene(firstLevelName);
        }

        public void ContinueGame()
        {
            OnGameContinued?.Invoke();
        }
    }
}