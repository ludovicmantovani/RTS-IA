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
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Unit[] selectedUnits = _unitSelection.GetSelectedUnits();
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    UnitsMoveToPosition(hit.point, selectedUnits);
                }
            }
        }
    }

    private void UnitsMoveToPosition(Vector3 movePos, Unit[] units)
    {
        Vector3[] destinations = UnitMover.GetUnitGroupDestinations(movePos, units.Length, 2);
        for (int x = 0; x < units.Length; x++)
        {
            units[x].GetComponent<UnitController>().MoveToPosition(destinations[x]);
        }
    }

}
