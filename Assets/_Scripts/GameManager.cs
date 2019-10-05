using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    menu, inGame, gameOver
}

public class GameManager : MonoBehaviour
{
    // Estado
    public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance;
    
    private void Awake() {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void BackMenu()
    {
        SetGameState(GameState.menu);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            // MENU
        }
        else if(newGameState == GameState.inGame)
        {
            // GAME
            Spawn[] spawns = Spawn.FindObjectsOfType<Spawn>();
            Debug.Log(spawns.Length + "Numero de spawns");

            foreach (var spItem in spawns)
            {
                StartCoroutine(spItem.InvokeCar());
            }
        }
        else if(newGameState == GameState.gameOver)
        {
            // GAME OVER
        }

        this.currentGameState = newGameState;
    }
}
