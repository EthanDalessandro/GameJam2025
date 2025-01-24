using UnityEngine;

public class ChargingBubblePowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerShoot>() != null)
            {
                other.GetComponent<PlayerShoot>().ChargingBubbleTrigger();
                Destroy(gameObject);
            }
        }
    }
}
