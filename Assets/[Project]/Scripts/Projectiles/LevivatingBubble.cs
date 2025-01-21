using UnityEngine;
using UnityEngine.EventSystems;

public class LevivatingBubble : MonoBehaviour
{
    private Rigidbody rb;

    public float projectileSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Force);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / (projectileSpeed) + 200, rb.velocity.z) * Time.fixedDeltaTime;
    }
}
