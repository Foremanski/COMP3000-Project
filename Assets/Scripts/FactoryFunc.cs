using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryFunc : MonoBehaviour
{
    //how much power is produced at minimum
    public float basePower;
    //changeable output percentage
    public float generatorAmount;
    //final power output
    private float powerOutput;
    //powerlines
    public GameObject powerLine;

    //check whether factory is turned on/linked to power line
    private bool isActivated, isConnected;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        isConnected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isActivated == true)
        {
            ProducePower();
        }
    }

    IEnumerator ProducePower()
    {
        yield return new WaitForSeconds(5);

        if(isConnected == true)
        {

            //calculate output
            powerOutput = basePower * generatorAmount;

            //send output to power line
            powerLine.GetComponent<PowerLineFunc>().heldPower = powerOutput;
        }

        else
        {
            //play wasted electricity anim
        }
    }
}
