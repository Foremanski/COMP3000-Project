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
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Button btnPowerUp;
    [SerializeField]
    private GameObject txtPowerOutput;

    private Coroutine InProgress;
    private BuildPowerLine buildPL;

    // Start is called before the first frame update
    void Start()
    {
        powerOutput = 0;
        buildPL = Camera.main.GetComponent<BuildPowerLine>();

        isActivated = false;
    }

    void Update()
    {

    }

    public void OnValueChangedSlider(float SliderAmount)
    {
        generatorAmount = slider.value;
        txtPowerOutput.GetComponent<TMP_InputField>().text = slider.value.ToString();
        Camera.main.GetComponent<CameraControl>().overUI = true;
    }
    public void OnValueCHangedInputField()
    {
        generatorAmount = float.Parse(txtPowerOutput.GetComponent<TMP_InputField>().text);
        slider.value = float.Parse(txtPowerOutput.GetComponent<TMP_InputField>().text);
    }

    IEnumerator ProducePower()
    {
        while(true)
        {      
            yield return new WaitForSeconds(1.0f * ClockScript.speed);
    
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

            //play sound effect
            Camera.main.GetComponent<SoundEffectHandler>().PlayPowerStationActivate();

            yield return new WaitForSeconds(5.0f * ClockScript.speed);

            btnPowerUp.GetComponentInChildren<TextMeshProUGUI>().text = "Power Down";

            isActivated = true;

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