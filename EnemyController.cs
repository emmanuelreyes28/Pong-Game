using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //AI player
    public static bool playerAI;
    //AI difficulty 
    public static float AIDifficulty;
    //speed of red paddle
    public float speed;
    //player 2 input controls
    public KeyCode up;
    public KeyCode down;
    //player's rigidbody
    private Rigidbody2D playerRB;
    //ball 
    Transform ball;
    //ball's rigidbody
    Rigidbody2D ballRb2D;
    //bounds of enemy
    public float topBound = 3.5f;
    public float bottomBound = -3.5f;
    //scale variable
    private Vector3 decreaseScale;
    //timer
    private float timer;

    void Start()
    {
        if(!playerAI)
        {
            //change speed
            speed = 10f;
            playerRB = GetComponent<Rigidbody2D>();
        }
        else
        {
            //change speed to appropiate difficulty 
            speed = AIDifficulty;
        }

        //decrease scale on y axis
        decreaseScale = new Vector3(0.0f, -0.10f, 0.0f);
    }
    void FixedUpdate(){
        if(playerAI)
        {
            //finding the ball
            ball = GameObject.FindGameObjectWithTag("Ball").transform;

            //setting the ball's rb to a variable
            ballRb2D = ball.GetComponent<Rigidbody2D>();

            //checking x direction of ball
            if(ballRb2D.velocity.x < 0)
            {
                //checking y direction of ball
                if(ball.position.y < this.transform.position.y)
                {
                    //move down if ball lower than paddle
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                }
                else if(ball.position.y > this.transform.position.y)
                {
                    //move up if ball higher than paddle
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
            }
        }
        else
        {
            //move paddle with user input 
            if(Input.GetKey(up))
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, speed);
            }
            else if(Input.GetKey(down))
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, -speed);
            }
            else
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            }
        }
        

        //set bounds of enemy/player2
        if(transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x, topBound, 0);
        }
        else if(transform.position.y < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, bottomBound, 0);
        }
    }

    void Update()
    {
        //update timer one sec 
        timer += Time.deltaTime;
        if(timer >= 30.0f)
        {
            paddleChange();
            //restart timer
            timer = 0.0f;
        }
    }

    void paddleChange()
    {
        //decrease scale of paddle
        if(this.transform.localScale.y <= 1.0f && this.transform.localScale.y >= 0.40)
        {
            this.transform.localScale += decreaseScale;

            //set bounds accordingly to paddle size
            topBound += 0.12f;
            bottomBound -= 0.12f;
        }
        else
        {
            //return paddle to original size 
            this.transform.localScale = new Vector3(this.transform.localScale.x, 1.0f, this.transform.localScale.z);
            
            //set bounds accordingly to paddle size
            topBound = 3.5f;
            bottomBound = -3.5f;
        }
    }
}
