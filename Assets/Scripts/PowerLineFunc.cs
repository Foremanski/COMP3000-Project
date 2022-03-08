using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLineFunc : MonoBehaviour
{
    public GameObject PowerSubject;

    //amount of power given from first 
    public float heldPower;

    //
    public float sentPower;
    //whether 
    public bool highPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(heldPower > 0.0f)
        {
            SendPower();
        }
    }

    IEnumerator SendPower()
    {
        yield return new WaitForSeconds(3);

        if(highPower == true)
        {
            //power sent 
            sentPower = heldPower - (held)
        }

        else
        {

        }
    }
}
