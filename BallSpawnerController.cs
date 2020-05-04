using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour
{
    public GameObject ball;
    public float waitTime = 1f;
    private float timer;

    void Update()
    {
        //if there is no ball create one
       if(transform.childCount == 0 && timer >= waitTime)
       {
           timer = 0.0f;
           StartCoroutine("BallSpawn");
       }
       else
       {
           timer += Time.deltaTime;
       } 
    }

    IEnumerator BallSpawn()
    {
        //Wait 1 second and instantiate new ball 
        GameObject ballClone;
        yield return new WaitForSeconds(waitTime);
        ballClone = Instantiate(ball, this.transform.position, this.transform.rotation) as GameObject;
        ballClone.transform.SetParent(this.transform);

    }
}
