using Inventory.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Inventory
{
    public class InventorySystem : MonoBehaviour
    {
        [Header("Units")]
        [SerializeField] private List<Unit> units = new List<Unit>();
        [SerializeField] private Transform unitsParent;

        public List<Unit> Units { get => units; }

        public bool IsMyUnit(Unit unit)
        {
            return units.Contains(unit);
        }
        public void AddUnit(UnitTemplate newUnit, Vector3 targetPosition)
        {
            GameObject goInstance = Instantiate(newUnit.Prefab, unitsParent);
            goInstance.transform.position = new Vector3(
                targetPosition.x,
                targetPosition.y,
                targetPosition.z);
            Unit unitInstance = goInstance.GetComponent<Unit>();
            units.Add(unitInstance);
        }

        public bool RemoveUnit(Unit oldUnit)
        {
            if (units.Contains(oldUnit))
            {
                units.Remove(oldUnit);
            }
            return false;
        }
    }
}
