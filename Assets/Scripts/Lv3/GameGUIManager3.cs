using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager3 : Singleton<GameGUIManager3>
{
    public GameObject homeGUI;
    public GameObject gameGUI;

    public Dialog gameDialog;
    public Dialog gameDialog1;
    public Dialog pauseDialog;

    public Image reloadFilled;
    public Text timerText;
    public Text killedCountingText;

    Dialog m_curDialog;

    public Dialog CurDialog { get => m_curDialog; set => m_curDialog = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameGUI(bool isShow)
    {
        if (gameGUI != null)
            gameGUI.SetActive(isShow);
        if (homeGUI != null)
            homeGUI.SetActive(!isShow);
    }

    public void UpdateTimer(string time)
    {
        if (timerText != null)
            timerText.text = time;
    }

    public void UpdateKilledCounting(int killed)
    {
        if (killedCountingText != null)
            killedCountingText.text = killed.ToString() + " / 10";
    }

    public void UpdateReload(float reload)
    {
        if (reloadFilled != null)
            reloadFilled.fillAmount = reload;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;

        if (pauseDialog)
        {
            m_curDialog = pauseDialog;
            pauseDialog.Show(true);
            pauseDialog.UpdateDialog("PAUSE", "LEVEL 3");
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;

        if (m_curDialog)
        {
            m_curDialog.Show(false);
        }
    }
    public void BackToHome()
    {
        ResumeGame();
        SceneManager.LoadScene("Main");
    }

    public void Replay()
    {
        //if (m_curDialog)
        //    m_curDialog.Show(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager3.Ins.PlayGame();
    }
    public void Next()
    {
        //if (m_curDialog)
        //    m_curDialog.Show(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager3.Ins.PlayGame();
    }

    public void End()
    {
        //if (m_curDialog)
        //    m_curDialog.Show(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

    public void ExitGame()
    {

        SceneManager.LoadScene("Exit");
    }
}

