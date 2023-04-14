using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float moveSpeed = 500f;
    [SerializeField] private float scrollSpeed = 10f;
    [SerializeField] private float smoothTime = 0.5f;
    
    [Header("Translation")]
    [SerializeField] private float minXPosition = 12f;
    [SerializeField] private float maxXPosition = 95f;
    [SerializeField] private float minZPosition = -2f;
    [SerializeField] private float maxZPosition = 88f;
    
    [Header("Zoom")]
    [SerializeField] private float minYScroll = 15f;
    [SerializeField] private float maxYScroll = 80f;
    
    private bool canZoom = true;
    private Vector3 velocity;
    private float targetZoom;

    public bool CanZoom { get => canZoom; set => canZoom = value; }

    void Start()
    {
        targetZoom = transform.position.y;
    }

    void Update()
    {
        Locomotion();
    }

    private void Locomotion()
    {
        // Déplacement de la caméra
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 targetPosition = transform.position + new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if (canZoom)
        {
            // Zoom de la caméra
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            targetZoom -= scroll * scrollSpeed * 1000 * Time.deltaTime;
            targetZoom = Mathf.Clamp(targetZoom, minYScroll, maxYScroll);
            float currentZoom = Mathf.SmoothDamp(transform.position.y, targetZoom, ref velocity.y, smoothTime);
            transform.position = new Vector3(transform.position.x, currentZoom, transform.position.z);
        }
    }
}
