using UnityEngine;

public class UnitMoveAnim : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private float movementThreshold = 0.01f;
    [SerializeField] private float walkAnimationSpeed = 25f;
    
    private Vector3 _lastPosition;
    private bool _isInMove = false;
    
    void Start()
    {
        _lastPosition = transform.position;
    }

    void Update()
    {
        if (animator == null) return;

        float movement = Vector3.Magnitude(transform.position - _lastPosition);
        _isInMove = movement > movementThreshold;
        animator.SetFloat("MoveAnimationSpeed", walkAnimationSpeed * movement);
        animator.SetBool("IsInMove", _isInMove);
        _lastPosition = transform.position;
    }
}
