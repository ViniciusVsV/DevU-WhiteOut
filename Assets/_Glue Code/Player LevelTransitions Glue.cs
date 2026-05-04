using Entities.Player;
using Levels.LevelTransitions;
using UnityEngine;

public class PlayerLevelTransitionsGlue : MonoBehaviour
{
    private TransitionManager transitionManager;

    private void Start()
    {
        transitionManager = FindAnyObjectByType<TransitionManager>();
    }

    private void OnEnable()
    {
        DeathDetector.OnPlayerDeath += FailLevel;
    }
    private void OnDisable()
    {
        DeathDetector.OnPlayerDeath -= FailLevel;
    }

    public void FailLevel()
    {
        transitionManager.FailLevel();
    }
}