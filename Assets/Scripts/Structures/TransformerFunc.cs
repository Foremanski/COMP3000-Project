using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransformerFunc : MonoBehaviour
{
    public float heldPower;
    private BuildPowerLine buildPL;
    public GameObject PowerLineIn;
    public GameObject PowerLineOut;
    public GameObject txtSentPower;
    private bool isConnected;

    // Start is called before the first frame update
    void Start()
    {
        buildPL = Camera.main.GetComponent<BuildPowerLine>();
        isConnected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(heldPower > 0)
        {
            SendPower();
        }
    }

    void SendPower()
    {
        PowerLineOut.GetComponent<PowerLineFunc>().heldPower = heldPower;
        txtSentPower.GetComponent<TextMeshProUGUI>().text = heldPower.ToString();
        heldPower = 0;
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
    
    //set power line Out
    private void OnMouseUp()
    {
        //sets current clicked gameobject to beginning of power line
        if (BuildingHandler.PowerLineMode == true && isConnected == false)
        {
            //set transformer to power line location
            buildPL.SetBuildInfo(gameObject);

            //if first position hasn't been set
            if (buildPL.Position1Set == false)
            {
                buildPL.GeneratePowerLine();
                buildPL.SetPosition1();

                //sets factory subject to new powerline
                PowerLineOut = buildPL.newPowerLine;

                isConnected = true;
            }
        }
    }
    //set power line in
    private void OnMouseOver()
    {
        if (BuildingHandler.PowerLineMode == true && buildPL.Position1Set == true)
        {
            buildPL.StructureClicked = true;
            //set transformer pos to power line location
            buildPL.SetBuildInfo(gameObject);
            if(buildPL.Position1Set == true)
            {
                PowerLineIn = buildPL.newPowerLine;
            }            
        }
    }

    private void OnMouseExit()
    {
        buildPL.StructureClicked = false;
    }

    private void OnMouseDown()
    {
        if(isConnected == false)
        {
            isConnected = true;
        }
        else
        {
            isConnected = false;
        }
    }
}
