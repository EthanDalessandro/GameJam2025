using DG.Tweening;
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

    private bool isChargingBubble = true;

    [Range(0, 10f)] public float normalShootCost;
    [Range(0, 10f)] public float levitatingShootCost;
    public float chargingForce;

    public BubbleFuel bubbleFuel;

    public float normalShootingCooldown;
    public float timeBetweenShootCooldown;
    private bool canNormalShoot;

    public float levitatingShootCooldown;
    private bool canLevitatingShoot;

    private void Awake()
    {
        bubbleFuel = GetComponent<BubbleFuel>();

        isChargingBubble = false;
        canNormalShoot = true;
        canLevitatingShoot = true;
    }

    private void Update()
    {
        if (isShooting)
        {
            if (bubbleFuel.bubbleFuel > 0)
            {
                if (!isChargingBubble)
                {
                    if (normalBubbleMode && canNormalShoot)
                    {
                        StartCoroutine(normalShoot(timeBetweenShootCooldown));
                        bubbleFuel.bubbleFuel -= normalShootCost;
                    }
                    if (!normalBubbleMode && canLevitatingShoot)
                    {
                        StartCoroutine(levitatingShoot(levitatingShootCooldown));
                        bubbleFuel.bubbleFuel -= levitatingShootCost;
                    }
                }
                else
                {
                    chargingForce += Time.deltaTime;
                    bubbleFuel.bubbleFuel -= Time.deltaTime; 

                    if (bubbleFuel.bubbleFuel <= 0 || chargingForce >= 10)
                    {
                        GameObject currentBigBubble = Instantiate(normalBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
                        currentBigBubble.GetComponent<NormalBubble>().SetScale(chargingForce / 2);
                        isChargingBubble = false;
                        chargingForce = 0;
                    }
                }
            }
        }
        else
        {
            if (chargingForce > 0.2f)
            {
                GameObject currentBigBubble = Instantiate(normalBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
                currentBigBubble.GetComponent<NormalBubble>().SetScale(chargingForce / 2);
                isChargingBubble = false;
                chargingForce = 0;
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

        GameObject currentBubble = Instantiate(normalBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
        currentBubble.GetComponent<NormalBubble>().SetFuel(bubbleFuel.bubbleFuel);
        yield return new WaitForSeconds(timeBetweenShoot);

        GameObject currentBubble1 = Instantiate(normalBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
        currentBubble1.GetComponent<NormalBubble>().SetFuel(bubbleFuel.bubbleFuel);
        yield return new WaitForSeconds(timeBetweenShoot);

        GameObject currentBubble2 = Instantiate(normalBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
        currentBubble2.GetComponent<NormalBubble>().SetFuel(bubbleFuel.bubbleFuel);
        DOTween.To(() => bubbleFuel.visual.fillAmount, x => bubbleFuel.visual.fillAmount = x, bubbleFuel.bubbleFuel / 100f, 0.5f);
        yield return new WaitForSeconds(normalShootingCooldown);

        canNormalShoot = true;
    }

    public IEnumerator levitatingShoot(float timeBetweenShoot)
    {
        canLevitatingShoot = false;

        GameObject currentBubble = Instantiate(levitatingBubblePrefab, bubbleSpawnTransform.position, transform.rotation);
        currentBubble.GetComponent<LevivatingBubble>().SetFuel(bubbleFuel.bubbleFuel);
        DOTween.To(() => bubbleFuel.visual.fillAmount, x => bubbleFuel.visual.fillAmount = x, bubbleFuel.bubbleFuel / 100f, 0.5f);
        yield return new WaitForSeconds(timeBetweenShoot);

        canLevitatingShoot = true;
    }

    public void ChargingBubbleTrigger()
    {
        isChargingBubble = true;
    }
}
