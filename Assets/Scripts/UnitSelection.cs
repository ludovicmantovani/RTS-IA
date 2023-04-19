using Inventory.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    [SerializeField] private LayerMask unitLayerMask;
    [SerializeField] private RectTransform selectionBox;

    private List<Unit> _selectedUnits = new List<Unit>();
    private Vector2 _startPos;

    private Camera _cam;
    private InventorySystem _inventory;
    
    void Awake()
    {
        _cam = Camera.main;
        _inventory = GetComponent<InventorySystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleSelectionVisual(false);
            _selectedUnits = new List<Unit>();
            TrySelect(Input.mousePosition);
            _startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReleaseSelectionBox();
        }

        if (Input.GetMouseButton(0))
        {
            UpdateSelectionBox(Input.mousePosition);
        }
    }

    void ReleaseSelectionBox()
    {
        selectionBox.gameObject.SetActive(false);
        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);
        foreach (Unit unit in _inventory.Units)
        {
            Vector3 screenPos = _cam.WorldToScreenPoint(unit.transform.position);

            if (screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y)
 {
                _selectedUnits.Add(unit);
                unit.GetComponent<UnitController>().ToggleSelectionVisual(true);
            }
        }
    }

    void UpdateSelectionBox(Vector2 curMousePos)
    {
        if (!selectionBox.gameObject.activeInHierarchy)
            selectionBox.gameObject.SetActive(true);
        float width = curMousePos.x - _startPos.x;
        float height = curMousePos.y - _startPos.y;
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = _startPos + new Vector2(width / 2, height / 2);
    }

    void TrySelect(Vector2 screenPos)
    {
        Ray ray = _cam.ScreenPointToRay(screenPos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, unitLayerMask))
        {
            Unit unit = hit.collider.GetComponent<Unit>();
            if (_inventory.IsMyUnit(unit))
            {
                _selectedUnits.Add(unit);
                unit.GetComponent<UnitController>().ToggleSelectionVisual(true);
            }
        }
    }

    void ToggleSelectionVisual(bool selected)
    {
        foreach (Unit unit in _selectedUnits)
        {
            unit.GetComponent<UnitController>().ToggleSelectionVisual(selected);
        }
    }

    public bool HasUnitsSelected()
    {
        return _selectedUnits.Count > 0 ? true : false;
    }


    public Unit[] GetSelectedUnits()
    {
        return _selectedUnits.ToArray();
    }
}
