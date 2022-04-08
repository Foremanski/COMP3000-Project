using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTransformer : MonoBehaviour
{
    public GameObject transformerPrefab;
    private GameObject newTransformer;
    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BuildingHandler.TransformerMode == true)
        {
            UpdateTransformer();
        }       
    }
    void UpdateTransformer()
    {
        newTransformer.transform.position = GetMousePosition();

        if(Input.GetMouseButtonDown(0))
        {
            BuildingHandler.TransformerMode = false;
        }
    }

    private Vector2 GetMousePosition()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        return mousePosition;
    }


    public void GenerateTransformer()
    {
        newTransformer = Instantiate(transformerPrefab);
    }
}
