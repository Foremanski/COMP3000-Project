using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Camera cam;
    public static bool PowerLineMode;

    // Start is called before the first frame update
    void Start()
    {
        PowerLineMode = false;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cam.GetComponent<CameraControl>().overUI = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cam.GetComponent<CameraControl>().overUI = false;
    }


    public void BuildPowerLine()
    {
        PowerLineMode = true;

        //instantsiate new power line game object

        //set origin point on click

        //set end point
    }
}
