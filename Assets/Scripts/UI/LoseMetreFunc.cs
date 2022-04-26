using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseMetreFunc : MonoBehaviour
{
    public static float LoseMetreAmount;
    public Slider sldrMetre;

    public int BlackoutScore;

    public float PowerWastedNum;

    public GameObject BlackoutText;
    public GameObject PowerWastedText;

    // Start is called before the first frame update
    void Start()
    {
        LoseMetreAmount = 0;
        CheckForFailState();
    }

    // Update is called once per frame
    void Update()
    { 
        UpdateMetre();
        UpdateText();
        CheckForFailState();
    }

    void UpdateMetre()
    {
        LoseMetreAmount = BlackoutScore + PowerWastedNum;

        //set LoseMetreAmount to Slider amount
        sldrMetre.value = LoseMetreAmount;
        
    }

    public void UpdateBlackouts()
    {
        BlackoutScore++;             
    }

    public void UpdateBlackoutText(int BlackoutNumsLive)
    {
        BlackoutText.GetComponent<TextMeshProUGUI>().text = BlackoutNumsLive.ToString();
    }

    public void UpdatePowerWastedNum(float PowerWastedIn)
    {
        PowerWastedNum = PowerWastedIn;
        float i = 0;

        for(i = 0; i < PowerWastedNum; i++)
        {
            i += 5;
        }      
        
    }

    public void UpdatePowerWastedText()
    {
        PowerWastedText.GetComponent<TextMeshProUGUI>().text = PowerWastedNum.ToString("0.00");
    }

    void CheckForFailState()
    {
        //if lose metre is filled up
        if(sldrMetre.value == sldrMetre.maxValue)
        {
            //display game over screen
            Camera.main.GetComponent<GameOverHandler>().SetFinalTime();      
        }
    }
}
