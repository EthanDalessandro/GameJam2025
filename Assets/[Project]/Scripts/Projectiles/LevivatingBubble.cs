using UnityEngine;
using UnityEngine.EventSystems;

public class LevivatingBubble : MonoBehaviour
{
    private Rigidbody rb;

    public float projectileSpeed;
    public float projectileDamage;

    public SOLFloatValue bubbleFuel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * (projectileSpeed * bubbleFuel.Value), ForceMode.Force);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / (projectileSpeed) + 200, rb.velocity.z) * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<BubbleInteraction>() != null)
        {
            collision.collider.GetComponent<BubbleInteraction>().Hit(projectileDamage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}