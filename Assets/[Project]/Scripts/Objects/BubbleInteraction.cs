using UnityEngine;

public class BubbleInteraction : MonoBehaviour
{
    private Rigidbody rb;

    private bool isLevitating;

    public float tresholdToLevitate;
    private float actualAmount;

    public AnimationCurve curve;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isLevitating = false;
    }

    public void GetHit(float amount)
    {
        if (!isLevitating)
        {
            actualAmount += amount;

            if(actualAmount > tresholdToLevitate)
            {
                isLevitating = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if(isLevitating)
        {
            Vector3 move = new Vector3(0,1,0);
            move.y = curve.Evaluate(Time.time);
            rb.velocity = new Vector3(rb.velocity.x, move.y, rb.velocity.z);
        }
    }
}
