using UnityEngine;

public class UnitMoveAnim : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private float movementThreshold = 0.01f;
    [SerializeField] private float walkAnimationSpeed = 1f;
    
    private Vector3 _lastPosition;
    private bool _isInMove = false;
    
    void Start()
    {
        _lastPosition = transform.position;
        if (animator) animator.SetFloat("MoveAnimationSpeed", walkAnimationSpeed);
    }

    void Update()
    {
        if (animator == null) return;

        animator.SetFloat("MoveAnimationSpeed", walkAnimationSpeed);

        float movement = Vector3.Magnitude(transform.position - _lastPosition);
        _isInMove = movement > movementThreshold;
        animator.SetBool("IsInMove", _isInMove);
        _lastPosition = transform.position;
    }
}
