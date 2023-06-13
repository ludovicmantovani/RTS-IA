using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    #region Variables
    public RessourcesManager _ressourcesManager = null;
    public BuildingDatas _datas;

    public BuildingDatas Datas{
        set{
            _datas = value;
        }
    }
    #endregion

    #region Built in Methods
    void Start()
    {

    }

    void Update()
    {
        
    }

    public virtual void OnEnable(){
        _ressourcesManager = RessourcesManager.instance;
        Cost();
        SetParameters();
    }
    #endregion

    #region Custom Methods
    void Cost(){
        if (_ressourcesManager != null)
        {
            _ressourcesManager.CurrentMetal -= _datas.MetalCost;
            _ressourcesManager.CurrentEnergy -= _datas.EnergyCost;
        }
    }

    void SetParameters(){

    }
    #endregion
}
