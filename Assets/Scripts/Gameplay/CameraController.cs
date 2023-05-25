using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float moveSpeed = 500f;
    [SerializeField] private float scrollSpeed = 10f;
    [SerializeField] private float smoothTime = 0.5f;
    
    [Header("Translation")]
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;

    [Header("Zoom")]
    [SerializeField] private float minYScroll = 15f;
    [SerializeField] private float maxYScroll = 80f;
    
    private bool _canZoom = true;
    private Vector3 _velocity;
    private float _targetZoom;
    private bool _canMoveByUser = true;

    public bool CanZoom { get => _canZoom; set => _canZoom = value; }
    public bool CanMoveByUser { get => _canMoveByUser; set => _canMoveByUser = value; }

    void Start()
    {
        _targetZoom = transform.position.y;
    }

    void Update()
    {
        if (_canMoveByUser)
        {
            Locomotion();
        }
    }

    private void Locomotion()
    {
        // Déplacement de la caméra
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 targetPosition = transform.position + moveSpeed * Time.deltaTime * new Vector3(horizontal, 0, vertical);
        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        targetPosition.z = Mathf.Clamp(targetPosition.z, minBounds.y, maxBounds.y);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);

        if (_canZoom)
        {
            // Zoom de la caméra
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            _targetZoom -= scroll * scrollSpeed * 1000 * Time.deltaTime;
            _targetZoom = Mathf.Clamp(_targetZoom, minYScroll, maxYScroll);
            float currentZoom = Mathf.SmoothDamp(transform.position.y, _targetZoom, ref _velocity.y, smoothTime);
            transform.position = new Vector3(transform.position.x, currentZoom, transform.position.z);
        }
    }

    public void SmoothMoveCamera(Vector3 targetPosition, float targetZoom)
    {
        _canMoveByUser = false;
        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x, maxBounds.x);
        targetPosition.z = Mathf.Clamp(targetPosition.z, minBounds.y, maxBounds.y);
        targetZoom = Mathf.Clamp(targetZoom, minYScroll, maxYScroll);
        Vector3 currentVelocity = Vector3.zero;
        float currentZoom = transform.position.y;
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f || Mathf.Abs(currentZoom - targetZoom) > 0.1f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
            currentZoom = Mathf.SmoothDamp(currentZoom, targetZoom, ref _velocity.y, smoothTime);
            transform.position = new Vector3(transform.position.x, currentZoom, transform.position.z);
            if (Vector3.Distance(transform.position, targetPosition) <= 0.1f && Mathf.Abs(currentZoom - targetZoom) <= 0.1f)
            {
                break;
            }
        }
        _canMoveByUser = true;
    }
}
