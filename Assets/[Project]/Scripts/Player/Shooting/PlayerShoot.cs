using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject levitatingBubblePrefab;
    public GameObject normalBubblePrefab;

    public Transform bubbleSpawnTransform;

    private bool isShooting;
    private bool normalBubbleMode = true;

    [Range(0, 10f)] public float normalShootCost;
    [Range(0, 10f)] public float levitatingShootCost;

    public SOLFloatValue bubbleFuel;

    public float normalShootingCooldown;
    public float timeBetweenShootCooldown;
    private bool canNormalShoot;

    public float levitatingShootCooldown;
    private bool canLevitatingShoot;

    private void Awake()
    {
        bubbleFuel.Value = 100;
        canNormalShoot = true; 
        canLevitatingShoot = true;
    }

    private void Update()
    {
        if (isShooting)
        {
            if (bubbleFuel.Value > 0)
            {
                if (normalBubbleMode && canNormalShoot)
                {
                    StartCoroutine(normalShoot(timeBetweenShootCooldown));
                    bubbleFuel.Value -= normalShootCost;
                }
                if(!normalBubbleMode && canLevitatingShoot)
                {
                    StartCoroutine(levitatingShoot(levitatingShootCooldown));
                    bubbleFuel.Value -= levitatingShootCost;
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

    public IEnumerator normalShoot(float timeBetweenShoot)
    {
        canNormalShoot = false;

        Instantiate(normalBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
        yield return new WaitForSeconds(timeBetweenShoot);

        Instantiate(normalBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
        yield return new WaitForSeconds(timeBetweenShoot);

        Instantiate(normalBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
        yield return new WaitForSeconds(normalShootingCooldown);

        canNormalShoot = true;
    }

    public IEnumerator levitatingShoot(float timeBetweenShoot)
    {
        canLevitatingShoot = false;
        Instantiate(levitatingBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
        yield return new WaitForSeconds(timeBetweenShoot);
        canLevitatingShoot = true;
    }
}
