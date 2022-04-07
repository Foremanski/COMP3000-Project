using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPowerLine : MonoBehaviour
{
    private GameObject PowerLineLocation;

    public GameObject newPowerLine;
    private GameObject newPowerNode;
    public GameObject PowerLinePrefab;
    public GameObject PowerNodePrefab;

    public float maxLength;
    private float lineLength;

    private Vector3 mousePosition;
    public bool StructureClicked = false;

    public bool Position1Set = false;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildingHandler.PowerLineMode == true && Position1Set == true)
        {
            //get mouse position
            GetMousePos();

            //get length between power line start and mouse pos
            lineLength = Vector2.Distance(newPowerLine.GetComponent<LineRenderer>().GetPosition(0), mousePosition);

            //check if length of powerline is under max length
            if (lineLength < maxLength)
            {
                //update second point
                newPowerLine.GetComponent<LineRenderer>().SetPosition(1, mousePosition);
            }
            //check for click
            if (Input.GetMouseButtonDown(0))
            {
                SetPosition2();
            }
        }
    }

    private void GetMousePos()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    //retrieves GameObject info
    public void SetBuildInfo(GameObject gameObject)
    {
        PowerLineLocation = gameObject;
    }

    //instantiate new power line gameobject
    public void GeneratePowerLine()
    {      
        newPowerLine = Instantiate(PowerLinePrefab);
    }


    private void BuildNode()
    {
        //build & position power node
        newPowerNode = Instantiate(PowerNodePrefab);
        newPowerNode.transform.position = new Vector3(newPowerLine.GetComponent<LineRenderer>().GetPosition(1).x, newPowerLine.GetComponent<LineRenderer>().GetPosition(1).y, 0.0f);
        //connect node to power line
        newPowerLine.GetComponent<PowerLineFunc>().PowerNode = newPowerNode;
    }
    //-------------------------------------
    //set Line Rendender and Node Positions
    //-------------------------------------
    public void SetPosition1()
    {
        //set first point to factory transform
        newPowerLine.GetComponent<LineRenderer>().SetPosition(0, PowerLineLocation.transform.position);
        newPowerLine.GetComponent<LineRenderer>().SetPosition(1, PowerLineLocation.transform.position);
        Position1Set = true;
    }

    private void SetPosition2()
    {
        //if another structure has been clicked on
        if (StructureClicked == true)
        {
            newPowerLine.GetComponent<LineRenderer>().SetPosition(1, PowerLineLocation.transform.position);
            newPowerLine.GetComponent<PowerLineFunc>().PowerNode = PowerLineLocation;
        }
        else
        {
            BuildNode();
        }
        //turn off build mode
        Position1Set = false;
    }
}
