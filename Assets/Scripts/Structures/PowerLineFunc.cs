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

    private Coroutine InProgress;

    // Start is called before the first frame update
    void Start()
    {
        InProgress = StartCoroutine(SendPower());
    }

    // Update is called once per frame
    void Update()
    {
        if (heldPower > 0.0f)
        {
            //play animation
        }

        else
        {
            //play animation
        }
    }

    IEnumerator SendPower()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f * ClockScript.speed);

            if(heldPower > 0)
            {            
                if (highPower == true)
                {
                    //take away 10% power
                    sentPower = heldPower * 0.9f;

                }

                else
                {
                    //take away 30% of power
                    sentPower = heldPower * 0.8f;
                }

                heldPower = 0;

                //send power to node/transformer/house
                if(PowerNode.GetComponent<PowerNodeFunc>() != null)
                {
                    PowerNode.GetComponent<PowerNodeFunc>().heldPower += sentPower;
                    if(PowerNode.GetComponent<PowerNodeFunc>().PowerLineIn = null)
                    {
                        PowerNode.GetComponent<PowerNodeFunc>().PowerLineIn = gameObject;
                    }                  
                }
                else if(PowerNode.GetComponent<TransformerFunc>() != null)
                {
                    PowerNode.GetComponent<TransformerFunc>().heldPower += sentPower;
                    if (PowerNode.GetComponent<PowerNodeFunc>().PowerLineIn = null)
                    {
                        PowerNode.GetComponent<PowerNodeFunc>().PowerLineIn = gameObject;
                    }
                }
                else
                {
                    PowerNode.GetComponent<ConsumerFunc>().PowerIntake = sentPower;
                }               
            }
        }       
    }
}
