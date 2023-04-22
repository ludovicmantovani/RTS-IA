using System;
using UnityEngine;

public class UnitAnim : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [Header("Move")]
    [SerializeField] private float movementThreshold = 0.01f;
    [SerializeField] private float walkAnimationSpeed = 25f;
    
    private Vector3 _lastPosition;
    private bool _isInMove = false;
    private UnitState _oldState = UnitState.Idle;
    private UnitState _curState = UnitState.Idle;
    
    void Start()
    {
        _lastPosition = transform.position;
    }

    void Update()
    {
        if (animator == null) return;

        switch (_curState)
        {
            case UnitState.Move:
                OnMoveUpdate();
                break;
            case UnitState.MoveToEnemy:
                OnMoveUpdate();
                break;
            case UnitState.Attack:
                OnShootUpdate();
                break;
            default:
                OnIdleUpdate();
                break;
        }
    }

    private void OnIdleUpdate()
    {
        animator.SetBool("IsInMove", false);
        animator.SetBool("IsInShoot", false);
    }

    public void OnStateChange(UnitState state)
    {
        _oldState = _curState;
        _curState = state;
    }

    private void OnMoveUpdate()
    {
        animator.SetBool("IsInShoot", false);
        float movement = Vector3.Magnitude(transform.position - _lastPosition);
        _isInMove = movement > movementThreshold;
        animator.SetFloat("MoveAnimationSpeed", walkAnimationSpeed * movement);
        animator.SetBool("IsInMove", _isInMove);
        _lastPosition = transform.position;
    }

    private void OnShootUpdate()
    {
        animator.SetBool("IsInMove", false);
        animator.SetBool("IsInShoot", true);
    }
}
