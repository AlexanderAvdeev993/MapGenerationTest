using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public delegate void ChunkEnteredEventHandler(Chunk chunk);
    public event ChunkEnteredEventHandler OnChunkEntered;

    public Transform[] ObstacleSpawnPositions;
    public GameObject[] Doors;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("wq");
    }

    public void EnterChunk()
    {
        OnChunkEntered?.Invoke(this);
    }
}
