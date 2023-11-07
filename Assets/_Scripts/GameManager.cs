using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Factory _factory;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private GameObject[] _obstaclePrefabs;

    [SerializeField][Range(0.0f, 1.0f)] private float _obstacleSpawnChance;


    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        _factory.SpawnChunk(_startPosition.position, _chunkPrefab, _obstaclePrefabs, _obstacleSpawnChance);
        //_factory.SpawnObject(_startPosition.position, _player);       
    }

}
