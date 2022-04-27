using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBorder : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ExpandBorderSize()
    {
        gameObject.GetComponent<CameraControl>().mapBorderX += 30f;
        gameObject.GetComponent<CameraControl>().mapBorderY += 30f;

        Debug.Log("Border is Expanded");
    }
}
