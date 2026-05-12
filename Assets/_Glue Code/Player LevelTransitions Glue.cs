using Entities.Player;
using Levels.LevelTransitions;
using UnityEngine;

public class PlayerLevelTransitionsGlue : MonoBehaviour
{
    private TransitionManager transitionManager;
    private InputHandler inputHandler;

    private void Start()
    {
        transitionManager = FindAnyObjectByType<TransitionManager>();
        inputHandler = FindAnyObjectByType<InputHandler>();
    }

    private void OnEnable()
    {
        DeathDetector.OnPlayerDeath += FailLevel;

        LevelEnter.OnLevelEntered += EnableInputs;
        LevelReEnter.OnLevelReEntered += EnableInputs;
        LevelExit.OnLevelExit += DisableInputs;
    }
    private void OnDisable()
    {
        DeathDetector.OnPlayerDeath -= FailLevel;

        LevelEnter.OnLevelEntered -= EnableInputs;
        LevelReEnter.OnLevelReEntered -= EnableInputs;
        LevelExit.OnLevelExit -= DisableInputs;
    }

    public void FailLevel()
    {
        transitionManager.FailLevel();
    }

    public void EnableInputs()
    {
        inputHandler.EnableInputs();
    }
    public void DisableInputs()
    {
        inputHandler.DisableInputs();
    }
}