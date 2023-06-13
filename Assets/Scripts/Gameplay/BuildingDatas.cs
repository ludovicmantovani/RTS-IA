using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingDatas
{
    [SerializeField] private string name;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float energyGainTimer;
    [SerializeField] private int energyCost;
    [SerializeField] private int metalCost;

    public string Name => name;
    public GameObject Prefab => prefab;
    public int MetalCost => metalCost;
    public float EnergyGainTimer => energyGainTimer;
    public int EnergyCost => energyCost;

}