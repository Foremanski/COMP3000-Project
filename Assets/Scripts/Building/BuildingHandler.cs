using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{

    public static bool PowerLineMode;
    public static bool TransformerMode;
    public static bool DestroyMode;

    // Start is called before the first frame update
    void Start()
    {
        PowerLineMode = false;
        TransformerMode = false;

    }

    public void TogglePLMode()
    {
        if(TransformerMode == false && DestroyMode == false)
        {
            if (PowerLineMode == false)
            {
                PowerLineMode = true;               
            }
            else
            {
                PowerLineMode = false;

            }
            //update screen effects
            gameObject.GetComponent<ModeEffects>().UpdateBuildEffect();
        }       
    }

    public void ToggleTransformerMode()
    {
        if(PowerLineMode == false && DestroyMode == false)
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

    public void ToggleDestroyMode()
    {
        if(TransformerMode == false && PowerLineMode == false)
        if (DestroyMode == false)
        {
            DestroyMode = true;

        }
        else
        {
            DestroyMode = false;
        }
        //update screen effects
        gameObject.GetComponent<ModeEffects>().UpdateDestroyEffect();
    }
}
