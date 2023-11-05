using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject flyPrefab;
    public GameObject butterflyPrefab;
    public GameObject spiderPrefab;

    public Transform[] spawnPoints; 
    public float spawnTime = 2f; 
    public Vector2 spawnCountRange = new Vector2(1, 5); 

    private float timer;

    void Start()
    {
        timer = spawnTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnCreatures();
            timer = spawnTime;
        }
    }

    void SpawnCreatures()
    {
        
        int spawnCount = Random.Range((int)spawnCountRange.x, (int)spawnCountRange.y);

        for (int i = 0; i < spawnCount; i++)
        {
           
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

           
            GameObject creaturePrefab = ChooseRandomCreature();

           
            Instantiate(creaturePrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    GameObject ChooseRandomCreature()
    {
        int randomIndex = Random.Range(0, 3); 

        switch (randomIndex)
        {
            case 0:
                return flyPrefab;
            case 1:
                return butterflyPrefab;
            case 2:
                return spiderPrefab;
            default:
                return flyPrefab; 
        }
    }
}
