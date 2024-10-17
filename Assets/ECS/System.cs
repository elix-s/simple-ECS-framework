using System.Collections.Generic;
using System.Linq;

public abstract class ECSSystem
{
    public abstract void Init();
    public abstract void Update();
    public abstract void Destroy();
    
    public FilteredEntityCollection FilterEntities<TInclude>(IEnumerable<Entity> entities) where TInclude : Component
    {
        return new FilteredEntityCollection(entities.Where(entity => entity.Has<TInclude>()));
    }
}