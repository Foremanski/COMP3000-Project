using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerNodeFunc : MonoBehaviour
{
    public GameObject PowerLineIn;
    public List<GameObject> PowerSubjects;
    public List<Slider> sliders;

    public float heldPower;

    public GameObject txtInitialReading;
    public GameObject txtDistributedPower;

    private BuildPowerLine buildPL;

    // Start is called before the first frame update
    void Start()
    {
        buildPL = Camera.main.GetComponent<BuildPowerLine>();
    }

    // Update is called once per frame
    void Update()
    {

        if (heldPower > 0)
        {

            DistributePower();           
            //turn colour blue
        }
        else
        {
            //turn colour red
        }
    }

    void setmaxValue()
    {
        for(int i = 0; i < sliders.Count; i++)
        {
            sliders[i].maxValue = heldPower / sliders.Count;
        }
    }


    void DistributePower()
    {



        //split power to number of lines connected
        for (int i = 0; i < PowerSubjects.Count; i++)
        {
            PowerSubjects[i].GetComponent<PowerLineFunc>().heldPower = sliders[i].value;
        }


        //update text elements
        txtInitialReading.GetComponent<TextMeshProUGUI>().text = heldPower.ToString("00.00");

        DisplayText();

        //reset held power
        heldPower = 0;
    }

    void DisplayText()
    {
        //check if more than one powerline
        if (PowerSubjects.Count > 1)
        {
            txtDistributedPower.GetComponent<TextMeshProUGUI>().text = (heldPower / PowerSubjects.Count).ToString("00.00");
        }
        else
        {
            txtDistributedPower.GetComponent<TextMeshProUGUI>().text = heldPower.ToString("00.00");
        }
    }

    public void updateSliderValues(float sliderValue)
    {
       
    }
}
