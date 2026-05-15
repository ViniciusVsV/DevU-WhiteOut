using System;
using UnityEngine;

namespace MenuSystem.Sections
{
    public class StartSection : MonoBehaviour
    {
        public static event Action OnNewGameStarted;
        public static event Action OnGameContinued;

        public void StartNewGame()
        {
            OnNewGameStarted?.Invoke();
        }

        public void ContinueGame()
        {
            OnGameContinued?.Invoke();
        }
    }
}