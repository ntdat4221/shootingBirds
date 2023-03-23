using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : Singleton<GameManager2>
{
    public Bird2[] birds;
    public float spawnTime;
    public int timeLimit;

    int m_curTimeLimit;
    int m_birdKilled;

    bool m_isGameover;
    public bool IsGameover { get => m_isGameover; set => m_isGameover = value; }
    public int BirdKilled { get => m_birdKilled; set => m_birdKilled = value; }


    public override void Awake()
    {
        MakeSingleton(false);

        m_curTimeLimit = timeLimit;
    }
    public override void Start()
    {
        GameGUIManager2.Ins.ShowGameGUI(false);
        GameGUIManager2.Ins.UpdateKilledCounting(m_birdKilled);
    }

    public void PlayGame()
    {
        StartCoroutine(GameSpawn());
        StartCoroutine(TimeCountDown());
        GameGUIManager2.Ins.ShowGameGUI(true);
    }

    IEnumerator TimeCountDown()
    {
        while (m_curTimeLimit > 0)
        {
            yield return new WaitForSeconds(1.0f);
            m_curTimeLimit--;
            if (m_curTimeLimit <= 0)
            {
                 m_isGameover = true;

                if (m_birdKilled >= 6)
                {   
                   
                    GameGUIManager2.Ins.gameDialog1.UpdateDialog("NEXT LEVEL", "LEVEL 3");
                    GameGUIManager2.Ins.gameDialog1.Show(true);
                    GameGUIManager2.Ins.CurDialog = GameGUIManager2.Ins.gameDialog1;
                }
                else 
                {
                    GameGUIManager2.Ins.gameDialog.UpdateDialog("GAME OVER", "LEVEL 2");                   
                    GameGUIManager2.Ins.gameDialog.Show(true);
                    GameGUIManager2.Ins.CurDialog = GameGUIManager2.Ins.gameDialog;
                }

                Prefs.bestScore = m_birdKilled;

                
                

            }
            GameGUIManager2.Ins.UpdateTimer(IntToTime(m_curTimeLimit));
        }
    }
    IEnumerator GameSpawn()
    {
        while (!m_isGameover)
        {
            SpawnBird();
            yield return new WaitForSeconds(spawnTime);
        }
    }
    void SpawnBird()
    {
        Vector3 spawPos = Vector3.zero;
        float randCheck = Random.Range(0f, 1f);

        if (randCheck >= 0.5f) {
            spawPos = new Vector3(12, Random.Range(-1.0f, 2.0f), 0f);
        }
        else
        {
            spawPos = new Vector3(-12, Random.Range(-1.0f, 2.0f), 0f);
        }

        if (birds != null && birds.Length > 0)
        {
            int randIdx = Random.Range(0, birds.Length);

            if (birds[randIdx] != null)
            {
                Bird2 birdClone = Instantiate(birds[randIdx], spawPos, Quaternion.identity);
            }
        }
    }

    string IntToTime(int time)
    {
        float minute = Mathf.Floor(time / 60);
        float second = Mathf.RoundToInt(time % 60);
        return minute.ToString("00") + ":" + second.ToString("00");
    }
}
