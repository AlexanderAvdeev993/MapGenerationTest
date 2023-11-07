using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject[] _doors;
    [SerializeField] private Factory _factory;    
    private bool triggered = false;
    public LayerMask chunkLayer;
    public Transform[] _obstacleSpawnPositions;

    private void Start()
    {           
        OpenDoors();
    }
    private void OpenDoors()             // двери на префабе закрыты, тут рандомно открываю некоторые
    {
        List<int> doorIndices = new List<int>(_doors.Length);
        for (int i = 0; i < _doors.Length; i++)
        {
            doorIndices.Add(i);
        }
        int doorsToOpen = Random.Range(1, _doors.Length);
       
        for (int i = 0; i < doorsToOpen; i++)
        { 
            int randomIndex = Random.Range(i, doorIndices.Count);
            int selectedDoorIndex = doorIndices[randomIndex];
           
            _doors[selectedDoorIndex].SetActive(false);

            doorIndices.RemoveAt(randomIndex);
        }
    }
    
    private bool CanSpawnChunkInDirection(Transform doorTransform)  // проверяет на наличие чанков на месте спавна
    {
        Vector3 direction = doorTransform.forward;
        float rayLength = 10f;
        Ray ray = new Ray(doorTransform.position, direction);
            
        if (Physics.Raycast(ray, rayLength, chunkLayer))                 
            return false;
             
        return true;
    }

    private void OnTriggerEnter(Collider other)    // триггер на каждом чанке для спавна соседних чанков
    {     
        if(!triggered)
        {
            triggered = true;
            foreach (var door in _doors)
            {
                if (!door.activeSelf && CanSpawnChunkInDirection(door.transform))                               
                    _factory.SpawnChunk(door.transform);               
            }
        }             
    }  
}
