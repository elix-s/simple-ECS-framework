using System.Collections.Generic;
using System.Linq;

public class FilteredEntityCollection
{
    private IEnumerable<Entity> entities;
    
    public FilteredEntityCollection(IEnumerable<Entity> entities)
    {
        this.entities = entities;
    }
    
    public FilteredEntityCollection Exec<TExclude>() where TExclude : Component
    {
        entities = entities.Where(entity => !entity.Has<TExclude>());
        return this; 
    }
    
    public IEnumerable<Entity> GetEntities()
    {
        return entities;
    }
}