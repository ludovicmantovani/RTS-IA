using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    #region Variables
    public GameManager _GM;
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
        _GM = GameManager.instance;
        
        CostTiberium();
        PlayPlacementAnimation();
        PlayPlacementSound();
        SetParameters();
    }
    #endregion

    #region Custom Methods
    void CostTiberium(){
        Debug.Log("C CHER LOL");
    }

    void PlayPlacementAnimation(){

    }

    void PlayPlacementSound(){

    }

    void SetParameters(){

    }
    #endregion
}
