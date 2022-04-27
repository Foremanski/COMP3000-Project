using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ChartUtil
{
    public class LineGraphFunc : MonoBehaviour
    {
        public Chart myChart;
        private Coroutine inProgress;
       
        private Series demand = new Series();
        private Series output = new Series();

        public GameObject[] allConsumers;
        public GameObject[] allProducers;

        public float newDemandData;
        public float newOutputData;

        private float maxChartValue;

        // Start is called before the first frame update
        void Start()
        {
            myChart.chartData.series = new List<Series>();
            demand.colorIndex = 3;
            demand.name = "Demand";          
            output.colorIndex = 2;
            output.name = "Output";

            myChart.chartData.series.Add(demand);
            myChart.chartData.series.Add(output);
            myChart.UpdateChart();

            inProgress = StartCoroutine(UpdateGraph());
        }

        // Update is called once per frame
        void Update()
        {
            CheckForReset();
        }

        IEnumerator UpdateGraph()
        {
            allConsumers = GameObject.FindGameObjectsWithTag("Consumer");
            allProducers = GameObject.FindGameObjectsWithTag("Producer");

            while (true)
            {
                yield return new WaitForSeconds(10.0f * ClockScript.speed);
              
                //add data to chart
                GetNewData();
                //set new max chart value 
                CheckForMaxChartValue();
                //add data to series
                AddData();              
                //resize chart with maxChartValue
                ResizeChart();
                //Calculate Wasted Power
                CalcWastedPower();
                getAllBlackouts();

                myChart.UpdateChart();
            }
        }

        void GetNewData()
        {
            //reset
            newDemandData = 0;
            newOutputData = 0;

            //retrieve total demand and total output
            for (int i = 0; i < allConsumers.Length; i++)
            {
                newDemandData += allConsumers[i].GetComponent<ConsumerFunc>().PowerUsage;
            }
            for(int i = 0; i < allProducers.Length; i++)
            {
                newOutputData += allProducers[i].GetComponent<ProducerFunc>().powerOutputBackup;
            }          
        }

        void CheckForMaxChartValue()
        {
            //set new max chart value 
            if (newDemandData > maxChartValue || newOutputData > maxChartValue)
            {
                if (newDemandData > newOutputData)
                {
                    maxChartValue = newDemandData;
                }
                else
                {
                    maxChartValue = newOutputData;
                }
            }
        }

        void AddData()
        {
            myChart.chartData.series.Clear();
            demand.data.Add(new Data(newDemandData, Camera.main.GetComponent<ClockScript>().hour + (Camera.main.GetComponent<ClockScript>().minute / 60)));
            myChart.chartData.series.Add(demand);
            output.data.Add(new Data(newOutputData, Camera.main.GetComponent<ClockScript>().hour + (Camera.main.GetComponent<ClockScript>().minute / 60)));
            myChart.chartData.series.Add(output);
        }

        //reset chart data and retrieve consumers/producers
        void CheckForReset()
        {
            if (Camera.main.GetComponent<ClockScript>().hour == 0 && Camera.main.GetComponent<ClockScript>().minute == 0)
            {
                //reset the data for that day
                ResetSeries();
                //retrieve all consumers and producers again
                allConsumers = GameObject.FindGameObjectsWithTag("Consumer");
                allProducers = GameObject.FindGameObjectsWithTag("Producer");
            }
        }

        void ResetSeries()
        {
            demand.data.Clear();
            output.data.Clear();
            maxChartValue = 0;
            myChart.UpdateChart();
        }

        void ResizeChart()
        {
            //resizes the chart to fit max value
            myChart.chartOptions.yAxis.max = maxChartValue + 10;
        }
        void CalcWastedPower()
        {
            
            float CalcPowerWasted;
            float totalIntake = 0;

            if (newDemandData > 0)
            {
                for (int i = 0; i < allConsumers.Length; i++)
                {
                    totalIntake += allConsumers[i].GetComponent<ConsumerFunc>().PowerIntake;
                }


                CalcPowerWasted = totalIntake - (newDemandData + newDemandData * 0.3f);

                CalcTransmissionLoss(totalIntake);

                //update lose metre score
                Camera.main.GetComponent<LoseMetreFunc>().UpdatePowerWastedScore(CalcPowerWasted);
            }                                
        }

        void CalcTransmissionLoss(float totalIntake)
        {
            float transmissionLoss = newOutputData - totalIntake;

            Camera.main.GetComponent<LoseMetreFunc>().UpdateTransmissionLoss(transmissionLoss);
        }

        //retreives all the bools of consumer houses an
        void getAllBlackouts()
        {
            int blackoutNums = 0;

            for (int i = 0; i < allConsumers.Length; i++)
            {
                if(allConsumers[i].GetComponent<ConsumerFunc>().isBlackout == true)
                {
                    blackoutNums++;
                }
            }
            //send blackout score to lose metre
            Camera.main.GetComponent<LoseMetreFunc>().UpdateBlackoutScore(blackoutNums);
        }
    }
}
