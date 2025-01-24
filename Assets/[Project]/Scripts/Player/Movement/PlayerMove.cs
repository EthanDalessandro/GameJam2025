using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Skins")]
    public GameObject playerSkinFront;
    public GameObject playerSkinBack;
    private Animator playerFrontAnimator;
    private Animator playerBackAnimator;
    [Header("Walking")]
    public AnimationClip frontWalkingDown;
    public AnimationClip backWalkingUp;
    [Header("Idles")]
    public AnimationClip frontIdling;
    public AnimationClip backIdling;

    public float moveSpeed;

    private Vector2 moveDirection;
    private Rigidbody rb;

    private void Awake()
    {
        playerFrontAnimator = playerSkinFront.GetComponent<Animator>();
        playerBackAnimator = playerSkinBack.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
    }

    public void OnPlayerMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
            if (moveDirection.y > 0) //going up
            {
                playerSkinFront.SetActive(false);
                playerSkinBack.SetActive(true);
                playerBackAnimator.Play(backWalkingUp.name);
            }
            if (moveDirection.y < 0) //going down
            {
                playerSkinBack.SetActive(false);
                playerSkinFront.SetActive(true);
                playerFrontAnimator.Play(frontWalkingDown.name);
            }
        }
        else
        {
            moveDirection = Vector2.zero;
            if (playerSkinBack.activeInHierarchy == true)
                playerBackAnimator.Play(backIdling.name);
            if (playerSkinFront.activeInHierarchy == true)
                playerFrontAnimator.Play(frontIdling.name);

        }
    }
}
