using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Building
{
    #region Variables
    private bool _gainEnergy = false;
    private float _lastTime = 0f;
    #endregion

    #region Built in Methods
    void Start()
    {
        
    }

    void Update()
    {
        if (_gainEnergy && Time.time > _lastTime + _datas.EnergyGainTimer)
        {
            _lastTime = Time.time;
            _ressourcesManager.CurrentEnergy += 1;
        }
    }

    public override void OnEnable(){
        base.OnEnable();

        _gainEnergy = true;
    }
    #endregion

    #region Custom Methods
    #endregion
}
