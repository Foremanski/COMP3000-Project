using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerNodeFunc : MonoBehaviour
{
    public List<GameObject> PowerSubjects;

    public float heldPower;

    private BuildPowerLine buildPL;

    // Start is called before the first frame update
    void Start()
    {
        buildPL = Camera.main.GetComponent<BuildPowerLine>();
    }

    // Update is called once per frame
    void Update()
    {
        if(heldPower > 0)
        {
            if(PowerSubjects.Count > 1)
            {
                SplitPower();
            }
            else
            {
                for(int i = 0; i < PowerSubjects.Count; i++)
                {
                    PowerSubjects[i].GetComponent<PowerLineFunc>().heldPower = heldPower;
                }
            }
        }
    }



    public void SplitPower()
    {
        Debug.Log("You ain't supposed to be here");
    }

    //building
    private void OnMouseUp()
    {
        if (BuildingHandler.PowerLineMode == true)
        {
            buildPL.SetBuildInfo(gameObject);
            buildPL.GeneratePowerLine();
            buildPL.SetPosition1();

            PowerSubjects.Add(buildPL.newPowerLine);
        }
        else
        {
            //display UI
        }
    }
}
