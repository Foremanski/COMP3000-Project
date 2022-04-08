using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformerFunc : MonoBehaviour
{
    public float HeldPower;
    private BuildPowerLine buildPL;
    public GameObject PowerLineIn;
    public GameObject PowerLineOut;
    private bool isConnected;

    // Start is called before the first frame update
    void Start()
    {
        buildPL = Camera.main.GetComponent<BuildPowerLine>();
        isConnected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (BuildingHandler.PowerLineMode == true && isConnected == false)
        {
            //set factory to power line location
            buildPL.SetBuildInfo(gameObject);

            //if first position hasn't been set
            if (buildPL.Position1Set == false)
            {
                buildPL.GeneratePowerLine();
                buildPL.SetPosition1();

                InvertPower();               
                //sets factory subject to new powerline
                PowerLineOut = buildPL.newPowerLine;
                isConnected = true;
            }
        }
    }

    private void InvertPower()
    {
        if(PowerLineIn.GetComponent<PowerLineFunc>().highPower == false)
        {
            buildPL.newPowerLine.GetComponent<PowerLineFunc>().highPower = true;
        }
        else
        {
            buildPL.newPowerLine.GetComponent<PowerLineFunc>().highPower = false;
        }
    }


    private void OnMouseOver()
    {
        if (BuildingHandler.PowerLineMode == true)
        {
            //set factory pos to power line location
            buildPL.SetBuildInfo(gameObject);


            //if first position has been set
            if (buildPL.Position1Set == true)
            {
                buildPL.StructureClicked = true;

                PowerLineIn = buildPL.newPowerLine;
            }
        }
    }

    private void OnMouseExit()
    {
        buildPL.StructureClicked = false;
    }
}
