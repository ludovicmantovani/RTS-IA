using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Units")]
    [SerializeField] private List<Unit> units = new List<Unit>();

    public List<Unit> Units { get => units;}

    // is this my unit?
    public bool IsMyUnit(Unit unit)
    {
        return units.Contains(unit);
    }

}
