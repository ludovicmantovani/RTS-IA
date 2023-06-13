using System.Collections;
using System.Collections.Generic;
using Inventory.Inventory;
using Inventory.Item;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    #region Variables
    [SerializeField] private InventorySystem inventory = null;
    [SerializeField] private UnitTemplate unitTemplate;
    [SerializeField] private Vector3 spawnPoint;

    private RessourcesManager _ressourcesManager = null;
    #endregion

    #region Built in Methods
    void Start()
    {
        _ressourcesManager = RessourcesManager.instance;
    }

    void Update()
    {
        
    }
    #endregion

    #region Custom Methods
    public void SpawnUnit()
    {
        inventory.AddUnit(unitTemplate, spawnPoint);
        _ressourcesManager.CurrentEnergy -= unitTemplate.EnergyCost;
        _ressourcesManager.CurrentMetal -= unitTemplate.MetalCost;
    }
    #endregion
}
