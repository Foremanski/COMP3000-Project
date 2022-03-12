using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFuncUI : MonoBehaviour
{
    private Collider2D collider;
    private Canvas ObjectUI;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
        ObjectUI = gameObject.GetComponentInChildren<Canvas>();

        ObjectUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(ObjectUI.enabled == false)
        {
            ObjectUI.enabled = true;
        }
        else
        {
            ObjectUI.enabled = false;
        }
    }
}
