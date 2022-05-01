using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DetectTile : MonoBehaviour
{
    Tilemap tiles;

    List<Tile> ForbiddenTiles; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool checkForSafeTile(Vector3 ClickedTile)
    {
        Vector3Int location = tiles.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        for(int i = 0; i < ForbiddenTiles.Count; i++)
        {
            if(ForbiddenTiles[i] == tiles.GetTile<Tile>(location))
            {
                return false;
            }
        }
        return true;
    }
}
