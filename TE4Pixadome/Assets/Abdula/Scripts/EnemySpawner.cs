using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirage;

public class EnemySpawner : NetworkBehaviour
{
    //[SerializeField]
    //private NetworkIdentity[] enemyPrefabs;
    private NetworkManagerLobby networkManagerLobby;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Vector3 center;

    [SerializeField]
    private Vector3 size;

    [SerializeField]
    private int maxObjects;

    private int currentObjectNumber;

    [SerializeField]
    private float timeToSpawn;

    private float currentTimeToSpawn;

    private List<NetworkIdentity> spawnedEnemies;

    private EnemySpawner()
    {
        spawnedEnemies = new List<NetworkIdentity>();
    }

    private void Awake()
    {
        networkManagerLobby = FindObjectOfType<NetworkManagerLobby>();
    }

    private void Start()
    {
        currentTimeToSpawn = timeToSpawn;
        currentObjectNumber = 0;
    }

    private void Update()
    {
        UpdateTimer();

        DestorySpawnedEnemies();
    }

    private void SpawnEnemy()
    {
        if (networkManagerLobby.Server.Active)
        {
            if (currentObjectNumber < maxObjects)
            {
                Vector3 position = RandomPosition();
                currentObjectNumber++;
                GameObject spawned = Instantiate(enemyPrefab, position, Quaternion.identity);
                spawned.name = $"{enemyPrefab.name}_{currentObjectNumber}";
                networkManagerLobby.ServerObjectManager.Spawn(spawned);
            }
        }
    }

    private void DestorySpawnedEnemies()
    {
        if (!networkManagerLobby.Server.Active)
        {
            networkManagerLobby.ClientObjectManager.DestroyAllClientObjects();
        }
    }

    private Vector3 RandomPosition()
    {
         Vector3 position = center + new Vector3(
    Random.Range(-size.x / 2, size.x / 2),
    Random.Range(-size.y / 2, size.y / 2),
    Random.Range(-size.z / 2, size.z / 2));

        return position;
    }

    private void UpdateTimer()
    {
        if (currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            currentTimeToSpawn = timeToSpawn;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
        //Gizmos.DrawCube(transform.localPosition + center, size);
    }
}