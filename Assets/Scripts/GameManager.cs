using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    public Text scoretext;
    // Update is called once per frame
    void Update()
    {
        scoretext.text="Score = " + score.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("EXIT");
        }
    }

    public void killEnemy()
    {
        score += 5;
        if (score >= PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        
    }
}
