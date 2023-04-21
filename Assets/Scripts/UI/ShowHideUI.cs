using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideUI : MonoBehaviour
{
    [SerializeField] private KeyCode toggleKey = KeyCode.Escape;
    [SerializeField] private GameObject uiContainer = null;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            uiContainer.SetActive(!uiContainer.activeSelf);
        }
    }
}
