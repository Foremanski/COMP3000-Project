using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerNodeFunc : MonoBehaviour
{
    public GameObject PowerLineIn;
    public List<GameObject> PowerSubjects;

    public float heldPower;

    public GameObject txtInitialReading;
    public GameObject txtDistributedPower;

    private BuildPowerLine buildPL;

    // Start is called before the first frame update
    void Start()
    {
        buildPL = Camera.main.GetComponent<BuildPowerLine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heldPower > 0)
        {
            DistributePower();
            
            //turn colour blue
        }
        else
        {
            //turn colour red
        }
    }

    void DistributePower()
    {
        //split power to number of lines connected
        for (int i = 0; i < PowerSubjects.Count; i++)
        {
            PowerSubjects[i].GetComponent<PowerLineFunc>().heldPower = heldPower / PowerSubjects.Count;
        }
        //update text elements
        txtInitialReading.GetComponent<TextMeshProUGUI>().text = heldPower.ToString("00.00");

        DisplayText();

        //reset held power
        heldPower = 0;
    }

    void DisplayText()
    {
        //check if more than one powerline
        if (PowerSubjects.Count > 1)
        {
            txtDistributedPower.GetComponent<TextMeshProUGUI>().text = (heldPower / PowerSubjects.Count).ToString("00.00");
        }
        else
        {
            txtDistributedPower.GetComponent<TextMeshProUGUI>().text = heldPower.ToString("00.00");
        }
    }

    //building
    private void OnMouseUp()
    {
        if (BuildingHandler.PowerLineMode == true)
        {
            buildPL.SetBuildInfo(gameObject);
            buildPL.GeneratePowerLine();
            buildPL.SetPosition1();

            buildPL.newPowerLine.GetComponent<PowerLineFunc>().highPower = PowerLineIn.GetComponent<PowerLineFunc>().highPower;
            PowerSubjects.Add(buildPL.newPowerLine);
        }
        else
        {
            //display UI
        }
    }
}
