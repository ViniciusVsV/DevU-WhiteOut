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
        EffectsController.OnPlayerDeath += FailLevel;
    }
    private void OnDisable()
    {
        EffectsController.OnPlayerDeath -= FailLevel;
    }

    public void FailLevel()
    {
        transitionManager.FailLevel();
    }
}