using UnityEngine;
using System.Collections.Generic;

public class RandomCubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public float planeSize = 10f;

    private HashSet<Vector3> usedPositions = new HashSet<Vector3>();

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        int spawnedCubes = 0;

        while (spawnedCubes < numberOfCubes)
        {
            float x = Random.Range(-planeSize / 2 + 0.5f, planeSize / 2 - 0.5f);
            float z = Random.Range(-planeSize / 2 + 0.5f, planeSize / 2 - 0.5f);
            Vector3 spawnPosition = new Vector3(x, 0.5f, z);

            if (!usedPositions.Contains(spawnPosition))
            {
                Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                usedPositions.Add(spawnPosition);
                spawnedCubes++;
            }
        }
    }
}
