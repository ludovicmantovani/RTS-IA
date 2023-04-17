using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class CameraFrameRect : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Terrain terrain;
    [SerializeField] private String layer;
    [SerializeField] private UILineRenderer uILineRenderer;
    [SerializeField] private bool showDebug = false;
    [SerializeField] private float maxDistance = 100;
    
    private Vector3 pos = Vector3.zero;
    private Vector2[] _points = new Vector2[5];

    private Ray[] GetRay()
    {
        Ray[] rays = new Ray[4];
        rays[0] = cam.ScreenPointToRay(new Vector3(0, 0, 0));
        rays[1] = cam.ScreenPointToRay(new Vector3(Screen.width, 0, 0));
        rays[2] = cam.ScreenPointToRay(new Vector3(Screen.width, Screen.height, 0));
        rays[3] = cam.ScreenPointToRay(new Vector3(0, Screen.height, 0));

        if (showDebug)
        {
            for (int i = 0; i < rays.Length; i++)
            {
                Debug.DrawRay(rays[i].origin, rays[i].direction * maxDistance, Color.yellow);
            }
        }

        return rays;
    }

    private void Update()
    {
        GetPoints();
        DrawLines();
    }

    private void DrawLines()
    {
        uILineRenderer.Points = _points;
        uILineRenderer.SetAllDirty();
    }

    private void GetPoints()
    {
        Ray[] rays = GetRay();
        for (int index = 0; index < _points.Length - 1; index++)
        {
            Ray ray = rays[index];
            _points[index] = Cast(ray);
        }
        _points[_points.Length - 1] = _points[0];
    }

    private Vector2 Cast(Ray ray)
    {
        Vector3 vec = Vector3.zero;
        Vector2 ret = Vector2.zero;
        int nbLayer = 1 << LayerMask.NameToLayer(layer);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, nbLayer))
        {
            vec = hit.point;
            ret.Set(
                ExtensionMethods.Remap(vec.x, 0f, terrain.terrainData.size.x, -125, 125),
                ExtensionMethods.Remap(vec.z, 0f, terrain.terrainData.size.z, -125f, 125)
                );
        }
        else
        {
            print("No hit");
        }
        return ret;
    }
}
