using Levels.LevelSaveSystem;
using MenuSystem;
using UnityEngine;

public class MenuEverythingGlue : MonoBehaviour
{
    private PauseMenuController pauseMenuController;
    private LevelManager levelManager;

    private void Start()
    {
        pauseMenuController = FindAnyObjectByType<PauseMenuController>();

        levelManager = LevelManager.Instance;
    }

    private void OnEnable()
    {
        Entities.Player.InputHandler.OnPausePressed += PauseGame;

        MenuSystem.Sections.StartSection.OnGameContinued += ContinueGame;
    }
    private void OnDisable()
    {
        Entities.Player.InputHandler.OnPausePressed -= PauseGame;

        MenuSystem.Sections.StartSection.OnGameContinued -= ContinueGame;
    }

    public void PauseGame()
    {
        pauseMenuController.PauseGame();
    }

    public void ContinueGame()
    {
        levelManager.LoadLevel();
    }
}