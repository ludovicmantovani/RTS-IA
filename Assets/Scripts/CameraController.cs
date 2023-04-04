using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private float horizontal = 0f;
    private float vertical = 0f;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0);
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);
    }

    void LateUpdate()
    {
        horizontal = 0f;
        vertical = 0f;
    }
}
