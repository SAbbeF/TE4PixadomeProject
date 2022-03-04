using System.Collections.Generic;
using UnityEngine;
using Mirage;

public class EnemyPoolManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private ClientObjectManager clientObjectManager;

    [SerializeField]
    private int startSize;

    [SerializeField]
    private int maxSize;

    [SerializeField]
    private NetworkIdentity prefab;

    [Header("Debug")]
    [SerializeField] int currentCount;

    Queue<NetworkIdentity> pool;

    EnemyPoolManager()
    {
        startSize = 5;
        maxSize = 20;
    }

    void Start()
    {
        InitializePool();

        clientObjectManager.RegisterPrefab(prefab, SpawnHandler, UnspawnHandler);
    }

    // used by clientObjectManager.RegisterPrefab
    NetworkIdentity SpawnHandler(SpawnMessage msg)
    {
        return GetFromPool((Vector3)msg.position, (Quaternion)msg.rotation);
    }

    // used by clientObjectManager.RegisterPrefab
    void UnspawnHandler(NetworkIdentity spawned)
    {
        PutBackInPool(spawned);
    }

    void OnDestroy()
    {
        clientObjectManager.UnregisterPrefab(prefab);
    }

    private void InitializePool()
    {
        pool = new Queue<NetworkIdentity>();
        for (int i = 0; i < startSize; i++)
        {
            NetworkIdentity next = CreateNew();

            pool.Enqueue(next);
        }
    }

    NetworkIdentity CreateNew()
    {
        if (currentCount > maxSize)
        {
            Debug.LogError($"Pool has reached max size of {maxSize}");
            return null;
        }

        // use this object as parent so that objects dont crowd hierarchy
        NetworkIdentity next = Instantiate(prefab, transform);
        next.name = $"{prefab.name}_pooled_{currentCount}";
        next.gameObject.SetActive(false);
        currentCount++;
        return next;
    }


    // Used to take Object from Pool.
    public NetworkIdentity GetFromPool(Vector3 position, Quaternion rotation)
    {
        NetworkIdentity next = pool.Count > 0
            ? pool.Dequeue() // take from pool
            : CreateNew(); // create new because pool is empty

        // CreateNew might return null if max size is reached
        if (next == null) { return null; }

        // set position/rotation and set active
        next.transform.position = position;
        next.transform.rotation = rotation;
        next.gameObject.SetActive(true);
        return next;
    }

    public void PutBackInPool(NetworkIdentity spawned)
    {
        // disable object
        spawned.gameObject.SetActive(false);

        // add back to pool
        pool.Enqueue(spawned);
    }
}
