using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject levitatingBubblePrefab;
    public GameObject normalBubblePrefab;

    public Transform bubbleSpawnTransform;

    private bool isShooting;
    private bool normalBubbleMode = true;

    [Range(0, 0.20f)] public float normalShootCost;
    [Range(0, 0.20f)] public float levitatingShootCost;

    public SOLFloatValue bubbleFuel;

    public float shootingCooldown;
    private float shootCD;

    private void Awake()
    {
        bubbleFuel.Value = 100;
    }

    private void Update()
    {
        if (shootCD <= shootingCooldown)
        {
            shootCD += Time.deltaTime;
        }

        if (isShooting && shootCD >= shootingCooldown)
        {
            shootCD = 0;

            if (bubbleFuel.Value > 0)
            {
                if (normalBubbleMode)
                {
                    bubbleFuel.Value -= normalShootCost;
                    GameObject currentBubble = Instantiate(normalBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
                }
                else
                {
                    bubbleFuel.Value -= levitatingShootCost;
                    GameObject currentBubble = Instantiate(levitatingBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
                }
            }
        }
    }

    public void OnPlayerShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }

    public void OnPlayerSwitchMode(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            normalBubbleMode = !normalBubbleMode;
        }
    }
}
