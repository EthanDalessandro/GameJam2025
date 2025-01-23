using UnityEngine;

public class NormalBubble : MonoBehaviour
{
    private Rigidbody rb;

    public float projectileSpeed;
    public float projectileDamage;

    private float currentFuel;

    public float lifetime;
    private float currentLifetime;

    private float bubbleFuel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentFuel = bubbleFuel;
    }

    private void FixedUpdate()
    {
        if(currentLifetime > lifetime)
        {
            Destroy(gameObject);
        }
        else
        {
            currentLifetime += Time.fixedDeltaTime;
        }

        rb.AddForce(transform.forward * (projectileSpeed * currentFuel), ForceMode.Force);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / (projectileSpeed) + 25, rb.velocity.z) * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            if(collision.collider.GetComponent<PlayerHealth>() != null)
            {
                collision.collider.GetComponent<PlayerHealth>().GetHit(projectileDamage);
            }
        }
        if(collision.collider.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    public void SetFuel(float fuel)
    {
        bubbleFuel = fuel;
    }

    public void SetScale(float scale)
    {
        transform.GetComponent<SphereCollider>().radius *= scale;
        transform.localScale *= scale;
    }
}
