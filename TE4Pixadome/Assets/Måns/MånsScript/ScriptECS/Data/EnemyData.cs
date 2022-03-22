using Unity.Entities;
using UnityEngine;

public struct EnemyData : IComponentData//, IConvertGameObjectToEntity
{
    public float health;
    //public GameObject enemyGameObject;

    //public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    //{

    //    using (BlobAssetStore blobAssetStore = new BlobAssetStore())
    //    {

    //        Entity enemyPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy
    //            (enemyGameObject, GameObjectConversionSettings.FromWorld(dstManager.World, blobAssetStore));


    //    }

    //}

}
