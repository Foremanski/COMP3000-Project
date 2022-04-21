using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera cam;
    public float border;
    
    float maxCameraDistance = 20f;
    float minCameraDistance = 5f;
    float scrollSpeed = 1.5f;

    public bool overUI;

    public float dragSpeed;
    private Vector3 dragOrigin;

    // Start is called before the first frame update
    void Start()
    {
        overUI = false;
        cam.orthographicSize = 5.0f;

    }

    // Update is called once per frame

    void Update()
    {
        ZoomCamera();
        DragFunc();
    }

    void ZoomCamera()
    {
        //zoom camera
        cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minCameraDistance, maxCameraDistance);
    }

    void DragFunc()
    {
        //checks if mouse isn't over UI element
        if (overUI == false || BuildingHandler.PowerLineMode == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {

                Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
                Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

                transform.Translate(-move, Space.World);

                dragOrigin = Input.mousePosition;
            }
        }
    }
}
