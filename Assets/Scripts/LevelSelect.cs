using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private Text levelName;
    [SerializeField] private Button button;

    // Start is called before the first frame update
    void Start()
    {
        levelName.text =  levelNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        if (levelAt < levelNumber)
        {
            button.interactable = false;
        }
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene(levelNumber + 2);
    }
}
