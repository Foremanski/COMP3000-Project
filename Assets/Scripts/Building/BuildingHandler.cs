using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{

    public static bool PowerLineMode;
    public static bool TransformerMode;
    public static bool DestroyMode;

    [SerializeField]
    

    // Start is called before the first frame update
    void Start()
    {
        PowerLineMode = false;
        TransformerMode = false;
        DestroyMode = false;
    }

    public void TogglePLMode()
    {
        TransformerMode = false;
        DestroyMode = false;

          
       
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
        //update screen effects
        gameObject.GetComponent<ModeEffects>().UpdateDestroyEffect();
    }

    public void ToggleTransformerMode()
    {
        DestroyMode = false;
        PowerLineMode = false;    

        if (TransformerMode == false)
        {
            Camera.main.GetComponent<BuildTransformer>().GenerateTransformer();
            TransformerMode = true;
        }
        else
        {
            TransformerMode = false;
        }

        //update screen effects
        gameObject.GetComponent<ModeEffects>().UpdateBuildEffect();
        //update screen effects
        gameObject.GetComponent<ModeEffects>().UpdateDestroyEffect();
    }

    public void ToggleDestroyMode()
    {
        TransformerMode = false;
        PowerLineMode = false;
                
        //toggle mode
        if (DestroyMode == false)
        {
            DestroyMode = true;              
        }
        else
        {
            DestroyMode = false;           
        }

        //update screen effects
        gameObject.GetComponent<ModeEffects>().UpdateBuildEffect();
        //update screen effects
        gameObject.GetComponent<ModeEffects>().UpdateDestroyEffect();
    }  
}
