using DoorSystem;
using Entities.Player;
using Levels.Level0;
using MenuSystem.Sections;
using UnityEngine;

public class Level0Glue : MonoBehaviour
{
    [SerializeField] private NewGameHandler newGameHandler;
    [SerializeField] private ContinueGameHandler continueGameHandler;
    [SerializeField] private Transitions transitions;
    [SerializeField] private InputHandler inputHandler;

    private void OnEnable()
    {
        StartSection.OnNewGameStarted += StartNewGame;
        StartSection.OnGameContinued += ContinueGame;

        DoorBehaviour.OnDoorEntered += ExitLevel;
    }
    private void OnDisable()
    {
        StartSection.OnNewGameStarted -= StartNewGame;
        StartSection.OnGameContinued -= ContinueGame;

        DoorBehaviour.OnDoorEntered -= ExitLevel;
    }

    public void StartNewGame()
    {
        newGameHandler.StartNewGame();
    }
    public void ContinueGame()
    {
        continueGameHandler.ContinueGame();
    }

    public void ExitLevel()
    {
        inputHandler.DisableInputs();
        transitions.FadeOut("Level 1");
    }
}