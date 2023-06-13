using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Item
{
    [CreateAssetMenu(menuName =("ScriptableObject/Inventory/UnitTemplate"))]
    public class UnitTemplate : ScriptableObject
    {
        [SerializeField] private string displayName = null;
        [SerializeField] private GameObject prefab = null;
        [SerializeField] private int pv = 15;
        [SerializeField] private int shield = 15;
        [SerializeField] private int minAttackDamage = 1;
        [SerializeField] private int maxAttackDamage = 3;
        [SerializeField] private float attackRate = 0.5f;
        [SerializeField] private float attackDistance = 0.5f;
        [SerializeField] private int energyCost = 1;
        [SerializeField] private int metalCost = 1;

        public int Pv { get => pv; }
        public int Shield { get => shield; }
        public string DisplayName { get => displayName; }
        public GameObject Prefab { get => prefab; }
        public int MinAttackDamage { get => minAttackDamage;}
        public int MaxAttackDamage { get => maxAttackDamage;}
        public float AttackRate { get => attackRate;}
        public float AttackDistance { get => attackDistance; }
        public int EnergyCost { get => energyCost; }
        public int MetalCost { get => metalCost; }
    }
}
