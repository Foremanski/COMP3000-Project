using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //UI Elements
    public Slider slider;
    public Button btnPowerUp;

   
    private Coroutine InProgress;
    private BuildPowerLine buildPL;

    // Start is called before the first frame update
    void Start()
    {
        buildPL = Camera.main.GetComponent<BuildPowerLine>();

        isActivated = false;
        isConnected = false;
    }

    public void OnValueChanged(float SliderAmount)
    {
        generatorAmount = slider.value;
    }


    IEnumerator ProducePower()
    {
        while(true)
        {      
            yield return new WaitForSeconds(3.0f);
    
            if(isConnected == true)
            {

                //calculate output
                powerOutput = basePower * generatorAmount;

                //send output to power line
                powerLine.GetComponent<PowerLineFunc>().heldPower = powerOutput;

                //reset output
                powerOutput = 0;
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
            //btnPowerUp.GetComponentInChildren<Text>().text = "Powering Up..";
            //btnPowerUp.GetComponentInChildren<Image>().color = Color.red;

            yield return new WaitForSeconds(5.0f);

            //btnPowerUp.GetComponentInChildren<Text>().text = "Power Down";

            isActivated = true;

            Debug.Log("Activate");

            InProgress = StartCoroutine(ProducePower());
        }
        else
        {            
            //change button properties
            //btnPowerUp.GetComponentInChildren<Text>().text = "Powering Down..";
            //btnPowerUp.GetComponentInChildren<Image>().color = Color.blue;

            yield return new WaitForSeconds(3.0f);
            //btnPowerUp.GetComponentInChildren<Text>().text = "Power Up";
            isActivated = false;

            StopCoroutine(InProgress);
        }
    }

    //set first structure as factory
    private void OnMouseUp()
    {
        //sets current clicked gameobject to beginning of power line
        if (BuildingHandler.PowerLineMode == true)
        {
            //set factory to power line location
            buildPL.SetBuildInfo(gameObject);
            
            //if first position hasn't been set
            if (buildPL.Position1Set == false)
            {                               
                buildPL.GeneratePowerLine();
                buildPL.SetPosition1();

                //sets factory subject to new powerline
                powerLine = buildPL.newPowerLine;

                isConnected = true;
            }             
        }
    }

    private void OnMouseOver()
    {
        if(BuildingHandler.PowerLineMode == true)
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