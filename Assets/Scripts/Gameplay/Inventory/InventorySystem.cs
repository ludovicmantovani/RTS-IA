using Inventory.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inventory.Inventory
{
    public class InventorySystem : MonoBehaviour
    {
        [SerializeField] private Transform unitsParent;
        [SerializeField] private string oldMaterialName = "";

        [SerializeField] private List<Unit> _units = new List<Unit>();
        private Player _player;

        public List<Unit> Units { get => _units; }

        public bool isMe;
        public static InventorySystem me;

        private void Awake()
        {
            if (isMe)
            {
                me = this;
            }
        }

        private void Start()
        {
            _player = GetComponent<Player>();
        }

        public bool IsMyUnit(Unit unit)
        {
            return _units.Contains(unit);
        }

        public void AddUnit(Unit unit)
        {
            if (_player != null) unit.SetPlayer(_player);
            _units.Add(unit);
            ReplaceMaterialRecursively(unit.gameObject);
        }

        public void AddUnit(UnitTemplate newUnit, Vector3 targetPosition)
        {
            GameObject goInstance = Instantiate(newUnit.Prefab, unitsParent);
            goInstance.transform.position = new Vector3(
                targetPosition.x,
                targetPosition.y,
                targetPosition.z);
            NavMeshAgent navMeshAgent = null;
            if (goInstance.TryGetComponent<NavMeshAgent>(out navMeshAgent))
            {
                navMeshAgent.Warp(new Vector3(
                targetPosition.x,
                targetPosition.y,
                targetPosition.z));
            }
            AddUnit(goInstance.GetComponent<Unit>());
        }

        public bool RemoveUnit(Unit oldUnit)
        {
            if (_units.Contains(oldUnit))
            {
                _units.Remove(oldUnit);
            }
            return false;
        }

        private void ReplaceMaterialRecursively(GameObject obj)
        {
            if (obj.GetComponent<Renderer>() != null)
            {
                Material[] materials = obj.GetComponent<Renderer>().materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    if (materials[i].name.Contains(oldMaterialName))
                    {
                        materials[i].color = _player.PlayerColor;
                    }
                }
                obj.GetComponent<Renderer>().materials = materials;
            }

            foreach (Transform child in obj.transform)
            {
                ReplaceMaterialRecursively(child.gameObject);
            }
        }
    }
}
