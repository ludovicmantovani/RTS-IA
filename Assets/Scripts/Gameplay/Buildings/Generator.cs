using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Building
{
    #region Variables
    #endregion

    #region Built in Methods
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void OnEnable(){
        base.OnEnable();

        GainEnergy();
    }
    #endregion

    #region Custom Methods
    void GainEnergy(){
        Debug.Log(_datas.EnergyGain);
        _GM.AddEnergyDispo(_datas.EnergyGain);
    }
    #endregion
}
