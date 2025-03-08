using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpawner;
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject gameUI;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioManager audioManager;
    void Start()
    {
        currentEnergy = 0;
        updateEnergyBar();
        boss.SetActive(false);
        MainMenu();
        audioManager.stopAudioGame();
    }

    public void addEnergy()
    {
        if (bossCalled)
        {
            return;
        }
        currentEnergy += 1;
        updateEnergyBar();
        if (currentEnergy == energyThreshold)
        {
            callBoss();
        }
    }

    private void callBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpawner.SetActive(false);
        gameUI.SetActive(false);
        audioManager.playBossSound();
    }

    private void updateEnergyBar()
    {
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameOverMenu()
    {
        gameOver.SetActive(true);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseGameMenu()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 0f;
    }

    public void startGame()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        audioManager.playDefaultAudio();
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
    }
}
