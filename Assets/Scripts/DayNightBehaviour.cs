using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightBehaviour : MonoBehaviour
{
    public List<GameObject> consumers;
    public float goal;
    private Coroutine inProgress;
    public int hour;

    // Start is called before the first frame update
    void Start()
    {
        consumers.AddRange(GameObject.FindGameObjectsWithTag("Consumer"));
        
        inProgress = StartCoroutine(ChangeBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        hour = Camera.main.GetComponent<ClockScript>().hour;
    }

    //if the map expands, update the list of consumers
    public void updateList()
    {
        consumers.Clear();
        consumers.AddRange(GameObject.FindGameObjectsWithTag("Consumer"));
    }

    IEnumerator ChangeBehaviour()
    {

        while (true)
        {
            yield return new WaitForSeconds(10.0f * ClockScript.speed);

            if (hour < 1)
            {
                //0 consumption
                Sleeping();
            }
            else if(hour >= 1 && hour < 5)
            {
                EarlyMorningBehaviour();
            }

            else if(hour >= 5 && hour < 8)
            {
                MorningBehaviour();
            }
            else if(hour >= 8 && hour < 16)
            {
                MiddayBehaviour();
            }
            else if(hour >= 16 && hour < 18)
            {
                AfternoonPeakBehaviour();
            }
            else if (hour >= 18 && hour < 22)
            {
                EveningBehaviour();
            }
            else if (hour >=22 && hour < 24)
            {
                BeginSleepBehaviour();
            }
        }
    }

    void Sleeping()
    {
        for(int i = 0; i < consumers.Count; i++)
        {
            consumers[i].GetComponent<ConsumerFunc>().PowerUsage = 0;
        }
    }

    void EarlyMorningBehaviour()
    {
        goal = 4.0f;

        for (int i = 0; i < consumers.Count; i++)
        {
            if (consumers[i].GetComponent<ConsumerFunc>().PowerUsage < goal)
            {
                //gradually increase power, morning ramp
                consumers[i].GetComponent<ConsumerFunc>().PowerUsage += 0.2f;
            }           
        }
    }

    void MorningBehaviour()
    {
        goal = 10.0f;

        for(int i = 0; i <consumers.Count; i++)
        {
            if(consumers[i].GetComponent<ConsumerFunc>().PowerIntake < goal)
            {
                //gradually increase power, morning ramp
                consumers[i].GetComponent<ConsumerFunc>().PowerIntake += 0.5f;
            }     
        }
    }

    void MiddayBehaviour()
    {
        goal = 12.0f;
        for (int i = 0; i < consumers.Count; i++)
        {
            if (consumers[i].GetComponent<ConsumerFunc>().PowerUsage < goal)
            {
                //gradually increase power, morning ramp
                consumers[i].GetComponent<ConsumerFunc>().PowerUsage += 0.2f;
            }
        }
    }

    void AfternoonPeakBehaviour()
    {
        goal = 16.0f;
        for (int i = 0; i < consumers.Count; i++)
        {
            if (consumers[i].GetComponent<ConsumerFunc>().PowerUsage < goal)
            {
                //gradually increase power, morning ramp
                consumers[i].GetComponent<ConsumerFunc>().PowerUsage += 0.5f;
            }
        }
    }

    void EveningBehaviour()
    {
        goal = 11.0f;
        for (int i = 0; i < consumers.Count; i++)
        {
            if (consumers[i].GetComponent<ConsumerFunc>().PowerUsage > goal)
            {
                //gradually increase power, morning ramp
                consumers[i].GetComponent<ConsumerFunc>().PowerUsage -= 0.4f;
            }
        }
    }

    void BeginSleepBehaviour()
    {
        goal = 0.0f;
        for (int i = 0; i < consumers.Count; i++)
        {
            if (consumers[i].GetComponent<ConsumerFunc>().PowerUsage > goal)
            {
                //gradually increase power, morning ramp
                consumers[i].GetComponent<ConsumerFunc>().PowerUsage -= 0.5f;
            }
        }
    }
}
