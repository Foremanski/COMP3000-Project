using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLineFunc : MonoBehaviour
{
    //Subject that powerline is sent to
    public GameObject PowerNode;

    //amount of power given from first object
    public float heldPower;
    //power sent onwards
    public float sentPower;
    //whether power line transmits efficiently
    public bool highPower;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (heldPower > 0.0f)
        {
            SendPower();
        }
    }

    IEnumerator SendPower()
    {
        yield return new WaitForSeconds(1);

        if(highPower == true)
        {
            //take away 10% power
            sentPower = heldPower - (heldPower * 0.9f);
        }

        else
        {
            //take away 30% of power
            sentPower = heldPower - (heldPower * 0.6f);            
        }
    }
}
