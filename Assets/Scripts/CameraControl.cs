using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{

    private Camera cam;

    //border
    public float mapBorderX, mapBorderY;

    //camera zoom
    float maxCameraDistance = 20f;
    float minCameraDistance = 5f;
    float scrollSpeed = 1.5f;

    public bool overUI;

    public float dragSpeed;
    private Vector3 dragOrigin;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        overUI = false;
        cam.orthographicSize = 5.0f;

        
    }

    // Update is called once per frame

    void Update()
    {
        ZoomCamera();
        DragFunc();

        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    void ZoomCamera()
    {
        //zoom camera
        cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minCameraDistance, maxCameraDistance);

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    void DragFunc()
    {
        //checks if mouse isn't over UI element
        if (overUI == false || BuildingHandler.PowerLineMode == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

                cam.transform.position = ClampCamera(cam.transform.position + difference);
            }
        }
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float vertExtent = cam.orthographicSize;
        float horzExtent = vertExtent * cam.aspect;

        float minX = horzExtent - mapBorderX / 2.0f;
        float maxX = mapBorderX / 2.0f - horzExtent;
        float minY = vertExtent - mapBorderY / 2.0f;
        float maxY = mapBorderY / 2.0f - vertExtent;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}

