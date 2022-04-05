using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    public static bool PowerLineMode;
    public static Vector3 PowerLineLocation;

    public GameObject newPowerLine;
    public GameObject PowerLinePrefab;
    bool Position1Set = false;
    private Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        PowerLineMode = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(PowerLineMode == true && Position1Set == true)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            newPowerLine.GetComponent<LineRenderer>().SetPosition(1, mousePosition);
                      
            if(Input.GetMouseButtonDown(1))
            {
               //turn off power line mode and reset
               PowerLineMode = false;
               Position1Set = false;
            }
        }
    }

    public void BuildPowerLine()
    {
        PowerLineMode = true;

        //instantiate new power line game object
        

        newPowerLine = Instantiate(PowerLinePrefab);

    }

    public void SetPosition1()
    {  
        
        //set first point to factory transform
        newPowerLine.GetComponent<LineRenderer>().SetPosition(0, PowerLineLocation);
        Position1Set = true;
    }
}
