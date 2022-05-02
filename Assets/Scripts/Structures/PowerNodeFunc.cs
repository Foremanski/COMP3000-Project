using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerNodeFunc : MonoBehaviour
{
    public GameObject PowerLineIn;
    public List<GameObject> PowerSubjects;
    public List<GameObject> sliders;

    public float heldPower;

    public GameObject txtInitialReading;
    public GameObject txtDistributedPower;

    [SerializeField]
    private GameObject slider1, slider2, slider3;
    public GameObject imgHighPower;
    public GameObject imgLowPower;

    private float sliderOrigin;

    // Start is called before the first frame update
    void Start()
    {
        sliders.Add(slider1);
        sliders.Add(slider2);
        sliders.Add(slider3);
    }

    // Update is called once per frame
    void Update()
    {

        if (heldPower > 0 && PowerSubjects.Count > 0)
        {
            
            setMaxValue();

            DistributePower();     
            
            

            //turn colour blue
        }
        else
        {
            //turn colour red
        }
    }


    void setMaxValue()
    {
        float percentageNum;
        for (int i = 0; i < PowerSubjects.Count; i++)
        {
            if (heldPower > 0)
            {
                //get percentage fill of slider
                percentageNum = sliders[i].GetComponent<Slider>().value / sliders[i].GetComponent<Slider>().maxValue;
                //set new max value
                sliders[i].GetComponent<Slider>().maxValue = heldPower;
                //scale sldier to match percentage
                sliders[i].GetComponent<Slider>().value = sliders[i].GetComponent<Slider>().maxValue * percentageNum;
            }
            else
            {
                sliders[i].GetComponent<Slider>().maxValue = 1.0f;
            }
        }

    }


    void DistributePower()
    {
        //split power to number of lines connected
        for (int i = 0; i < PowerSubjects.Count; i++)
        {
            PowerSubjects[i].GetComponent<PowerLineFunc>().heldPower = sliders[i].GetComponent<Slider>().value;
        }

        DisplayText();

        //reset held power
        heldPower = 0;
    }

    void DisplayText()
    {
        //update text elements
        txtInitialReading.GetComponent<TextMeshProUGUI>().text = heldPower.ToString("00.00");

        for (int i = 0; i < PowerSubjects.Count; i++)
        {
            //check if more than one powerline
            if (PowerSubjects.Count > 0)
            {
                sliders[i].GetComponentInChildren<TextMeshProUGUI>().text = sliders[i].GetComponent<Slider>().value.ToString("00.00");
            }

            else
            {
                sliders[i].GetComponentInChildren<TextMeshProUGUI>().text = heldPower.ToString("00.00");
            }
        }            
    }

    public void setSliderOrigin(GameObject slider)
    {
        sliderOrigin = slider.GetComponent<Slider>().value;
        Debug.Log("SET");
        Debug.Log(sliderOrigin);
    }

    public void updateSliderValues(Slider slider)
    {       

        for(int i = 0; i < PowerSubjects.Count; i++)
        {
            if(sliders[i].GetComponent<Slider>() != slider)
            {
                sliders[i].GetComponent<Slider>().value += ((sliderOrigin - slider.value) / (PowerSubjects.Count - 1));            
            }
            sliders[i].GetComponentInChildren<TextMeshProUGUI>().text = sliders[i].GetComponent<Slider>().value.ToString("00.00");
            Debug.Log((sliderOrigin - slider.value));
        }
    }

    public void AddNewSlider()
    {

        //enable sliders
        for (int i = 0; i < PowerSubjects.Count; i++)
        {
            sliders[i].SetActive(true);
            
        }

        //set max value and reset slider values
        setMaxValue();
        for (int i = 0; i < PowerSubjects.Count; i++)
        {
            if(PowerSubjects.Count > 1)
            {
                sliders[i].GetComponent<Slider>().value = sliders[i].GetComponent<Slider>().maxValue / 2;
            }
            else
            {
                sliders[i].GetComponent<Slider>().value = sliders[i].GetComponent<Slider>().maxValue;
            }
        }
    }
}
