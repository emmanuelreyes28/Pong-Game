using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera cam;
    //list of colors
    public List<Color> colorList = new List<Color>();
    public bool randomColor;
    private int colorIndex = 0;
    private int nextColorIndex = 1;
    public float duration = 5.0f;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        //set color to first color in list 
        cam.backgroundColor = colorList[colorIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //update time 
        time += Time.deltaTime;
        
        if(randomColor)
        {
            while(nextColorIndex == colorIndex)
            {
                //pick random color from color list
                nextColorIndex = Random.Range(0, colorList.Count);
            }
        }
        else
        {
            if(time >= duration)
            {
                if(nextColorIndex >= colorList.Count)
                {
                    nextColorIndex = 0;
                }
                else
                {
                    //change bg color to next color in list 
                    cam.backgroundColor = Color.Lerp(colorList[colorIndex], colorList[nextColorIndex], time);
                    //restart timer
                    time = 0.0f;
                    nextColorIndex += 1;
                }
                
            }
        }
    }

    
}
