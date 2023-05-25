using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    private Mesh _mesh;
    private Vector3[] _vertices;
    private Color[] _colors;

    private LayerMask _fogLayer;


    public static event Action OnCompleteInitialize;

    public static FogOfWar instance;
    [SerializeField] private GameObject _fogOfWar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _fogLayer = LayerMask.GetMask("FogLayer");
        Initialize();
    }

    private void Initialize()
    {
        _mesh = _fogOfWar.GetComponent<MeshFilter>().mesh;
        _vertices = _mesh.vertices;

        _colors = new Color[_vertices.Length];

        for (int i = 0; i < _colors.Length; i++)
        {
            _colors[i] = Color.black;
        }

        _mesh.colors = _colors;
        OnCompleteInitialize?.Invoke();
    }

    public void UnhideUnit(Transform unit, int radius)
    {
        Mesh unitMesh = unit.GetComponent<MeshFilter>().mesh;
        Vector3[] uniVertices = unitMesh.vertices;

        foreach (Vector3 vertice in uniVertices)
        {
            Vector3 verticePos = unit.transform.TransformPoint(vertice);
            Ray ray = new Ray(transform.position, verticePos - transform.position);
            Debug.DrawRay(transform.position, verticePos - transform.position, Color.green);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 15000, _fogLayer, QueryTriggerInteraction.Collide))
            {
                for (int i = 0; i < _vertices.Length; i++)
                {
                    Vector3 vPos = _fogOfWar.transform.TransformPoint(_vertices[i]);
                    float distance = Vector3.SqrMagnitude(vPos - hit.point);

                    if (distance < radius)
                    {
                        float alpha = Mathf.Min(_colors[i].a, distance / radius);
                        _colors[i].a = alpha;
                    }
                }

                _mesh.colors = _colors;
            }

        }
    }
}
