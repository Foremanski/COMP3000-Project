using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Camera cam;

   


    // Start is called before the first frame update
    void Start()
    {
       
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


}
