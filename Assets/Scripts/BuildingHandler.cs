using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{

    public static bool PowerLineMode;          

    // Start is called before the first frame update
    void Start()
    {
        PowerLineMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePLMode()
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
