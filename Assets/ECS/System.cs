using System.Collections.Generic;

public abstract class ECSSystem
{
    public abstract void Init();
    public abstract void Update();
    public abstract void Destroy();
    
    public List<Entity> FilterEntities<T>(IEnumerable<Entity> entities) where T : Component
    {
        List<Entity> filteredEntities = new List<Entity>();

        foreach (var entity in entities)
        {
            if (entity.Has<T>())
            {
                filteredEntities.Add(entity);
            }
        }

        return filteredEntities;
    }
}