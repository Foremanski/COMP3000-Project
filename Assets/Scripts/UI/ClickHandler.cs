using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private BuildPowerLine buildPL;

    // Start is called before the first frame update
    void Start()
    {
        buildPL = gameObject.GetComponent<BuildPowerLine>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BuildingHandler.PowerLineMode == true || BuildingHandler.DestroyMode == true || BuildingHandler.TransformerMode == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                getGameObject();
            }
        }    
    }
    void getGameObject()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


        if(hit.collider != null)
        {
            Debug.Log("whoop");
            buildPL.StructureClicked = true;
            HandleClick(hit.transform.gameObject);
        }
        else
        {
            Debug.Log("o no");
            if(BuildingHandler.PowerLineMode == true && buildPL.Position1Set == true)
            {
                buildPL.StructureClicked = false;
                buildPL.SetPosition2();
            }
        }
    }

    //finds what type of clicked gameobject is
    void HandleClick(GameObject ClickedObject)
    {
        //check what ClickedObject Is
        if(ClickedObject.GetComponent<PowerNodeFunc>() != null)
        {
            HandlePowerNode(ClickedObject);
        }
        else if(ClickedObject.GetComponent<TransformerFunc>() != null)
        {
            HandleTransformer(ClickedObject);
        }
        else if(ClickedObject.GetComponent<ProducerFunc>() != null)
        {
            HandleProducer(ClickedObject);
        }
        else if(ClickedObject.GetComponent<ConsumerFunc>() != null)
        {
            HandleConsumer(ClickedObject);
        }
    }

    //individual 
    void HandleProducer(GameObject ClickedObject)
    {
        ProducerFunc ClickedProducer = ClickedObject.GetComponent<ProducerFunc>();

        //sets current clicked gameobject to beginning of power line
        if (BuildingHandler.PowerLineMode == true && ClickedProducer.powerLine == null)
        {
            //set factory to power line location
            buildPL.SetBuildInfo(ClickedObject);
            buildPL.GeneratePowerLine();
            buildPL.SetPosition1();

            //sets factory subject to new powerline
            ClickedProducer.powerLine = buildPL.newPowerLine;          
        }   
    }

    void HandleConsumer(GameObject ClickedObject)
    {
        ConsumerFunc ClickedConsumer = ClickedObject.GetComponent<ConsumerFunc>();
        if(BuildingHandler.PowerLineMode == true && buildPL.Position1Set == true && buildPL.newPowerLine.GetComponent<PowerLineFunc>().highPower == false)
        {
            //set factory pos to power line location
            buildPL.SetBuildInfo(ClickedObject);
            buildPL.SetPosition2();

            ClickedConsumer.PowerLineIn = buildPL.newPowerLine;
        }
        else if(buildPL.newPowerLine.GetComponent<PowerLineFunc>().highPower == true)
        {
            //notify player
        }
    }

    void HandlePowerNode(GameObject ClickedObject)
    {
        PowerNodeFunc ClickedPowerNode = ClickedObject.GetComponent<PowerNodeFunc>();     

        if (BuildingHandler.PowerLineMode == true)
        {
            buildPL.SetBuildInfo(ClickedObject);

            //first click - generate power line from node
            if (buildPL.Position1Set == false)
            {            
                //check if powersubjects element is null
                for(int i = 0; i < ClickedPowerNode.PowerSubjects.Count; i++)
                {
                    if(ClickedPowerNode.PowerSubjects[i] == null)
                    {
                        ClickedPowerNode.PowerSubjects.RemoveAt(i);
                    }
                }
                
                if(ClickedPowerNode.PowerSubjects.Count <3)
                {
                    buildPL.GeneratePowerLine();
                    buildPL.SetPosition1();

                    buildPL.newPowerLine.GetComponent<PowerLineFunc>().highPower = ClickedPowerNode.PowerLineIn.GetComponent<PowerLineFunc>().highPower;

                    ClickedPowerNode.GetComponent<PowerNodeFunc>().PowerSubjects.Add(buildPL.newPowerLine);
                }               
            }
            //second click - connect power line to node
            else if(buildPL.Position1Set == true && ClickedPowerNode.PowerLineIn == null)
            {
                buildPL.SetPosition2();

                buildPL.StructureClicked = true;
                ClickedPowerNode.PowerLineIn = buildPL.newPowerLine;
            }
        }

        else if (BuildingHandler.DestroyMode == true)
        {
            //destroy connected power lines
            for (int i = 0; i < ClickedPowerNode.PowerSubjects.Count; i++)
            {
                Destroy(ClickedPowerNode.PowerSubjects[i]);
            }
            Destroy(ClickedPowerNode.PowerLineIn);

            //destroy node
            Destroy(ClickedObject);
        }
    }

    void HandleTransformer(GameObject ClickedObject)
    {
        TransformerFunc ClickedTransformer = ClickedObject.GetComponent<TransformerFunc>();

        if (BuildingHandler.PowerLineMode == true)
        {
            //set transformer to power line location
            buildPL.SetBuildInfo(ClickedObject);

            //first click - power line out
            if (buildPL.Position1Set == false && ClickedTransformer.PowerLineOut == null)
            {
                buildPL.GeneratePowerLine();
                buildPL.SetPosition1();


                ClickedTransformer.PowerLineOut = buildPL.newPowerLine;

                ClickedTransformer.InvertPower();                          
            }
            //second click - set power line in
            else if(buildPL.Position1Set == true && ClickedTransformer.PowerLineIn == null)
            {
                buildPL.SetPosition2();
                ClickedTransformer.PowerLineIn = buildPL.newPowerLine;
            }
        }

        else if(BuildingHandler.DestroyMode == true)
        {
            Destroy(ClickedTransformer.PowerLineIn);
            Destroy(ClickedTransformer.PowerLineOut);
            Destroy(ClickedObject);
        }
    }
}
