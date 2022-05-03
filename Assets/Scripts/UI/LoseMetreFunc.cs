using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseMetreFunc : MonoBehaviour
{
    private Camera cam;
    private Coroutine inprogress;

    [SerializeField]
    private AudioSource MetreClear, MetreAlarm;

    //UI
    public Slider sldrMetre;

    //total score
    public static float LoseMetreAmount;
    
    //scores
    private int BlackoutScore;
    private float PowerWastedScore;
    private float TransmissionLossScore;

    //Text objects
    public GameObject BlackoutText;
    public GameObject PowerWastedText;
    public GameObject TransmissionLossText;

    //check for performance reset
    private bool BlackOutClear;
    private bool PowerWastedClear;
    private bool TransmissionLossClear;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        LoseMetreAmount = 0;

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
            yield return new WaitForSeconds(5.0f * ClockScript.speed);
            LoseMetreAmount += BlackoutScore + PowerWastedScore;

            //set LoseMetreAmount to Slider amount
            sldrMetre.value = LoseMetreAmount;

            if(sldrMetre.value > 70)
            {
                MetreAlarm.Play();
            }
        }        
    }

    void CheckForClearState()
    {
        if(BlackOutClear == true && PowerWastedClear == true)
        {
            //play clear audio
            if(sldrMetre.value > 30)
            {
                MetreClear.Play();
            }           
            sldrMetre.value = 0;
            LoseMetreAmount = 0;
        }
    }

    void CheckForFailState()
    {
        //if lose metre is filled up
        if (sldrMetre.value == sldrMetre.maxValue)
        {
            //display game over screen
            cam.GetComponent<GameOverHandler>().SetFinalTime();
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
            
        }
        BlackoutText.GetComponent<TextMeshProUGUI>().text = BlackoutNums.ToString("00");
    }

    //handles Wasted Power Score
    public void UpdatePowerWastedScore(float PowerWastedIn)
    {
        PowerWastedScore = 0;


        if (PowerWastedIn <= 0)
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
                    
        }

        if (PowerWastedIn > 0)
        {
            //update Text Element
            PowerWastedText.GetComponent<TextMeshProUGUI>().text = PowerWastedIn.ToString("0.00");
        }
        else
        {
            //update Text Element
            PowerWastedText.GetComponent<TextMeshProUGUI>().text = "0.00";
        }
    }   

    public void UpdateTransmissionLoss(float transmissionLossIn)
    {
        TransmissionLossScore = 0;

        if(TransmissionLossScore < 25)
        {
            TransmissionLossClear = true;
        }
        else
        {
            TransmissionLossClear = false;

            //calc transmission loss score
            TransmissionLossScore = transmissionLossIn / 10;            
        }

        if(transmissionLossIn > 0)
        {
            //update Text Element
            TransmissionLossText.GetComponent<TextMeshProUGUI>().text = transmissionLossIn.ToString("0.00");
        }
        else
        {
            //update Text Element
            TransmissionLossText.GetComponent<TextMeshProUGUI>().text = "0.00";
        }
    }
}
