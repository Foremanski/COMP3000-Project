using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFuncUI : MonoBehaviour
{
    private Collider2D collider;
    private Canvas ObjectUI;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
        ObjectUI = gameObject.GetComponentInChildren<Canvas>();

        ObjectUI.enabled = false;
    }

    //activates world space UI on Click
    private void OnMouseDown()
    {
        if(ObjectUI.enabled == false)
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
        mainCamera.GetComponent<CameraControl>().overUI = true;
    }
    private void OnMouseExit()
    {
        mainCamera.GetComponent<CameraControl>().overUI = false;
    }
}
