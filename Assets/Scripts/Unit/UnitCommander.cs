using Inventory.Inventory;
using UnityEngine;

public class UnitCommander : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private UnitSelection _unitSelection;
    private Camera _cam;

    void Awake()
    {
        _unitSelection = GetComponent<UnitSelection>();
        _cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && _unitSelection.HasUnitsSelected())
        {
            _unitSelection.RemoveNullUnitsFromSelection();

            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Unit[] selectedUnits = _unitSelection.GetSelectedUnits();
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    UnitsMoveToPosition(hit.point, selectedUnits);
                }
                else if (hit.collider.CompareTag("Unit"))
                {
                    Unit enemy = hit.collider.gameObject.GetComponent<Unit>();
                    if (!InventorySystem.me.IsMyUnit(enemy))
                    {
                        UnitsAttackEnemy(enemy, selectedUnits);
                    }
                }
            }
        }
    }

    private void UnitsMoveToPosition(Vector3 movePos, Unit[] units)
    {
        Vector3[] destinations = UnitMover.GetUnitGroupDestinations(movePos, units.Length, 2);
        for (int x = 0; x < units.Length; x++)
        {
            units[x].MoveToPosition(destinations[x]);
        }
    }

    private void UnitsAttackEnemy(Unit target, Unit[] units)
    {
        foreach (Unit unit in units)
        {
            unit.AttackUnit(target);
        }
    }

}
