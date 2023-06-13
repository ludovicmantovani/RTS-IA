using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetRessourcesText : MonoBehaviour
{
    #region Variables
    [SerializeField] private TextMeshProUGUI textMPEnergy = null;
    [SerializeField] private TextMeshProUGUI textMPMetal = null;
    private RessourcesManager _ressourcesManager = null;
    #endregion

    #region Built in Methods
    void Start()
    {
        _ressourcesManager = RessourcesManager.instance;
        if (_ressourcesManager) SetText();
    }

    void Update()
    {

    }
    #endregion

    #region Custom Methods
    private void SetText()
    {
        if (_ressourcesManager == null) return;
        textMPEnergy.SetText(_ressourcesManager.CurrentEnergy.ToString());
        textMPMetal.SetText(_ressourcesManager.CurrentMetal.ToString());
    }
    #endregion
}
