using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBorder : MonoBehaviour
{
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //DEBUG
        /*
        if(Input.GetKeyDown("o"))
        {
            counter++;
            ExpandBorderSize(counter);
        }
        */
    }
    public void ExpandBorderSize(int dayNum)
    {
        //check which day it is
        if(dayNum == 1)
        {
            //increase border
            gameObject.GetComponent<CameraControl>().minMapBorderX += 50f;
            gameObject.GetComponent<CameraControl>().minMapBorderY += 50f;
            //increase zoom out
            gameObject.GetComponent<CameraControl>().maxCameraDistance += 7.0f;
            //increase scroll speed
            gameObject.GetComponent<CameraControl>().scrollSpeed += 0.5f;
        }
        else if(dayNum == 2)
        {
            gameObject.GetComponent<CameraControl>().maxMapBorderX += 50f;
            gameObject.GetComponent<CameraControl>().maxMapBorderY += 10f;

            gameObject.GetComponent<CameraControl>().maxCameraDistance += 4.0f;
           
            gameObject.GetComponent<CameraControl>().scrollSpeed += 1.0f;
        }
        else if (dayNum == 3)
        {
            gameObject.GetComponent<CameraControl>().minMapBorderX += 50f;         
            gameObject.GetComponent<CameraControl>().maxMapBorderX += 120f;
            gameObject.GetComponent<CameraControl>().minMapBorderY += 50f;
            gameObject.GetComponent<CameraControl>().maxMapBorderY += 10f;

            gameObject.GetComponent<CameraControl>().maxCameraDistance += 18f;

            gameObject.GetComponent<CameraControl>().scrollSpeed += 2.0f;

        }
        else if(dayNum == 4)
        {
            gameObject.GetComponent<CameraControl>().maxMapBorderY += 50f;

            gameObject.GetComponent<CameraControl>().maxCameraDistance += 10f;
            
        }
        else if(dayNum == 5)
        {
            gameObject.GetComponent<CameraControl>().minMapBorderX += 170f;
            gameObject.GetComponent<CameraControl>().maxMapBorderX += 5f;
            gameObject.GetComponent<CameraControl>().minMapBorderY += 30f;
            gameObject.GetComponent<CameraControl>().maxMapBorderY += 100f;

            gameObject.GetComponent<CameraControl>().maxCameraDistance += 20f;

            gameObject.GetComponent<CameraControl>().scrollSpeed += 5.0f;
        }
        

        Debug.Log("Border is Expanded");
    }
}
