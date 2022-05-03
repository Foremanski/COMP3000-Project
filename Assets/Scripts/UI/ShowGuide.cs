using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGuide : MonoBehaviour
{
    private bool guideShown;
    [SerializeField]
    private GameObject guideUI;
    void Start()
    {
        guideShown = false;
        guideUI.SetActive(false);
    }


    public void ShowGuideUI()
    {
        if(guideShown == false)
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
}
