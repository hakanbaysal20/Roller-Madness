using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Transform[] spawnPositions;
    private timemanager TimeManager;

    private float nextspawntime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        TimeManager = FindObjectOfType<timemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.timeSinceLevelLoad>=nextspawntime && TimeManager.gameover==false && TimeManager.gameFinished==false)
        {
            nextspawntime += spawnRate;
           SpawnObject(objects[RandomObjectNumber()], spawnPositions[RandomSpawnNumber()]);
            

        }
        
    }
    private void SpawnObject(GameObject objectToSpawn,Transform newTransform)
    {
        Instantiate(objectToSpawn, newTransform.position, newTransform.rotation);

    }
    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);

    }
    private int RandomObjectNumber()
    {
        return Random.Range(0,objects.Length);
    }
}
