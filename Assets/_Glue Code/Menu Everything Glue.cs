using Levels.LevelSaveSystem;
using Levels.LevelTransitions;
using MenuSystem;
using UnityEngine;

public class MenuEverythingGlue : MonoBehaviour
{
    private PauseMenuController pauseMenuController;
    private LevelExit levelExit;

    private void Start()
    {
        pauseMenuController = FindAnyObjectByType<PauseMenuController>();
        levelExit = FindAnyObjectByType<LevelExit>();
    }

    private void OnEnable()
    {
        Entities.Player.InputHandler.OnPausePressed += PauseGame;
        MenuSystem.PauseMenuController.OnMenuReturned += ReturnToMenu;
    }
    private void OnDisable()
    {
        Entities.Player.InputHandler.OnPausePressed -= PauseGame;
        MenuSystem.PauseMenuController.OnMenuReturned -= ReturnToMenu;
    }

    public void PauseGame()
    {
        pauseMenuController.PauseGame();
    }

    public void ReturnToMenu()
    {
        levelExit.ExitToMenu();
    }
}