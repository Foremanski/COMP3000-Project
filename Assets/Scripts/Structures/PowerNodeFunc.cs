using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerNodeFunc : MonoBehaviour
{
    public List<GameObject> PowerSubjects;

    public float heldPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnMouseUp()
    {
        if(BuildingHandler.PowerLineMode == true)
        {
            BuildingHandler.PowerLineLocation = gameObject;
            gameObject.GetComponent<PowerNodeFunc>().PowerSubjects.Add(Camera.main.GetComponent<BuildingHandler>().newPowerLine);

            Camera.main.GetComponent<BuildingHandler>().SetPosition1();
        }
        else
        {
            //display UI
        }
    }

    public void SplitPower()
    {

    }
}
