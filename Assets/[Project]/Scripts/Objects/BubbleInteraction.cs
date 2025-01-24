using UnityEngine;

public class BubbleInteraction : MonoBehaviour
{
    public GameObject bubbleVisual;
    private Rigidbody rb;

    private bool isLevitating;

    public float tresholdToLevitate;
    public float levitationForce;
    private float actualAmount;

    public AnimationCurve curve;

    private void Awake()
    {
        bubbleVisual.SetActive(false);
        rb = GetComponent<Rigidbody>();
        isLevitating = false;
    }

    public void Hit(float amount)
    {
        if (!isLevitating)
        {
            actualAmount += amount;

            if (actualAmount > tresholdToLevitate)
            {
                isLevitating = true;
                bubbleVisual.SetActive(true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isLevitating)
        {
            Vector3 move = new Vector3(0, 1, 0);
            move.y = curve.Evaluate(Time.time);
            rb.velocity = new Vector3(rb.velocity.x, move.y * levitationForce, rb.velocity.z);
        }
    }
}
