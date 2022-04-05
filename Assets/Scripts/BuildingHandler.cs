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

    public float maxLength;
    private float lineLength;

    // Start is called before the first frame update
    void Start()
    {
        PowerLineMode = false;
        maxLength = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(PowerLineMode == true && Position1Set == true)
        {
            //get mouse position
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            //get length between power line start and mouse pos
            lineLength = Vector2.Distance(newPowerLine.GetComponent<LineRenderer>().GetPosition(0), mousePosition);

            //check if length of powerline is under max length
            if(lineLength < maxLength)
            {           
                //update second point
                newPowerLine.GetComponent<LineRenderer>().SetPosition(1, mousePosition);
            }
            
            //Right mouse click - turn off build mode and reset pos
            if (Input.GetMouseButtonDown(1))
            {
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
        newPowerLine.GetComponent<LineRenderer>().SetPosition(1, PowerLineLocation);
        Position1Set = true;
    }
}
