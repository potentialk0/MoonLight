using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] vertices =
        {
            new Vector3(-1, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 0, -1),
            new Vector3(-1, 0, -1),
            new Vector3(0, 2, 0),
        };

        Vector3[] normals =
        {
            new Vector3(-1, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 0, -1),
            new Vector3(-1, 0, -1),
            new Vector3(0, 2, 0),
        };

        int[] indices = new int[]
        {
            0, 1, 4,
            4, 1, 2,
            4, 2, 3,
            4, 3, 0,
            0, 3, 2,
            0, 2, 1,
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = indices;
        mesh.normals = normals;

        GetComponent<MeshFilter>().mesh = mesh;

        Material material = new Material(Shader.Find("Standard"));
        GetComponent<MeshRenderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
