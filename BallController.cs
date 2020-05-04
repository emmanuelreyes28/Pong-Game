using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //speed of ball
    public float speed = 3.5f;

    //initial direction of ball
    private Vector2 spawnDirection;
    //ball component
    Rigidbody2D rb2D;
    //timer
    private float timer = 0f;
    
    void Start()
    {
        //setting ball's rb
        rb2D = this.gameObject.GetComponent<Rigidbody2D>();

        //generating random initial directions
        int rand = Random.Range(1,4);

        //setting intial direction
        if(rand == 1)
        {
            spawnDirection = new Vector2(1,1);
        }
        else if(rand == 2)
        {
            spawnDirection = new Vector2(1,-1);
        }
        else if(rand == 3)
        {
            spawnDirection = new Vector2(-1,-1);
        }
        else if(rand == 4)
        {
            spawnDirection = new Vector2(-1,1);
        }

        //moving ball in initial direction 
        rb2D.velocity = (spawnDirection * speed);

    }

    void Update()
    {
        //start timer counter
        timer += Time.deltaTime;
    
        if(timer >= 30.0f)
        {
            //increase speed and apply force to ball
            speed += 2.5f;
            rb2D.AddForce(rb2D.velocity * speed);
            
            //restart timer
            timer = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //play sound if ball hits these gameObjects
        if(other.gameObject.tag == "TopBound" || other.gameObject.tag == "BottomBound" ||
           other.gameObject.tag == "Paddle")
        {
            GetComponent<AudioSource>().Play();
        }
    }

}
