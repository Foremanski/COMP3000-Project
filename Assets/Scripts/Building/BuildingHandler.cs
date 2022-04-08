using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{

    public static bool PowerLineMode;
    public static bool TransformerMode;

    // Start is called before the first frame update
    void Start()
    {
        PowerLineMode = false;
        TransformerMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePLMode()
    {
        if(TransformerMode == false)
        {
            if (PowerLineMode == false)
            {
                PowerLineMode = true;
            }
            else
            {
                PowerLineMode = false;
            }
        }       
    }

    public void ToggleTransformerMode()
    {
        if(PowerLineMode == false)
        {
            if (TransformerMode == false)
            {
                Camera.main.GetComponent<BuildTransformer>().GenerateTransformer();
                TransformerMode = true;
            }
            else
            {
                TransformerMode = false;
            }
        }       
    }
}
