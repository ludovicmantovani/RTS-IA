using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFrameRect : MonoBehaviour
{
    public Camera cam;
    Vector3 pos = Vector3.zero;


    private void Start()
    {
        Ray topLeft = cam.ScreenPointToRay(new Vector3(0, 0, 0));
        Cast(topLeft);
        Ray topRight = cam.ScreenPointToRay(new Vector3(Screen.width, 0, 0));
        Cast(topRight);
        Ray botRight = cam.ScreenPointToRay(new Vector3(Screen.width, Screen.height, 0));
        Cast(botRight);
        Ray botLeft = cam.ScreenPointToRay(new Vector3(0, Screen.height, 0));
        Cast(botLeft);

        Debug.DrawRay(topLeft.origin, topLeft.direction * 10, Color.yellow);
        Debug.DrawRay(topRight.origin, topRight.direction * 10, Color.yellow);
        Debug.DrawRay(botRight.origin, botRight.direction * 10, Color.yellow);
        Debug.DrawRay(botLeft.origin, botLeft.direction * 10, Color.yellow);

    }

    private void Update()
    {
       
    }

    private void Cast(Ray ray)()
    {
        Vector3 vec = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            vec = hit.point;
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = vec;
        }
    }
}
