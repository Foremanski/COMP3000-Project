using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightBehaviour : MonoBehaviour
{
    int hour = Camera.main.GetComponent<ClockScript>().hour;
    public List<GameObject> consumers;
    public float goal;

    // Start is called before the first frame update
    void Start()
    {
        consumers.AddRange(GameObject.FindGameObjectsWithTag("Consumer"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    //if the map expands, update the list of consumers
    public void updateList()
    {
        consumers.Clear();
        consumers.AddRange(GameObject.FindGameObjectsWithTag("Consumer"));
    }

    IEnumerator ChangeBehaviour()
    {
        yield return new WaitForSeconds(5.0f * -ClockScript.speed);

        if (hour < 1)
        {
            //0 consumption
            Sleeping();
        }
        else if (hour >= 1 && hour < 5)
        {
            //low consumption
        }

        //between 5 and 8
        else if (hour >= 5 && hour < 8)
        {
            //ramp up consumption
            MorningBehaviour();
        }

        //peak at 6
    }

    void Sleeping()
    {
        for(int i = 0; i < consumers.Count; i++)
        {
            consumers[i].GetComponent<HouseFunc>().PowerIntake = 0;
        }
    }

    void MorningBehaviour()
    {

        for(int i = 0; i <consumers.Count; i++)
        {
            //gradually increase power, morning ramp
            consumers[i].GetComponent<HouseFunc>().PowerIntake += goal;
        }
    }

    void DaytimeNormal()
    {
        
    }   
}
