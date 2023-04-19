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
        [SerializeField] private float pv = 100;
        [SerializeField] private float shield = 0;
        [SerializeField] private float damage = 0;

        public float Pv { get => pv; }
        public float Shield { get => shield; }
        public float Damage { get => damage; }
        public string DisplayName { get => displayName; }
        public GameObject Prefab { get => prefab; }
    }
}
