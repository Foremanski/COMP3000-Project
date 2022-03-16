using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    public static bool PowerLineMode;
    public static GameObject PowerLineLocation;

    public GameObject newPowerLine;


    // Start is called before the first frame update
    void Start()
    {
        PowerLineMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildPowerLine()
    {
        PowerLineMode = true;

        //instantiate new power line game object
        Instantiate(newPowerLine);
    }

    public void SetPositions()
    {
        //set first point of line to structure location
        newPowerLine.GetComponent<LineRenderer>().SetPosition(0, PowerLineLocation.transform.position);
        newPowerLine.GetComponent<LineRenderer>().SetPosition(1, PowerLineLocation.transform.position + PowerLineLocation.transform.position);

        //attach line to mouse position until click
        /*while (PowerLineMode == true)
        {
            testPowerLine.GetComponent<LineRenderer>().SetPosition(1, Input.mousePosition);

            if(Input.GetMouseButtonDown(1))
            {
                //set up power line here

                break;
            }
        } */
    }
}
