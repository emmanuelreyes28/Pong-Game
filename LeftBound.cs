using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftBound : MonoBehaviour
{
    public Text playerScoreText;
    int playerScore;
    public Text winText;
    public Text blueWinsText;
    //game options
    public GameObject playAgain;
    public GameObject mainMenu;
    public GameObject quit;

    void Start()
    {
        //unfreeze game
        Time.timeScale = 1;

        //disable text and buttons
        winText.enabled = false;
        blueWinsText.enabled = false;
        playAgain.SetActive(false);
        mainMenu.SetActive(false);
        quit.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other){
        //Destroys gameobject ball
        if(other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            //increase player score
            playerScore++; 
            playerScoreText.text = playerScore.ToString();
            GetComponent<AudioSource>().Play();
        }
    }

    void Update(){
        //enable text and buttons once someone has won
        if(playerScore == 3 && EnemyController.playerAI)
        {
            winText.enabled = true;
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            quit.SetActive(true);
            Time.timeScale = 0;
        }
        else if(playerScore == 3)
        {
            blueWinsText.enabled = true;
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            quit.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
