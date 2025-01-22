using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public Transform head;
    public Vector2 clampHeadRotation; // Min et max en degrés
    public float rotateSpeed;

    private Vector2 rotateDirection;

    private void Update()
    {
        // Rotation du corps
        transform.localEulerAngles += new Vector3(0, rotateDirection.x * rotateSpeed, 0);

        // Rotation de la tête
        Vector3 headEulerAngles = head.localEulerAngles;

        // Ajuster l'angle X de la tête (pitch) avec le clamp
        headEulerAngles.x -= rotateDirection.y * rotateSpeed / 2;
        headEulerAngles.x = ClampAngle(headEulerAngles.x, clampHeadRotation.x, clampHeadRotation.y);

        // Appliquer la rotation clampée
        head.localEulerAngles = headEulerAngles;
    }

    public void OnRotateCamera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rotateDirection = context.ReadValue<Vector2>();
        }
        else
        {
            rotateDirection = Vector2.zero;
        }
    }

    // Fonction pour clamping des angles entre -180 et 180 degrés
    private float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if (angle < -180) angle += 360;
        if (angle > 180) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
