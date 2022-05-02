using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{

    private Camera cam;

    //border
    public float minMapBorderX, maxMapBorderX, minMapBorderY, maxMapBorderY;

    //camera zoom
    public float maxCameraDistance;
    public float scrollSpeed = 1.5f;

    float minCameraDistance = 5f;
    

    public bool overUI;

    public float dragSpeed;
    private Vector3 dragOrigin;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        overUI = false;
        cam.orthographicSize = 5.0f;

        maxCameraDistance = 7.0f;
        scrollSpeed = 1.5f;

    }

    // Update is called once per frame

    void Update()
    {
        ZoomCamera();
        DragFunc();

        //DEBUG
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
        if (BuildingHandler.PowerLineMode == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0) && overUI == false)
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

        float minX = horzExtent - minMapBorderX / 2.0f;
        float maxX = maxMapBorderX / 2.0f - horzExtent;
        float minY = vertExtent - minMapBorderY / 2.0f;
        float maxY = maxMapBorderY / 2.0f - vertExtent;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}

