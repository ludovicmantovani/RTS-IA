using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Item
{
    [CreateAssetMenu(menuName =("ScriptableObject/Inventory/Item"))]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField] private string displayName = null;
        [SerializeField] [TextArea] private string description = null;
        [SerializeField] private Sprite icon = null;
        [SerializeField] private GameObject prefab = null;
        [SerializeField] private float pv = 100;
        [SerializeField] private float shield = 0;
        [SerializeField] private float damage = 0;
    }
}
