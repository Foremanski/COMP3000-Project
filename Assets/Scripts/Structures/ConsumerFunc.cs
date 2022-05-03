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
    public GameObject txtPowerIntake;
    public GameObject PowerLineIn;

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

    IEnumerator ConsumePower()
    {      
        while(true)
        {
            yield return new WaitForSeconds(5.0f * ClockScript.speed);

            txtPowerIntake.GetComponent<TextMeshProUGUI>().text = PowerIntake.ToString("0.00");
            txtPowerUsage.GetComponent<TextMeshProUGUI>().text = PowerUsage.ToString("0.00");

            if (PowerUsage > 0)
            {              
                //if power is flowing into the house
                if (PowerIntake >= PowerUsage)
                {
                    isBlackout = false;
                    //Debug.Log("PowerFed");
                }
                else
                {
                    //blackout house, reduce score
                    isBlackout = true;
                    //Debug.Log("BlackOut");
                }
                     
            }
               
        }      
    }
}
