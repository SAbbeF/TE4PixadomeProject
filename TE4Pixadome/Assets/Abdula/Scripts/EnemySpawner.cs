using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirage;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField]
    private NetworkIdentity[] enemyPrefabs;

    [SerializeField]
    private NetworkManagerLobby networkManagerLobby;

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

    }

    private void Start()
    {
        currentTimeToSpawn = timeToSpawn;
        currentObjectNumber = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            SpawnEnemy();
        }

        UpdateTimer();

        //DestorySpawnedEnemies();
    }

    private void SpawnEnemy()
    {
        if (networkManagerLobby.Server.Active)
        {
            Vector3 position = center + new Vector3(
                Random.Range(-size.x / 2, size.x / 2),
                Random.Range(-size.y / 2, size.y / 2),
                Random.Range(-size.z / 2, size.z / 2));

            if (currentObjectNumber < maxObjects)
            {
                for (int i = 0; i < enemyPrefabs.Length; i++)
                {
                    NetworkIdentity enemyPrefab = enemyPrefabs[i];
                    GameObject.Instantiate(enemyPrefab, position, Quaternion.identity);
                    networkManagerLobby.ServerObjectManager.Spawn(enemyPrefab);
                    spawnedEnemies.Add(enemyPrefab);
                }
            }
        }
    }

    private void DestorySpawnedEnemies()
    {
        if (!networkManagerLobby.Server.Active)
        {
            networkManagerLobby.ClientObjectManager.DestroyAllClientObjects();
            foreach (NetworkIdentity sphere in spawnedEnemies)
            {
                //spawnedSpheres[0] = Destroy(spawnedSpheres[0].gameObject);
            }
        }
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
