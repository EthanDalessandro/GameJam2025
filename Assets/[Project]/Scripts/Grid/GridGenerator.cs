using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public SOListOfObject listOfPrefabs;
    public GameObject[] playerPrefabs = new GameObject[3];

    public Vector2 gridSize;
    public Vector2 offSet;

    private void Start()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Vector3 posToSpawn = new Vector3(j * offSet.x, transform.position.y, i * offSet.y);

                GameObject actualObject = Instantiate(listOfPrefabs.GetPrefab(), posToSpawn, Quaternion.identity, transform);

                SpawnPlayer(i, j, 0, 0, playerPrefabs[0]);
                SpawnPlayer(i, j, 0, (int)gridSize.x - 1, playerPrefabs[1]);
                SpawnPlayer(i, j, (int)gridSize.y - 1, 0, playerPrefabs[2]);
                SpawnPlayer(i, j, (int)gridSize.y - 1, (int)gridSize.x - 1, playerPrefabs[3]);
            }
        }
    }

    public void SpawnPlayer(int i, int j, int checkI, int checkJ, GameObject playerToSpawn)
    {
        if (i == checkI && j == checkJ)
        {
            //Instantiate(playerToSpawn, new Vector3(j * offSet.x, transform.position.y, i * offSet.y), Quaternion.identity, transform);
        }
    }
}