using AudioSystem;
using MenuSystem;
using UnityEngine;

public class MenuEverythingGlue : MonoBehaviour
{
    private PauseMenuController pauseMenuController;

    private void Start()
    {
        pauseMenuController = FindAnyObjectByType<PauseMenuController>();
    }

    private void OnEnable()
    {
        Entities.Player.InputHandler.OnPausePressed += PauseGame;
    }
    private void OnDisable()
    {
        Entities.Player.InputHandler.OnPausePressed -= PauseGame;
    }

    public void PauseGame()
    {
        pauseMenuController.PauseGame();
    }
}