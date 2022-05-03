using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    private bool guideShown, creditsShown;
    [SerializeField]
    private GameObject guideUI, creditsUI;
    [SerializeField]
    private AudioSource clickSound;

    //Start and Exit
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
    void Start()
    {
        guideShown = false;
        creditsShown = false;
        creditsUI.SetActive(false);
        guideUI.SetActive(false);
    }


    public void ShowGuideUI()
    {
        playClickSound();

        if (guideShown == false && creditsShown == false)
        {
            guideShown = true;
            guideUI.SetActive(true);
        }
        else
        {
            guideShown = false;
            guideUI.SetActive(false);
        }
    }

    public void ShowCreditsUI()
    {
        playClickSound();

        if (creditsShown == false && guideShown == false)
        {
            creditsShown = true;
            creditsUI.SetActive(true);
        }
        else
        {
            creditsShown = false;
            creditsUI.SetActive(false);
        }
    }
    
    private void playClickSound()
    {
        clickSound.Play();
    }
}