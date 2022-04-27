using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    private Camera cam;

    public GameObject GameOverScreen;
    public GameObject FinalTimeText;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFinalTime()
    {
        if(GameOverScreen.activeInHierarchy == false)
        {
            GameOverScreen.SetActive(true);

            //FinalTimeText.GetComponent<TextMeshProUGUI>().text = Camera.main.GetComponent<ClockScript>().day.ToString() + " Days " + Camera.main.GetComponent<ClockScript>().hour + " Hours " + Camera.main.GetComponent<ClockScript>().minute + " Minutes";
            FinalTimeText.GetComponent<TextMeshProUGUI>().text = string.Format("{0} Days, {1} Hours, {2} Minutes", 
                cam.GetComponent<ClockScript>().day.ToString("00"), 
                cam.GetComponent<ClockScript>().hour.ToString("00"), 
                cam.GetComponent<ClockScript>().minute.ToString("00"));
        }      
    }


    public void StartNewGame()
    {
        GameOverScreen.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        GameOverScreen.SetActive(false);
        SceneManager.LoadScene("MenuScene");
    }
}
