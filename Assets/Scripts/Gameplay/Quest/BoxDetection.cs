using Inventory.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetection : MonoBehaviour
{
    [SerializeField] private List<GameObject> boxDetectors;
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private List<Unit> units;

    public void Detected()
    {
        foreach (GameObject go in boxDetectors)
        {
            Destroy(go);
        }

        if (inventorySystem != null)
        {
            foreach (Unit unit in units)
            {
                inventorySystem.AddUnit(unit);
            }
        }
    }
}
