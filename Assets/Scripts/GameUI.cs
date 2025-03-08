using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public void startGame()
    {
        gameManager.startGame();
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void continueGame()
    {
        gameManager.resumeGame();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
