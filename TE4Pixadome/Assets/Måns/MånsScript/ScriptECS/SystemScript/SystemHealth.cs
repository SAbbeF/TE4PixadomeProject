using Unity.Entities;
using UnityEngine;
public class SystemHealth : SystemBase
{

    protected override void OnUpdate()
    {
        Entities.WithAll<HealthTag.HealthTag>().ForEach((Entity entity) =>
         {

            



        }).Run();
    }
}