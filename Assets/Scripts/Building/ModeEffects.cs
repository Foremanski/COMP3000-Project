using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModeEffects : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject BuildEffect, DestroyEffect;
    [SerializeField]
    private GameObject btnBuildPowerLine, btnDestroyPowerLine;  

    void Start()
    {
        BuildEffect.SetActive(false);
        DestroyEffect.SetActive(false);
    }

    public void UpdateBuildEffect()
    {
        if(BuildingHandler.PowerLineMode == true)
        {
            BuildEffect.SetActive(true);
            btnBuildPowerLine.GetComponentInChildren<TextMeshProUGUI>().text = "Stop Building";
        }
        else
        {
            BuildEffect.SetActive(false);
            btnBuildPowerLine.GetComponentInChildren<TextMeshProUGUI>().text = "Build Power Lines";
        }
    }
    public void UpdateDestroyEffect()
    {
        if (BuildingHandler.DestroyMode == true)
        {
            DestroyEffect.SetActive(true);
            btnDestroyPowerLine.GetComponentInChildren<TextMeshProUGUI>().text = "Stop Destroying";
        }
        else
        {
            DestroyEffect.SetActive(false);
            btnDestroyPowerLine.GetComponentInChildren<TextMeshProUGUI>().text = "Destroy Power Lines";
        }
    }
}
