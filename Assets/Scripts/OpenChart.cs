using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ChartUtil
{
    public class OpenChart : MonoBehaviour
    {
        public GameObject myChart;
        public Animator animChartController;

        // Start is called before the first frame update
        void Start()
        {
            myChart.SetActive(false);                      
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ChartStateCoroutine()
        {
            StartCoroutine(ChangeChartState());
        }

        private IEnumerator ChangeChartState()
        {
            if(myChart.activeInHierarchy)
            {
                //close chart
                myChart.SetActive(false);

                yield return new WaitForSeconds(0.1f);

                //play animation
                animChartController.Play("GraphClose");
            }
            else
            {
                //play animation
                animChartController.Play("GraphOpen");

                //play sound 
                Camera.main.GetComponent<SoundEffectHandler>().PlayPowerStationActivate();

                yield return new WaitForSeconds(0.8f);

                //enable chart
                myChart.SetActive(true);
            }
        }
    }
}



