using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    private Rigidbody rb;

    public float rotateSpeed;

    public Vector2 directionToLookAt;
    public Vector2 deadzone;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.LookAt(new Vector3(directionToLookAt.x, 0, directionToLookAt.y) + transform.position, Vector3.up);
    }

    public void OnCameraRotation(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            directionToLookAt = context.ReadValue<Vector2>();
        }
    }
}
