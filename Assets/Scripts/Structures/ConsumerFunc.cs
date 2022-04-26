using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsumerFunc : MonoBehaviour
{
    //how much power the structure uses
    public float PowerUsage = 0;
    //how much power the structure receives
    public float PowerIntake = 0;

    public GameObject txtPowerUsage;

    private Coroutine InProgress;
    private BuildPowerLine buildPL;

    public bool isBlackout;

    // Start is called before the first frame update
    void Start()
    {
        isBlackout = false;
        InProgress = StartCoroutine(ConsumePower());
        buildPL = Camera.main.GetComponent<BuildPowerLine>();
        txtPowerUsage.GetComponent<TextMeshProUGUI>().text = PowerUsage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    IEnumerator ConsumePower()
    {      
        while(true)
        {
            yield return new WaitForSeconds(5.0f * ClockScript.speed);

            if(PowerUsage > 0)
            {
                //if house is connected
                if (PowerIntake >= PowerUsage)
                {
                    isBlackout = false;
                    //
                    PowerIntake = PowerIntake - PowerUsage;

                    Debug.Log("FeedPower");
                    //keep house on, increase score
                }
                else
                {

                    isBlackout = true;
                    //turn off house and reduce score
                    Camera.main.GetComponent<LoseMetreFunc>().UpdateBlackouts();

                    Debug.Log("WastedPower");
                }
                txtPowerUsage.GetComponent<TextMeshProUGUI>().text = PowerUsage.ToString("0.00");
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
