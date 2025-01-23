using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    public float shield;

    public void GetHit(float AmountTaken)
    {
        if(shield > 0)
        {
            shield -= 1;
        }
        else
        {
            health -= AmountTaken;

            if(health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
