using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonByRessource : MonoBehaviour
{
    #region Variables
    [SerializeField] private int energyCost = 0;
    [SerializeField] private int metalCost = 0;
    [SerializeField] private Button button = null;

    private RessourcesManager _ressourcesManager = null;
    #endregion

    #region Built in Methods
    void Start()
    {
        _ressourcesManager = RessourcesManager.instance;
        if (_ressourcesManager) CanBuild();
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        RessourcesManager.OnRessourcesUpdate += CanBuild;
    }

    private void OnDisable()
    {
        RessourcesManager.OnRessourcesUpdate -= CanBuild;
    }
    #endregion

    #region Custom Methods
    private void CanBuild()
    {
        if (_ressourcesManager == null || button == null) return;
        if (_ressourcesManager.CurrentEnergy >= energyCost &&
            _ressourcesManager.CurrentMetal >= metalCost)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
    #endregion
}
