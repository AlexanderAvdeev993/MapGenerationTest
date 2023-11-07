using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField][Range(0.0f, 1.0f)] private float _obstacleSpawnChance;    
    public void SpawnChunk(Transform spawnChankPosition)
    {
        GameObject chunkContainer = new GameObject("ChunkContainer");
        GameObject chunkObject = Instantiate(_chunkPrefab,
            spawnChankPosition.position + spawnChankPosition.forward * 10f,
            spawnChankPosition.rotation, chunkContainer.transform);

        Chunk chunk = chunkObject.GetComponent<Chunk>();

        if (chunk == null) return;

        foreach (Transform spawnObstaclePosition in chunk._obstacleSpawnPositions)
        {
            if (Random.value < _obstacleSpawnChance)
            {
                int randomObstacleIndex = Random.Range(0, _obstaclePrefabs.Length);
                Instantiate(_obstaclePrefabs[randomObstacleIndex],
                             spawnObstaclePosition.position,
                             Quaternion.Euler(0f, Random.Range(0f, 360f), 0f),
                             chunkContainer.transform);
            }
        }      
    }
}
