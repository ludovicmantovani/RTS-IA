using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] private Color playerColor = Color.blue;

    [Header("Units")]
    [SerializeField] private List<Unit> units = new List<Unit>();

    public Color PlayerColor { get => playerColor;}
    public List<Unit> Units { get => units;}

    public bool IsMyUnit(Unit unit)
    {
        return units.Contains(unit);
    }

    public void AddUnit(Unit newUnit)
    {
        units.Add(newUnit);
        newUnit.SetPlayer(this);
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
