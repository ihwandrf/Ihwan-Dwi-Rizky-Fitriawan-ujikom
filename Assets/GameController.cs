using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isPaused = false;

    public int gameTime = 60;

    public CanvasGroup panelPause;
    public CanvasGroup panelMain;
    public CanvasGroup gameOverPanel;

    public TMP_Text timer;
    public TMP_Text score;

    public SFXController sfxController;
    // Start is called before the first frame update
    void Start()
    {
        timer.SetText(gameTime.ToString());
        StartCoroutine(TimerCountdown());
        sfxController = GameObject.FindGameObjectWithTag("SFX Controller").GetComponent<SFXController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            isGameOver = true;
        }

        if (isGameOver)
        {
            gameTime = 0;
            HidePanelMain();
            ShowGameOverPanel();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        HidePanelMain();
        ShowPanelPause();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        HidePanelPause();
        ShowPanelMain();
        isPaused = false;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        sfxController.GameOver();
        ShowGameOverPanel();
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowGameOverPanel()
    {
        gameOverPanel.alpha = 1;
        gameOverPanel.interactable = true;
        gameOverPanel.blocksRaycasts = true;
        gameOverPanel.ignoreParentGroups = true;
    }

    public void HidePanelMain()
    {
        panelMain.alpha = 0;
        panelMain.interactable = false;
        panelMain.blocksRaycasts = false;
        panelMain.ignoreParentGroups = false;
    }

    public void ShowPanelMain()
    {
        panelMain.alpha = 1;
        panelMain.interactable = true;
        panelMain.blocksRaycasts = true;
        panelMain.ignoreParentGroups = true;
    }

    public void HidePanelPause()
    {
        panelPause.alpha = 0;
        panelPause.interactable = false;
        panelPause.blocksRaycasts = false;
        panelPause.ignoreParentGroups = false;
    }

    public void ShowPanelPause()
    {
        panelPause.alpha = 1;
        panelPause.interactable = true;
        panelPause.blocksRaycasts = true;
        panelPause.ignoreParentGroups = true;
    }

    IEnumerator TimerCountdown()
    {
        if(gameTime > 0)
        {
            gameTime--;
            timer.SetText(gameTime.ToString());
            yield return new WaitForSecondsRealtime(1);
            StartCoroutine(TimerCountdown());
        }
        else
        {
            isGameOver = true;
        }
        
    }
}
