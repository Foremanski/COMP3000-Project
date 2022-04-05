using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryFunc : MonoBehaviour
{
    public Camera MainCamera;

    //how much power is produced at minimum
    public float basePower;
    //changeable output percentage
    public float generatorAmount;
    //final power output
    private float powerOutput;
    //powerlines
    public GameObject powerLine;

    private Coroutine InProgress;


    public Button btnPowerUp;

    //check whether factory is turned on/linked to power line
    private bool isActivated, isConnected;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;

        isActivated = false;
        isConnected = false;
    }

    // Update is called once per frame

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

    private void OnMouseDown()
    {
        //sets current clicked gameobject to beginning of power line
        if (BuildingHandler.PowerLineMode == true)
        {
            //set factory pos to power line location
            BuildingHandler.PowerLineLocation = gameObject.transform.position;

            //sets factory subject to new powerline
            gameObject.GetComponent<FactoryFunc>().powerLine = MainCamera.GetComponent<BuildingHandler>().newPowerLine;

            MainCamera.GetComponent<BuildingHandler>().SetPosition1();

          
        }
    }
}