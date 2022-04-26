using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseMetreFunc : MonoBehaviour
{
    private Coroutine inprogress;

    public static float LoseMetreAmount;
    public Slider sldrMetre;

    private int BlackoutScore;
    private float PowerWastedScore;

    public GameObject BlackoutText;
    public GameObject PowerWastedText;

    private bool BlackOutClear;
    private bool PowerWastedClear;

    // Start is called before the first frame update
    void Start()
    {
        LoseMetreAmount = 0;
        CheckForFailState();

        inprogress = StartCoroutine(UpdateMetre());
    }

    // Update is called once per frame
    void Update()
    { 
        UpdateMetre();
        CheckForClearState();
        CheckForFailState();
    }

    IEnumerator UpdateMetre()
    {
        while(true)
        {
            yield return new WaitForSeconds(4.0f);
            LoseMetreAmount += BlackoutScore + PowerWastedScore;

            //set LoseMetreAmount to Slider amount
            sldrMetre.value = LoseMetreAmount;
        }        
    }

    void CheckForClearState()
    {
        if(BlackOutClear == true && PowerWastedClear == true)
        {
            sldrMetre.value = 0;
        }
    }

    void CheckForFailState()
    {
        //if lose metre is filled up
        if (sldrMetre.value == sldrMetre.maxValue)
        {
            //display game over screen
            Camera.main.GetComponent<GameOverHandler>().SetFinalTime();
        }
    }

    //----------------------------------

    //handles blackout score
    public void UpdateBlackoutScore(int BlackoutNums)
    {
        if (BlackoutNums == 0)
        {
            BlackOutClear = true;
        }
        else
        {
            BlackOutClear = false;

            //set Score
            BlackoutScore = BlackoutNums;
            //Display Text
            BlackoutText.GetComponent<TextMeshProUGUI>().text = BlackoutNums.ToString("00");
        }              
    }


    //handles Wasted Power Score
    public void UpdatePowerWastedScore(float PowerWastedIn)
    {
        PowerWastedScore = 0;


        if (PowerWastedIn == 0)
        {
            PowerWastedClear = true;
        }
        else
        {
            PowerWastedClear = false;

            //every units, increase score
            for (float i = 0; i < PowerWastedIn; i += 5)
            {
                PowerWastedScore++;
            }
            //update Text Element
            PowerWastedText.GetComponent<TextMeshProUGUI>().text = PowerWastedIn.ToString("0.00");
        }        
    }   
}
