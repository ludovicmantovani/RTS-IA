using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    #region Variables
    private Mesh _mesh;
    private Vector3[] _vertices;
    private Color[] _colors;
    private LayerMask _fogLayer;
    private GameObject _fogOfWar;

    public static event Action OnCompleteInitialize;

    public static FogOfWar instance;
    #endregion

    #region Builtin Methods
    void Awake(){
        if(instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        _fogLayer = LayerMask.GetMask("FogOfWar");
        _fogOfWar = GameObject.Find("FogOfWar");

        Initialize();
    }

    void Update()
    {
        
    }
    #endregion

    #region Custom Methods
    void Initialize(){
        if(!_fogOfWar) return;

        _mesh = _fogOfWar.GetComponent<MeshFilter>().mesh;
        _vertices = _mesh.vertices;

        _colors = new Color[_vertices.Length];

        for(int i = 0; i < _colors.Length; i++){
            _colors[i] = Color.black;
        }

        _mesh.colors = _colors;

        OnCompleteInitialize?.Invoke();
    }

    public void UnhideUnit(Transform unit, int radius){
        if(!_fogOfWar) return;

        Mesh unitMesh = unit.GetComponent<MeshFilter>().mesh;
        Vector3[] unitVertices = unitMesh.vertices;

        foreach(var vertice in unitVertices){
            Vector3 verticePos = unit.transform.TransformPoint(vertice);
            Ray ray = new Ray(transform.position, verticePos - transform.position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 1500, _fogLayer, QueryTriggerInteraction.Collide)){
                for(int i = 0; i < _vertices.Length; i++){
                    Vector3 vPos = _fogOfWar.transform.TransformPoint(_vertices[i]);
                    float distance = Vector3.SqrMagnitude(vPos - hit.point);

                    if(distance < radius){
                        float alpha = Mathf.Min(_colors[i].a, distance / radius);
                        _colors[i].a = alpha;
                    }
                }

                _mesh.colors = _colors;
            }
        }
    }
    #endregion
}
