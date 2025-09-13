using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagent : MonoBehaviour
{
    public Text highscoretext;

    private void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore");
        highscoretext.text = "Hightscore = " + highscore.ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("EXIT");
        }
    }
}
