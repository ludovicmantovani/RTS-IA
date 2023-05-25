using Inventory.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    public float checkRate = 1.0f;
    public float nearbyEnemyAttackRange;
    public LayerMask unitLayerMask;

    private Unit _unit;

    public void InitializeAI(Unit unit)
    {
        _unit = unit;
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        _unit = GetComponent<Unit>();
        InvokeRepeating("Check", 0.0f, checkRate);
    }

    void Check()
    {
        if (_unit.State != UnitState.Attack && _unit.State != UnitState.MoveToEnemy)
        {
            Unit potentialEnemy = CheckForNearbyEnemies();

            if (potentialEnemy != null)
            {
                _unit.AttackUnit(potentialEnemy);
            }
        }


    }

    Unit CheckForNearbyEnemies()
    {
        RaycastHit[] hits = Physics.SphereCastAll(
            transform.position, nearbyEnemyAttackRange,
            Vector3.up, unitLayerMask);
        GameObject closest = null;
        float closestDist = nearbyEnemyAttackRange;
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject == gameObject)
            {
                continue;
            }
            if (_unit.Player.GetComponent<InventorySystem>().IsMyUnit(
                hits[i].collider.gameObject.GetComponent<Unit>()))
            {
                continue;
            }
            if (!closest || Vector3.Distance(transform.position, hits[i].transform.position) < closestDist)
            {
                closest = hits[i].collider.gameObject;
                closestDist = Vector3.Distance(transform.position, hits[i].transform.position);
            }
        }
        return closest != null ? closest.GetComponent<Unit>() : null;
    }
}
