using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private GameObject selectionVisual;

    public void ToggleSelectionVisual(bool selected)
    {
        selectionVisual.SetActive(selected);
    }

}
