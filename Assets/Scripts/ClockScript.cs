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


    public GameObject textTarget;
    // Start is called before the first frame update
    void Start()
    {
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
                    day++;
                    hour = 0;
                }
            }
            textTarget.GetComponent<TextMeshProUGUI>().text = hour.ToString("00") + ":" + minute.ToString("00");
        }
    }
}
