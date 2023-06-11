using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    //[SerializeField] private int numPlayer = 0;
    [SerializeField] private GameObject player;

    private int _energyMax;
    private int _energyDispo;
    private int _currentEnergy;
    private int _tiberium;

    private Spawner[] _spawners;

    //private UIManager _UI;

    public static GameManager instance;
    #endregion

    #region Builtin Methods
    void Awake(){
        if(instance==null)
            instance = this;
        else
            Destroy(gameObject);

        _spawners = FindObjectsOfType<Spawner>();
    }

    void Start()
    {
        //_UI = UIManager.instance;

        //player.transform.position = new Vector3(_spawners[numPlayer].transform.position.x, 0, _spawners[numPlayer].transform.position.z);
        //StartCoroutine(_spawners[numPlayer].UnhideBase());
    }

    void Update()
    {
        
    }
    #endregion

    #region Custom Methods
    public void AddEnergyMax(int value){
        _energyMax += value;
    }

    public void AddEnergyDispo(int value){
        _energyDispo += value;

        //_UI.UpdateEnergyUI(_energyDispo);
    }

    public void RemoveEnergyDispo(int value){
        _energyDispo -= value;
    }

    public void AddCurrentEnergy(int value){
        _currentEnergy += value;

        if(_currentEnergy > _energyDispo){
            Debug.Log("Probleme");
        }
    }
    #endregion
}
