using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{


    //public override void Awake()
    //{
    //    MakeSingleton(false);

    //}

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("Main");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }

    public void ExitGame()
    {

        SceneManager.LoadScene("Exit");
        
    }

    public void YesExit()
    {
        Application.Quit();
    }

    public void NoExit()
    {
        ResumeGame();
        SceneManager.LoadScene("Main");
    }

    public void DeleteData()
    {
        SceneManager.LoadScene("DeleteData");
    }

    public void Yes()
    {
  
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main");

    }

    public void No()
    {
        SceneManager.LoadScene("Main");
    }

}
