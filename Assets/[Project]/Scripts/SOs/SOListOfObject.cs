using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ListOfObject")]
public class SOListOfObject : ScriptableObject
{
    public List<GameObject> objects;

    public GameObject GetPrefab()
    {
        return objects[Random.Range(0, objects.Count)];
    }
}
