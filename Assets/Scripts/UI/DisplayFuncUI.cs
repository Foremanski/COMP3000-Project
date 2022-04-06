using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFuncUI : MonoBehaviour
{
    private Canvas ObjectUI;

    // Start is called before the first frame update
    void Start()
    {
        ObjectUI = gameObject.GetComponentInChildren<Canvas>();

        ObjectUI.enabled = false;
    }

    //activates world space UI on Click
    private void OnMouseDown()
    {     
        if(BuildingHandler.PowerLineMode == true)
        {

        }
            //enable World space UI
        else if (ObjectUI.enabled == false)
        {
            ObjectUI.enabled = true;
        }
        else
        {
            ObjectUI.enabled = false;
        }             
    }

    //disables drag functionality
    private void OnMouseOver()
    {
        Camera.main.GetComponent<CameraControl>().overUI = true;
    }
    private void OnMouseExit()
    {
        Camera.main.GetComponent<CameraControl>().overUI = false;
    }
}
