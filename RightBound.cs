using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RightBound : MonoBehaviour
{
    public Text enemyScoreText;
    int enemyScore;
    //win text
    public Text loseText;
    public Text redWinsText;
    //game options
    public GameObject playAgain;
    public GameObject mainMenu;
    public GameObject quit;

    void Start(){
        //unfreeze game when restarting 
        Time.timeScale = 1;
        //disable text at beginning of game
        loseText.enabled = false;
        redWinsText.enabled = false;
        playAgain.SetActive(false);
        mainMenu.SetActive(false);
        quit.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other){
        //Destroys gameobject ball
        if(other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);

            //increase enemy score 
            enemyScore++; 
            enemyScoreText.text = enemyScore.ToString();
            GetComponent<AudioSource>().Play();
        }
    }

    void Update(){
        //enable text and buttons once someone has won 
        if(enemyScore == 3 && EnemyController.playerAI)
        {
            loseText.enabled = true;
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            quit.SetActive(true);
            Time.timeScale = 0;
        }
        else if(enemyScore == 3)
        {
            redWinsText.enabled = true;
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            quit.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
