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
            SendPower();
        }
    }

    void SendPower()
    {
        PowerLineOut.GetComponent<PowerLineFunc>().heldPower = heldPower;
        txtSentPower.GetComponent<TextMeshProUGUI>().text = heldPower.ToString();
        heldPower = 0;
    }

    

    public void InvertPower()
    {
        if(PowerLineIn.GetComponent<PowerLineFunc>().highPower == false)
        {
            PowerLineOut.GetComponent<PowerLineFunc>().highPower = true;
        }
        else
        {
            PowerLineOut.GetComponent<PowerLineFunc>().highPower = false;
        }
    }
    
}
