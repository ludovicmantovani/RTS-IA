using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarPlaneGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    [SerializeField] private int resolution;
    [SerializeField] private Material mat;

    private Mesh _mesh;
    private List<Vector3> _vertices = new List<Vector3>();
    private List<int> _triangles = new List<int>();
    private MeshFilter _meshFilter;

    void Awake()
    {
        _mesh = new Mesh();
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = _mesh;
    }
    
    void Start()
    {
        GeneratePlane();
    }

    void GeneratePlane(){
        float vertPerX = size.x / resolution;
        float vertPerZ = size.y / resolution;

        for(int z = 0; z < resolution + 1; z++){
            for(int x = 0; x < resolution + 1; x++){
                _vertices.Add(new Vector3(x * vertPerX, 0, z * vertPerZ));
            }
        }

        for(int z = 0; z < resolution; z++){
            for(int x = 0; x < resolution; x++){
                int i = (z * resolution) + z + x;

                _triangles.Add(i);
                _triangles.Add(i + resolution + 1);
                _triangles.Add(i + resolution + 2);

                _triangles.Add(i);
                _triangles.Add(i + resolution + 2);
                _triangles.Add(i + 1);
            }
        }

        SetupPlane();
    }

    void SetupPlane(){
        _mesh.Clear();
        _mesh.vertices = _vertices.ToArray();
        _mesh.triangles = _triangles.ToArray();

        GetComponent<MeshRenderer>().sharedMaterial = mat;
        gameObject.AddComponent<BoxCollider>();
    }
}