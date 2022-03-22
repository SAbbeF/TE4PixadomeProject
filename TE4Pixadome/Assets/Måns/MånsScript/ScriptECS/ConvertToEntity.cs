using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class ConvertToEntity : MonoBehaviour, IConvertGameObjectToEntity
{
    public GameObject enemyGameObject;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

        using (BlobAssetStore blobAssetStore = new BlobAssetStore())
        {

            Entity enemyPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy
                (enemyGameObject, GameObjectConversionSettings.FromWorld(dstManager.World, blobAssetStore));


        }

    }
}
