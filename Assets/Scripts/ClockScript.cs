using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockScript : MonoBehaviour
{
    private Coroutine inProgress;
    public int hour;
    public int minute;

    public GameObject textTarget;
    // Start is called before the first frame update
    void Start()
    {
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
            yield return new WaitForSeconds(1.0f);

            if (minute < 59)
            {
                //update UI clock
                minute++;
            }
            else
            {
                minute = 0;
                //update UI clock

                if (hour <= 24)
                {
                    hour++;
                }
                else
                {
                    hour = 0;
                }

            }
            textTarget.GetComponent<TextMeshProUGUI>().text = hour.ToString("00") + ":" + minute.ToString("00");
        }
    }
}
