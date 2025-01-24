using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    [SerializeField] Transform parent; 
    // Update is called once per frame
    void LateUpdate()
    {
        transform.localEulerAngles = new(90, -parent.localEulerAngles.y, 0);
    }
}
