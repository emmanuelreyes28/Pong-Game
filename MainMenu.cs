using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //Load next level in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void isPlayerAI()
    {
        EnemyController.playerAI = true;
    }

    public void isPlayerHuman()
    {
        EnemyController.playerAI = false;
    }

    public void easyDifficulty()
    {
        //speed of AI(red) paddle
        EnemyController.AIDifficulty = 2.0f;
    }

    public void mediumDifficulty()
    {
        //speed of AI(red) paddle
        EnemyController.AIDifficulty = 4.0f;
    }

    public void hardDifficulty()
    {
        //speed of AI(red) paddle
        EnemyController.AIDifficulty = 6.0f;
    }
    public void QuitGame()
    {
        //exit application
        Application.Quit();
    }
}
