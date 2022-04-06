using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{


    public static bool PowerLineMode;
    public static Vector3 PowerLineLocation;

    public GameObject newPowerLine;
    private GameObject newPowerNode;
    public GameObject PowerLinePrefab;
    public GameObject PowerNodePrefab;

    public bool Position1Set = false;
    private Vector3 mousePosition;

    public float maxLength;
    private float lineLength;

    public bool StructureClicked = false;

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
            

            if (Input.GetMouseButtonDown(0))
            {
                //if another structure has been clicked on
                if (StructureClicked == true)
                {
                    newPowerLine.GetComponent<LineRenderer>().SetPosition(1, PowerLineLocation);
                }
                else
                {
                    //build & position power node
                    newPowerNode = Instantiate(PowerNodePrefab);                    
                    newPowerNode.transform.position = new Vector3(newPowerLine.GetComponent<LineRenderer>().GetPosition(1).x, newPowerLine.GetComponent<LineRenderer>().GetPosition(1).y, 0.0f);
                    //connect node to power line
                    newPowerLine.GetComponent<PowerLineFunc>().PowerNode = newPowerNode;
                }
                //turn off build mode
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
