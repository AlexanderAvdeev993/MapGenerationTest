using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Factory : MonoBehaviour 
{

    public void SpawnChunk(Vector3 position, GameObject spawnObject, GameObject[] obstaclePrefabs, float obstacleSpawnChance)
    {      
        GameObject chunkContainer = new GameObject("ChunkContainer");                   
        GameObject chunkObject = Instantiate(spawnObject, position, Quaternion.identity, chunkContainer.transform);
        Chunk chunk = chunkObject.GetComponent<Chunk>();
        if (chunk == null) return;

        foreach (Transform spawnPosition in chunk.ObstacleSpawnPositions)
        {
            if (Random.value < obstacleSpawnChance)
            {
                int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);             
                Instantiate(obstaclePrefabs[randomObstacleIndex], spawnPosition.position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f), chunkContainer.transform);
            }
        }
    }

    public void SpawnObject(Vector3 position, GameObject _spawnObject)
    {
        GameObject gameObject = Instantiate(_spawnObject, position, Quaternion.identity);        
    }
}
