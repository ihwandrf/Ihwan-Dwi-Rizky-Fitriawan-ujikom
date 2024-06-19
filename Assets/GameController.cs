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

    public TMP_Text timer;
    public TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        timer.SetText(gameTime.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        /*gameTime--;
        timer.SetText(gameTime.ToString());*/

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
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        HidePanelMain();
        ShowPanelPause();
        isPaused = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        HidePanelPause();
        ShowPanelMain();
        isPaused = false;
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
}
