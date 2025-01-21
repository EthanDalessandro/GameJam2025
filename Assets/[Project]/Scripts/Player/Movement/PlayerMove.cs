using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 moveDirection;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMovement = transform.forward * moveDirection.y;
        Vector3 sideMovement = transform.right * moveDirection.x;

        Vector3 move = (forwardMovement + sideMovement).normalized * moveSpeed;

        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else
        {
            moveDirection = Vector2.zero;
        }
    }
}
