using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockScript : MonoBehaviour
{
    private Coroutine inProgress;

    public int day;
    public int hour;
    public int minute;
    public static float speed;

    private int counter;


    public GameObject textTarget;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;

        day = 0;
        hour = 0;
        minute = 0;

        speed = 1.0f;
        
        inProgress = StartCoroutine(Clock());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Clock()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f * speed);
            if (BuildingHandler.PowerLineMode == false)
            {
                if (minute < 59)
                {
                    //update UI clock
                    minute++;
                }
                else
                {
                    minute = 0;
                    //update UI clock

                    if (hour < 23)
                    {
                        hour++;
                    }
                    else
                    {

                        //add day to final time
                        day++;
                        //reset hours
                        hour = 0;
                        //expand border
                        gameObject.GetComponent<ExpandBorder>().ExpandBorderSize(day);
                    }
                }
            }           
            textTarget.GetComponent<TextMeshProUGUI>().text = hour.ToString("00") + ":" + minute.ToString("00");
        }
    }

    public void IncreaseSpeed()
    {
        
       if(counter <=3)
        {
            counter++;
            speed -= 0.2f;
            Debug.Log(speed);
        }
    }

    public void DecreaseSpeed()
    {
        if (counter >= -3)
        {
            counter--;
            speed += 0.2f;
            Debug.Log(speed);
        }      
    }
}
