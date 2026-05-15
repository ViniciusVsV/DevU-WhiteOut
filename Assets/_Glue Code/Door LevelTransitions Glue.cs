using DoorSystem;
using Levels.LevelTransitions;
using UnityEngine;

public class DoorLevelTransitionsGlue : MonoBehaviour
{
    private TransitionManager transitionManager;

    private void Start()
    {
        transitionManager = FindAnyObjectByType<TransitionManager>();
    }

    private void OnEnable()
    {
        DoorBehaviour.OnDoorEntered += ExitLevel;
    }
    private void OnDisable()
    {
        DoorBehaviour.OnDoorEntered -= ExitLevel;
    }

    public void ExitLevel()
    {
        transitionManager.ExitLevel();
    }
}