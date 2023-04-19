using System;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField] private GameObject selectionVisual;

    private NavMeshAgent _navAgent = null;
    private Player _player = null;

    void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    public void ToggleSelectionVisual(bool selected)
    {
        selectionVisual.SetActive(selected);
    }

    public void MoveToPosition(Vector3 pos)
    {
        _navAgent.isStopped = false;
        _navAgent.SetDestination(pos);
    }

    public void SetPlayer(Player player)
    {
        _player = player;
        SetColor(player.PlayerColor);
    }

    private void SetColor(Color playerColor)
    {
        throw new NotImplementedException();
    }
}
