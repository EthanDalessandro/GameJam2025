using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerReload : MonoBehaviour
{
    public BubbleFuel bubbleFuel;

    public float fuelAddedPerReload;

    private float stickGoalToGainFuel;
    private Vector2 currentStickPosition;
    private bool isStickUp;

    private void Awake()
    {
        bubbleFuel = GetComponent<BubbleFuel>();
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            currentStickPosition = context.ReadValue<Vector2>();
            IsGoalReached();
        }
    }

    public void IsGoalReached()
    {
        if(isStickUp)
        {
            if(currentStickPosition.y < -0.5f)
            {
                GainFuel();
                isStickUp = false;
            }
        }
        else
        {
            if(currentStickPosition.y > 0.5f)
            {
                GainFuel();
                isStickUp = true;
            }
        }
    }

    public void GainFuel()
    {
        if(bubbleFuel.bubbleFuel < 101)
        {
            bubbleFuel.bubbleFuel += fuelAddedPerReload;
        }
    }
}
