using UnityEngine;

public class MovementSystem : ECSSystem
{
    public override void Init()
    {
        Debug.Log("Movement System Initialized");
    }

    public override void Update()
    {
        var entities = ECSManager.Instance.GetEntities();
        var movingEntities = FilterEntities<PositionComponent>(entities).Exec<ScaleComponent>().GetEntities();
        
        foreach (var entity in movingEntities)
        {
            var position = entity.Get<PositionComponent>();
            position.x += 0.01f; 
            position.y += 0.01f; 
            
            if (entity.GameObject != null)
            {
                entity.GameObject.transform.position = new Vector3(position.x, position.y, 0);
                Debug.Log($"Entity {entity.Id}: Position ({position.x}, {position.y})");
            }
        }
    }

    public override void Destroy()
    {
        Debug.Log("Movement System Destroyed");
    }
}