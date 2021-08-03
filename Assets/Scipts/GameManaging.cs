using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManaging : MonoBehaviour
{
    [SerializeField] private float restartDelay = 2f;
    bool gameHasEnded = false;
    private PlayFabManager fabManager;

    private void Start()
    {
        fabManager = new PlayFabManager();
    }
    public void endGame(int scoreAmount,int coinsAmount) 
    {
        if (gameHasEnded == false) 
        { 
            gameHasEnded = true;
            Debug.Log(coinsAmount);
            Debug.Log(scoreAmount);

            SaveData(scoreAmount, coinsAmount);
            fabManager.SendLeaderBoard(scoreAmount);

            Invoke("Restart", restartDelay);
        }
    }

    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SaveData(int scoreAmount,int coinsAmount)
    {
        PlayerData characterData = new PlayerData(scoreAmount, coinsAmount);
    }

}
