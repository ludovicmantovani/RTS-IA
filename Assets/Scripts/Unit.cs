using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Components")]
    public GameObject selectionVisual;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ToggleSelectionVisual(bool selected)
    {
        selectionVisual.SetActive(selected);
    }

}
