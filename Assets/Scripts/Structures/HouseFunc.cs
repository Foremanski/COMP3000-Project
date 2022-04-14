using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFunc : MonoBehaviour
{
    //how much power the structure uses
    public float PowerUsage = 0;
    //how much power the structure receives
    public float PowerIntake = 0;

    private Coroutine InProgress;
    private BuildPowerLine buildPL;

    // Start is called before the first frame update
    void Start()
    {
        InProgress = StartCoroutine(ConsumePower());
        buildPL = Camera.main.GetComponent<BuildPowerLine>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    IEnumerator ConsumePower()
    {      
        while(true)
        {
            yield return new WaitForSeconds(5.0f * -ClockScript.speed);

            //if house is connected
            if (PowerIntake >= PowerUsage)
            {
                //
                PowerIntake = PowerIntake - PowerUsage;

                Debug.Log("FeedPower");
                //keep house on, increase score
            }
            else
            {
                //turn off house and reduce score
                Debug.Log("WastedPower");
            }
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
            }
        }
    }

    private void OnMouseExit()
    {
        buildPL.StructureClicked = false;
    }
}
