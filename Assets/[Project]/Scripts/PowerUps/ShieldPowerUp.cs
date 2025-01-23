using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public int shieldAdded;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerHealth>() != null)
            {
                other.GetComponent<PlayerHealth>().AddShield(shieldAdded);
                Destroy(gameObject);
            }
        }
    }
}
