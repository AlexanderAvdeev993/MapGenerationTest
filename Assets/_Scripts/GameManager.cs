using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Factory _factory;
    [SerializeField] private Transform _startPosition;
    


    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        //_factory.SpawnChunk(_startPosition.transform);
        //_factory.SpawnObject(_startPosition.position, _player);       
    }

}
