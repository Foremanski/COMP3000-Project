using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseMetreFunc : MonoBehaviour
{
    public static float LoseMetreAmount;
    public Slider sldrMetre;

    // Start is called before the first frame update
    void Start()
    {
        CheckForFailState();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMetre();
        CheckForFailState();
    }

    void UpdateMetre()
    {
        //set LoseMetreAmount to Slider amount
        sldrMetre.value = LoseMetreAmount;
    }

    void CheckForFailState()
    {
        //if lose metre is filled up
        if(sldrMetre.value == sldrMetre.maxValue)
        {
            //display game over screen
        }

    }
}
