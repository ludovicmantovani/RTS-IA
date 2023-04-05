using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField] private GameObject selectionVisual;

    private NavMeshAgent _navAgent = null;

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

}
