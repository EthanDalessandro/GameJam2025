using UnityEngine;

public class obstacleBehaviour : MonoBehaviour
{
    public Transform child;
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(new(transform.position.x, transform.position.y - child.transform.localScale.y / 2, transform.position.z), Vector3.down, out hit);
        if (hit.transform.CompareTag("Obstacle"))
        {
            Debug.Log("aie");
            DestroyImmediate(gameObject);

        }
    }

}
