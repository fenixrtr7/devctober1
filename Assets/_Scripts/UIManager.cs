using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText, maxScoreText;
    float score, maxScore;

    public GameObject panelMenu, panelGameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            score+= Time.deltaTime;
            scoreText.text = "Score: " + score.ToString("0.00");
        }
    }

    public void ButtonPlay()
    {
        GameManager.sharedInstance.StartGame();
        panelMenu.SetActive(false);
    }
}
