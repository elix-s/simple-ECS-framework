using UnityEngine;

public class EntityBehaviour : MonoBehaviour
{
    private Entity _entity;
    
    public void Initialize(Entity entity)
    {
        _entity = entity;
    }
}