using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Camera cam;
    [SerializeField]
    private bool mouseOver;


    // Start is called before the first frame update
    void Start()
    {
        mouseOver = false;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(mouseOver == false)
            {
                cam.GetComponent<CameraControl>().overUI = false;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cam.GetComponent<CameraControl>().overUI = true;

        mouseOver = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(!Input.GetMouseButton(0))
        {
            mouseOver = false;
        }
        else
        {
            mouseOver = true;
        }
    }
}
