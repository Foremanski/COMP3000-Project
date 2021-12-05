using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        if(Input.GetKeyDown("e"))
        {
            InitialiseMesh();
        }
        if(Input.GetKeyDown("q"))
        {
            ResizeMesh();
        }
    }


    void InitialiseMesh()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3 (0,0,0),
            new Vector3 (1,0,0),
            new Vector3 (1,1,0),
            new Vector3 (0,1,0),
            new Vector3 (0,1,1),
            new Vector3 (1,1,1),
            new Vector3 (1,0,1),
            new Vector3 (0,0,1)
        };

        triangles = new int[]
        {
            0, 2, 1, //face front
	        0, 3, 2,
            2, 3, 4, //face top
	        2, 4, 5,
            1, 2, 5, //face right
	        1, 5, 6,
            0, 7, 4, //face left
	        0, 4, 3,
            5, 4, 7, //face back
	        5, 7, 6,
            0, 6, 7, //face bottom
	        0, 1, 6
        };
    }
    
    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    void ResizeMesh()
    {
        Mesh meshClone = mesh;

        meshClone.vertices =
    }
}
