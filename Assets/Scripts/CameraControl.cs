using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera cam;

    
    float maxCameraDistance = 20f;
    float minCameraDistance = 5f;
    float scrollSpeed = 1.5f;


    public float dragSpeed;
    private Vector3 dragOrigin;

    // Start is called before the first frame update
    void Start()
    {
        cam.orthographicSize = 5.0f;
    }

    // Update is called once per frame

    void Update()
    {
        //zoom camera
        cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minCameraDistance, maxCameraDistance);

        if(Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

            transform.Translate(-move, Space.World);

            dragOrigin = Input.mousePosition;                  
        }

       
    }
}
