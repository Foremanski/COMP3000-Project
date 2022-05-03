using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBorder : MonoBehaviour
{
    int counter = 0;
    [SerializeField]
    private GameObject Group2, Group3, Group4, Group5, Group6;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //DEBUG
        
        if(Input.GetKeyDown("o"))
        {
            counter++;
            ExpandBorderSize(counter);
        }
        
    }
    public void ExpandBorderSize(int dayNum)
    {
        //check which day it is
        if(dayNum == 1)
        {
            //increase border
            gameObject.GetComponent<CameraControl>().minMapBorderX = 90f;
            gameObject.GetComponent<CameraControl>().minMapBorderY = 65f;
            //increase zoom out
            gameObject.GetComponent<CameraControl>().maxCameraDistance = 14.0f;           
            //increase scroll speed
            gameObject.GetComponent<CameraControl>().scrollSpeed += 0.5f;

            //enable Town
            Group2.SetActive(true);

        }
        else if(dayNum == 2)
        {
            gameObject.GetComponent<CameraControl>().maxMapBorderX = 100f;
            gameObject.GetComponent<CameraControl>().minMapBorderY = 115f;           
            gameObject.GetComponent<CameraControl>().maxMapBorderY = 35f;

            gameObject.GetComponent<CameraControl>().maxCameraDistance = 18.0f;
           
            gameObject.GetComponent<CameraControl>().scrollSpeed += 1.0f;

            //enable towns
            Group3.SetActive(true);
        }
        else if (dayNum == 3)
        {
            gameObject.GetComponent<CameraControl>().minMapBorderX = 140f;         
            gameObject.GetComponent<CameraControl>().maxMapBorderX = 195f;
            gameObject.GetComponent<CameraControl>().minMapBorderY = 125f;
            gameObject.GetComponent<CameraControl>().maxMapBorderY = 45f;

            gameObject.GetComponent<CameraControl>().maxCameraDistance += 18f;

            gameObject.GetComponent<CameraControl>().scrollSpeed += 2.0f;

            Group4.SetActive(true);

        }
        else if(dayNum == 4)
        {
            gameObject.GetComponent<CameraControl>().maxMapBorderY += 50f;

            gameObject.GetComponent<CameraControl>().maxCameraDistance += 10f;

            Group5.SetActive(true);
            
        }
        else if(dayNum == 5)
        {
            gameObject.GetComponent<CameraControl>().minMapBorderX += 170f;
            gameObject.GetComponent<CameraControl>().maxMapBorderX += 5f;
            gameObject.GetComponent<CameraControl>().minMapBorderY += 30f;
            gameObject.GetComponent<CameraControl>().maxMapBorderY += 100f;

            gameObject.GetComponent<CameraControl>().maxCameraDistance += 20f;

            gameObject.GetComponent<CameraControl>().scrollSpeed += 5.0f;

            Group6.SetActive(true);
        }
        

        Debug.Log("Border is Expanded");
    }
}
