using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProducerFunc : MonoBehaviour
{
    //how much power is produced at minimum
    public float basePower;
    //changeable output percentage
    public float generatorAmount;
    //final power output
    private float powerOutput;
    public float powerOutputBackup;
    //powerlines
    public GameObject powerLine;
    //check whether factory is turned on/linked to power line
    private bool isActivated;

    //UI Elements
    public Slider slider;
    public Button btnPowerUp;
    public GameObject txtPowerOutput;

    private Coroutine InProgress;
    private BuildPowerLine buildPL;

    // Start is called before the first frame update
    void Start()
    {
        buildPL = Camera.main.GetComponent<BuildPowerLine>();

        isActivated = false;
    }

    void Update()
    {
        //update text element
        txtPowerOutput.GetComponent<TextMeshProUGUI>().text = powerOutput.ToString("000");
    }

    public void OnValueChanged(float SliderAmount)
    {
        generatorAmount = slider.value;
    }

    IEnumerator ProducePower()
    {
        while(true)
        {      
            yield return new WaitForSeconds(3.0f * ClockScript.speed);
    
            if(powerLine != null)
            {
                //reset output
                powerOutput = 0;

                //calculate output
                powerOutput = basePower * generatorAmount;
                powerOutputBackup = powerOutput;            

                //send output to power line
                powerLine.GetComponent<PowerLineFunc>().heldPower = powerOutput;
            }

            else
            {
               //play wasted electricity anim
                Debug.Log("yo");
            }
        }
    }

    public void PowerUpCoRoutine()
    {
        StartCoroutine(ActivatePower());

    }

    private IEnumerator ActivatePower()
    {
        if(isActivated == false)
        {
            btnPowerUp.GetComponentInChildren<TextMeshProUGUI>().text = "Powering Up..";
            //btnPowerUp.GetComponentInChildren<Image>().color = Color.red;

            yield return new WaitForSeconds(5.0f * ClockScript.speed);

            btnPowerUp.GetComponentInChildren<TextMeshProUGUI>().text = "Power Down";

            isActivated = true;

            Debug.Log("Activate");

            InProgress = StartCoroutine(ProducePower());
        }
        else
        {            
            //change button properties
            btnPowerUp.GetComponentInChildren<TextMeshProUGUI>().text = "Powering Down..";

            yield return new WaitForSeconds(3.0f * ClockScript.speed);

            btnPowerUp.GetComponentInChildren<TextMeshProUGUI>().text = "Power Up";

            isActivated = false;

            StopCoroutine(InProgress);
        }
    }
}