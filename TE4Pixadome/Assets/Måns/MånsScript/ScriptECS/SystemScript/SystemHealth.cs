using Unity.Entities;
public class SystemHealth : SystemBase
{

    protected override void OnUpdate()
    {
        Entities.WithAll<HealthTag>().ForEach((Entity entity) =>
         {



         }).Run();
    }
}