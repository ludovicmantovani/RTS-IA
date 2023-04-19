using Inventory.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float _pv;
    private float _shield;
    private float _damage;

    public void SetData(UnitTemplate unitTemplate)
    {
        _pv = unitTemplate.Pv;
        _shield = unitTemplate.Shield;
        _damage = unitTemplate.Damage;
    }
}
