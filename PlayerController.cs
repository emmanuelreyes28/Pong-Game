using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //scale variable
    private Vector3 decreaseScale;
    //player's rigibody 
    private Rigidbody2D playerRB;
    //speed of player 
    public float speed = 10f;
    //bounds of player
    public float topBound = 3.5f;
    public float bottomBound = -3.5f;
    //player input controls
    public KeyCode up;
    public KeyCode down;
    //timer 
    private float timer;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        //decrease scale on y axis
        decreaseScale = new Vector3(0.0f, -0.10f, 0.0f);
    }


    void FixedUpdate()
    {   
        //apply player input 
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
       

        //set bounds 
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
